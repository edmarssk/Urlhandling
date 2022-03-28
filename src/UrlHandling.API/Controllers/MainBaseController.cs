using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using UrlHandling.Business.Interfaces.Services;
using UrlHandling.Business.Notifications;

namespace UrlHandling.API.Controllers
{
    [ApiController]
    public abstract class MainBaseController : ControllerBase
    {
        private readonly INotifier _notifier;
        public MainBaseController(INotifier notifier)
        {
            _notifier = notifier;

        }

        protected bool ValidSolicitation()
        {
            return !_notifier.HasNotifications();
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (ValidSolicitation())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _notifier.GetNotifications().Select(m => m.Message)
            });
        }
        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid)
                NotifyErrorsModalInvalid(modelState);

            return CustomResponse();
        }

        protected void NotifyErrorsModalInvalid(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(e => e.Errors);

            foreach (var item in errors)
            {
                var error = item.Exception == null ? item.ErrorMessage : item.Exception.Message;
                NotifyError(error);
            }
        }

        protected void NotifyError(string message)
        {
            _notifier.InsertNotification(new Notification(message));
        }
    }
}
