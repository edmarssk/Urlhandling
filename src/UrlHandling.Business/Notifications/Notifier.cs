using System;
using System.Collections.Generic;
using System.Text;
using UrlHandling.Business.Interfaces.Services;

namespace UrlHandling.Business.Notifications
{
    public class Notifier : INotifier
    {
        private List<Notification> _notifications;

        public Notifier()
        {
            _notifications = new List<Notification>();
        }
        public List<Notification> GetNotifications()
        {
            return _notifications;
        }

        public bool HasNotifications()
        {
            return _notifications.Count > 0;
        }

        public void InsertNotification(Notification notification)
        {
            _notifications.Add(notification);
        }
    }
}
