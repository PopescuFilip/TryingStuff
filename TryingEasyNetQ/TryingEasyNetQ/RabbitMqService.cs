using EasyNetQ;
using EasyNetQ.Topology;

namespace TryingEasyNetQ;

public class RabbitMqService : IRabbitMqService
{
    private readonly IAdvancedBus _bus;
    private readonly Exchange _exchange;

    public RabbitMqService()
    {
        _bus = RabbitHutch.CreateBus("connString").Advanced;
        _exchange = _bus.ExchangeDeclare("myExchange", ExchangeType.Header);
    }

    public void Consume(string queueName, RoutingInformation routingInfo, QueueConsumer queueConsumer)
    {
        var queue = _bus.QueueDeclare(queueName);

        _bus.Bind(_exchange, queue, routingInfo.RoutingKey, routingInfo.Headers);
        _bus.Consume(queue, (body, properties, info) => queueConsumer(body, properties, info));
    }

    public void Publish<T>(RoutingInformation routingInfo, T publishedObject)
    {
        var message = new Message<T>(publishedObject);
        message.Properties.Headers = routingInfo.Headers;

        _bus.Publish(_exchange, routingInfo.RoutingKey, true, message);
    }
}
