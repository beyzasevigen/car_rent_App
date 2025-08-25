using CarRentApp.Queries.Notifications.GetCarByIdErrorLog;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Handlers.QueryHandlers.Notifications.GetCarByIdErrorLog
{
    public class GetCarByIdErrorLogNotificationHandler : INotificationHandler<GetCarByIdErrorLogNotification>
    {
        public async Task Handle(GetCarByIdErrorLogNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"[ERROR] {DateTime.Now:dd.MM.yyyy HH:mm:ss} => {notification.ErrorMessage}");

            await Task.CompletedTask;
        }
    }
}
