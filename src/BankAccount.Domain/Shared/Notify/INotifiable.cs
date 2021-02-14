using System.Collections.Generic;

namespace BankAccount.Domain.Shared.Notify
{
    public interface INotifiable
    {
        public bool Invalid { get;}
        public bool Valid { get; }
        public IReadOnlyCollection<Notification> Notifications { get;}
        void AddNotification(Notification notification);
    }
}
