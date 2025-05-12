namespace OrderService.Queue
{
    public interface IMessageQueue
    {
        void Publish(string message);
    }

}
