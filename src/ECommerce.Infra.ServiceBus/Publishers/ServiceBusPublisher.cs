using ECommerce.Infra.ServiceBus.Publishers;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

public class ServiceBusPublisher : IServiceBusPublisher
{
    private readonly string _hostName = "localhost";

    public void PublishToDirect<T>(T message, string exchange, string routingKey)
    {
        Publish(message, exchange, routingKey, "direct");
    }

    public void PublishToFanout<T>(T message, string exchange)
    {
        Publish(message, exchange, "", "fanout");
    }

    private void Publish<T>(T message, string exchange, string routingKey, string exchangeType)
    {
        var factory = new ConnectionFactory { HostName = _hostName };
        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        channel.ExchangeDeclare(exchange: exchange, type: exchangeType, durable: true);

        var json = JsonSerializer.Serialize(message);
        var body = Encoding.UTF8.GetBytes(json);

        channel.BasicPublish(
            exchange: exchange,
            routingKey: routingKey,
            basicProperties: null,
            body: body
        );
    }
}
