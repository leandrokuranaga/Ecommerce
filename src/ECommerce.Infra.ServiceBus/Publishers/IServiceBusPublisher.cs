namespace ECommerce.Infra.ServiceBus.Publishers
{
    public interface IServiceBusPublisher
    {
        void PublishToDirect<T>(T message, string exchange, string routingKey);
        void PublishToFanout<T>(T message, string exchange);
    }

}
