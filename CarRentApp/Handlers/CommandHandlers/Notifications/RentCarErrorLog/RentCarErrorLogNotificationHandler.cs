using CarRentApp.Commands.Notifications.RentCarErrorLog;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Handlers.CommandHandlers.Notifications.RentCarErrorLog
{
    public class RentCarErrorLogNotificationHandler : INotificationHandler<RentCarErrorLogNotification>
    {
        public async Task Handle(RentCarErrorLogNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"[ERROR] {DateTime.Now:dd.MM.yyyy HH:mm:ss} => {notification.ErrorMessage}");

            await Task.CompletedTask;
        }
    }
}
