using System;
using System.Collections.Generic;
using System.Text;
using UrlHandling.Business.Notifications;

namespace UrlHandling.Business.Interfaces.Services
{
    public interface INotifier
    {
        void InsertNotification(Notification notification);
        List<Notification> GetNotifications();
        bool HasNotifications();
    }
}
