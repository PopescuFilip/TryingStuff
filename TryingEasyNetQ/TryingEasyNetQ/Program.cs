// See https://aka.ms/new-console-template for more information
using EasyNetQ;
using EasyNetQ.Topology;

Console.WriteLine("Hello, World!");

var bus = RabbitHutch.CreateBus("connString").Advanced;
var exchange = bus.ExchangeDeclare("myExchange", ExchangeType.Header);

var queue = bus.QueueDeclare("queue name");
var headers = new Dictionary<string, object> { { "key", "value" } };

var s = bus.Bind(exchange, queue, "routingKey", headers);

bus.Consume(queue, (body, properties, info) =>
{

});

var message = new Message<string>("cacamaca");
message.Properties.Headers = headers;

bus.Publish(exchange, "routingKey", true, message);
