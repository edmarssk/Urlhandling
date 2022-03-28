using System;
using System.Collections.Generic;
using System.Text;
using UrlHandling.Business.Interfaces.Services;
using UrlHandling.Business.Notifications;

namespace UrlHandling.Business.Services
{
    public abstract class BaseService
    {
        private readonly INotifier _notifier;

        protected BaseService(INotifier notifier)
        {
            _notifier = notifier;
        }

        protected void Notify(string mensagem)
        {
            _notifier.InsertNotification(new Notification(mensagem));
        }
    }
}

