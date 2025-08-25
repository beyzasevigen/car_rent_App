using CarRentApp.Queries.Notifications.GetAllContractsErrorLog;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Handlers.QueryHandlers.Notifications.GetAllContractsErrorLog
{
    public class GetAllContractsErrorLogNotificationHandler : INotificationHandler<GetAllContractsErrorLogNotification>
    {
        public async Task Handle(GetAllContractsErrorLogNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"[ERROR] {DateTime.Now:dd.MM.yyyy HH:mm:ss} => {notification.ErrorMessage}");

            await Task.CompletedTask;
        }
    }
}
