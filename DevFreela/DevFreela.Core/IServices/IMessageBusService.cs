namespace DevFreela.Core.IServices
{
    public interface IMessageBusService
    {
        void Publish(string queue,byte[] message);
    }
}