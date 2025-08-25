using CarRentApp.Queries.Notifications.GetAvailableCarsErrorLog;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Handlers.QueryHandlers.Notifications.GetAvailableCarsErrorLog
{
    public class GetAvailableCarsErrorLogNotificationHandler : INotificationHandler<GetAvailableCarsErrorLogNotification>
    {
        public async Task Handle(GetAvailableCarsErrorLogNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"[ERROR] {DateTime.Now:dd.MM.yyyy HH:mm:ss} => {notification.ErrorMessage}");

            await Task.CompletedTask;
        }
    }
}
