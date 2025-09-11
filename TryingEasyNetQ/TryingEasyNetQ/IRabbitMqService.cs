using EasyNetQ;

namespace TryingEasyNetQ;

public delegate void QueueConsumer(ReadOnlyMemory<byte> body, MessageProperties properties, MessageReceivedInfo info);

public interface IRabbitMqService
{
    void Consume(string queueName, RoutingInformation routingInfo, QueueConsumer queueConsumer);
    void Publish<T>(RoutingInformation routingInfo, T publishedObject);
}