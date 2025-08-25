using CarRentApp.Queries.Notifications.GetAllCompaniesErrorLog;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Handlers.QueryHandlers.Notifications.GetAllCompaniesErrorLog
{
    public class GetAllCompaniesErrorLogNotificationHandler : INotificationHandler<GetAllCompaniesErrorLogNotification>
    {
        public async Task Handle(GetAllCompaniesErrorLogNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"[ERROR] {DateTime.Now:dd.MM.yyyy HH:mm:ss} => {notification.ErrorMessage}");

            await Task.CompletedTask;
        }
    }
}
