using CarRentApp.Queries.Notifications.GetCarErrorLog;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Handlers.QueryHandlers.Notifications.GetAllCarsErrorLog
{
    public class GetAllCarsErrorLogNotificationHandler : INotificationHandler<GetAllCarsErrorLogNotification>
    {
        public async Task Handle(GetAllCarsErrorLogNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"[ERROR] {DateTime.Now:dd.MM.yyyy HH:mm:ss} => {notification.ErrorMessage}");

            await Task.CompletedTask;
        }
    }
}
