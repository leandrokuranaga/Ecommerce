namespace ECommerce.Infra.ServiceBus.Consumers
{
    public interface IMessageConsumer<T>
    {
        Task HandleMessageAsync(T message);
    }

}
