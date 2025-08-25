using CarRentApp.Commands.Notifications.ReturnCarErrorLog;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Handlers.CommandHandlers.Notifications.ReturnCarErrorLog
{
    public class ReturnCarErrorLogNotificationHandler : INotificationHandler<ReturnCarErrorLogNotification>
    {
        public async Task Handle(ReturnCarErrorLogNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"[ERROR] {DateTime.Now:dd.MM.yyyy HH:mm:ss} => {notification.ErrorMessage}");

            await Task.CompletedTask;
        }
    }
}
