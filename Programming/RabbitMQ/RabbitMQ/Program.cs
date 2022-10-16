using System.Text; 
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

var factory = new ConnectionFactory()
{
    HostName = "localhost",
};

using var conn = factory.CreateConnection();
using (var channel = conn.CreateModel())
{ 
    Receiving(channel);

    while (true)
    {
        var input = Console.ReadLine();
        if (string.Compare(input, "exit", true) == 0)
        {
            Console.WriteLine("exit..");
            break;
        }
        
        Send(input, channel);
    }
}

void Send(string input, IModel channel)
{
    channel.QueueDeclare
    (
        queue: "ChanService1",
        durable: false,
        exclusive: false,
        autoDelete: false,
        arguments: null
    );
 
    var body = Encoding.UTF8.GetBytes(input!); 

    channel.BasicPublish
    (
        exchange: "",
        routingKey: "ChanService1",
        basicProperties: null,
        body: body
    );

    Console.WriteLine($"[x] Sent {input}");
}

void Receiving(IModel channel)
{
    channel.QueueDeclare
    (
        queue: "ChanService1",
        durable: false,
        exclusive: false,
        autoDelete: false,
        arguments: null
    );

    var consumer = new EventingBasicConsumer(channel);
    consumer.Received += (model, ea) =>
    {
        var body = ea.Body.ToArray();
        var message = Encoding.UTF8.GetString(body);
        Console.WriteLine("[x] Received {0}", message);
    };
    
    channel.BasicConsume
    (
        queue: "ChanService1",
        autoAck: true,
        consumer: consumer
    ); 
}