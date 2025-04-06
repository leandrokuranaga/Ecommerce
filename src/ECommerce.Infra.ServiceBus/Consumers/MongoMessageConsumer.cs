using ECommerce.Infra.ServiceBus.Consumers;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

public abstract class MongoMessageConsumer<T> : BackgroundService, IMessageConsumer<T>
{
    protected readonly IMongoCollection<T> _collection;
    private readonly string _queueName;
    private IModel _channel;
    private IConnection _connection;

    protected MongoMessageConsumer(IMongoCollection<T> collection, string queueName)
    {
        _collection = collection;
        _queueName = queueName;

        var factory = new ConnectionFactory { HostName = "localhost" };
        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();

        _channel.QueueDeclare(
            queue: _queueName,
            durable: true,
            exclusive: false,
            autoDelete: false,
            arguments: null);
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var consumer = new EventingBasicConsumer(_channel);

        consumer.Received += async (model, ea) =>
        {
            var json = Encoding.UTF8.GetString(ea.Body.ToArray());

            try
            {
                var message = JsonSerializer.Deserialize<T>(json);
                if (message != null)
                    await HandleMessageAsync(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao processar mensagem: {ex.Message}");
            }
        };

        _channel.BasicConsume(queue: _queueName, autoAck: true, consumer: consumer);

        return Task.CompletedTask;
    }

    public abstract Task HandleMessageAsync(T message);

    public override void Dispose()
    {
        _channel?.Dispose();
        _connection?.Dispose();
        base.Dispose();
    }
}
