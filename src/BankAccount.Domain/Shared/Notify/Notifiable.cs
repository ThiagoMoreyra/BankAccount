﻿using System.Collections.Generic;
using System.Linq;

namespace BankAccount.Domain.Shared.Notify
{
    public abstract class Notifiable: INotifiable
    {
        private readonly List<Notification> _notifications;
        protected Notifiable() => _notifications = new List<Notification>();
        public IReadOnlyCollection<Notification> Notifications => _notifications;

        public void AddNotification(string property, string message)
        {
            _notifications.Add(new Notification(message));
        }

        public void AddNotification(Notification notification)
        {
            _notifications.Add(notification);
        }

        public void AddNotifications(IReadOnlyCollection<Notification> notifications)
        {
            _notifications.AddRange(notifications);
        }

        public void AddNotifications(IList<Notification> notifications)
        {
            _notifications.AddRange(notifications);
        }

        public void AddNotifications(ICollection<Notification> notifications)
        {
            _notifications.AddRange(notifications);
        }

        public void AddNotifications(Notifiable item)
        {
            AddNotifications(item.Notifications);
        }

        public void AddNotifications(params Notifiable[] items)
        {
            foreach (var item in items)
                AddNotifications(item);
        }

        public void Clear()
        {
            _notifications.Clear();
        }

        public bool Invalid => _notifications.Any();
        public bool Valid => !Invalid;
    }
}
