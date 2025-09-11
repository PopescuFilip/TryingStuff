//using EasyNetQ;
//using EasyNetQ.Topology;
//using System.Collections.Concurrent;
//using System.Windows;

//// track pending confirmations
//var pending = new ConcurrentDictionary<string, TaskCompletionSource<bool>>();

//var bus = RabbitHutch.CreateBus("host=localhost").Advanced;

//// declare confirmation queue
//var confirmQueue = await bus.QueueDeclareAsync("serviceA.confirmations");
//var confirmExchange = await bus.ExchangeDeclareAsync("serviceA.confirm.exchange", ExchangeType.Direct);
//await bus.BindAsync(confirmExchange, confirmQueue, "confirm");


//// consume confirmations
//bus.Consume<ConfirmationMessage>(confirmQueue, (msg, info) =>
//{
//    if (pending.TryRemove(msg.Properties.CorrelationId, out var tcs))
//    {
//        tcs.SetResult(true); // signal success
//    }
//    return Task.CompletedTask;
//});

//// send message + wait for reply
//async Task SendMessageAsync(MyPayload payload)
//{
//    var correlationId = Guid.NewGuid().ToString();
//    var tcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
//    pending[correlationId] = tcs;

//    var exchange = await bus.ExchangeDeclareAsync("serviceB.exchange", ExchangeType.Direct);
//    var message = new Message<MyPayload>(payload);
//    message.Properties.CorrelationId = correlationId;

//    await bus.PublishAsync(exchange, "serviceB.route", false, message);

//    // wait up to 1 minute
//    if (await Task.WhenAny(tcs.Task, Task.Delay(TimeSpan.FromMinutes(1))) == tcs.Task)
//    {
//        // got confirmation
//        Console.WriteLine("✅ Confirmation received!");
//    }
//    else
//    {
//        // timed out
//        Console.WriteLine("⚠ No confirmation received within 1 minute");

//        //MessageBox.Show("No confirmation received!", "Timeout");
//    }
//}

//// call it
//await SendMessageAsync(new MyPayload("Hello B"));

//public record ConfirmationMessage();
//public record MyPayload(string Data);
