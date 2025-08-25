using CarRentApp.Commands.Notifications.CreateCompany;
using CarRentApp.Commands.Notifications.CreateCompanyErrorLog;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Handlers.CommandHandlers.Notifications.CreateCompanyErrorLog
{
    public class CreateCompanyErrorLogNotificationHandler : INotificationHandler<CreateCompanyErrorLogNotification>
    {
        public async Task Handle(CreateCompanyErrorLogNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"[ERROR] {DateTime.Now:dd.MM.yyyy HH:mm:ss} => {notification.ErrorMessage}");
            await Task.CompletedTask;
        }
    }
}
