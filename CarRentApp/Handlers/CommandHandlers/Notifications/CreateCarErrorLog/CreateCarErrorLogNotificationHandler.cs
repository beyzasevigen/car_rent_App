using CarRentApp.Commands.Notifications.CreateCarErrorLog;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Handlers.CommandHandlers.Notifications.CreateCarErrorLog
{
    public class CreateCarErrorLogNotificationHandler : INotificationHandler<CreateCarErrorLogNotification>
    {
        public async Task Handle(CreateCarErrorLogNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"[ERROR] {DateTime.Now:dd.MM.yyyy HH:mm:ss} => {notification.ErrorMessage}");

            await Task.CompletedTask;
        }
    }
}

