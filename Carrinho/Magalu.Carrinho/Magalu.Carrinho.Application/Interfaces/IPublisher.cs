namespace Magalu.Carrinho.Application.Interfaces
{
    public interface IPublisher<T> where T : class
    {
        Task PublishAsync(T message, string queueName);
    }
}
