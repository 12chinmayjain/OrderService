using System.Threading.Channels;

namespace OrderService.Queue
{
    public class MessageQueue : IMessageQueue
    {
        private readonly Channel<string> _channel = Channel.CreateUnbounded<string>();

        public MessageQueue()
        {
            Task.Run(async () =>
            {
                await foreach (var msg in _channel.Reader.ReadAllAsync())
                {
                    Console.WriteLine($"[Queue] Processing message: {msg}");
                }
            });
        }

        public void Publish(string message)
        {
            _channel.Writer.WriteAsync(message);
        }
    }
}
