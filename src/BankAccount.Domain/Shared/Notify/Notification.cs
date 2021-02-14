namespace BankAccount.Domain.Shared.Notify
{
    public sealed class Notification
    {
        public Notification(string message)
        {
            Message = message;
        }

        public string Message { get; }        
    }
}
