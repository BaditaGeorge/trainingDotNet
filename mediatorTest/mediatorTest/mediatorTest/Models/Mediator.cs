using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

namespace mediatorTest.Models
{
    public class NotificationMessage : INotification
    {
        //public string Source { get; set; }
        public string NotifyText { get; set; }
    }

    public class NotificationManager
    {
        public List<NotificationMessage> Notifications { get; set; }

        public NotificationManager()
        {
            //Notifications = new List<NotificationMessage>() { new NotificationMessage { Source = "William",NotifyText="Hello!"},
            //new NotificationMessage{ Source="Samuel",NotifyText="Regards from Paris!"} };
        }

        public void AddNotification(NotificationMessage notifyText)
        {
            Notifications.Add(notifyText);
        }

        public NotificationMessage getLast()
        {
            return Notifications.Last();
        }

        public List<NotificationMessage> getAll()
        {
            return Notifications;
        }
    }

    public class Notifier : INotificationHandler<NotificationMessage>
    {
        public NotificationManager manager;

        public Notifier()
        {
            manager = new NotificationManager();
        }

        public Task Handle(NotificationMessage notification,CancellationToken cancellation)
        {
            //manager.AddNotification(notification);
            Debug.WriteLine("Handler 1" + notification.NotifyText);
            return Task.CompletedTask;
        }
    }

    public class SecondNotifier : INotificationHandler<NotificationMessage>
    {
        public Task Handle(NotificationMessage notification,CancellationToken cancellation)
        {
            Debug.WriteLine("Handler 2" + notification.NotifyText);
            return Task.CompletedTask;
        }
    }

    public class Query : IRequest<NotificationMessage>
    {
        public string NotifyText { get; set; }
    }

    

    public class NotifierMediatorService
    {
        private readonly IMediator _mediator;

        public NotifierMediatorService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public string Notify(string notifyText)
        {
            //_mediator.Publish(new NotificationMessage { NotifyText = notifyText });
            _mediator.Send(new NotificationMessage { NotifyText = notifyText });
            var text = JsonConvert.SerializeObject(new NotificationMessage { NotifyText = notifyText});
            return text;
        }
    }
}
