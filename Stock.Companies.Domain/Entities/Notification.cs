namespace Stock.Companies.Domain.Entities
{
    public class Notification
    {
        public Notification(string message)
        {
            Message = message;
        }

        public string Message { get; private set;}
    }
}