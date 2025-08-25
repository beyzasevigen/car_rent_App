using CarRentApp.Commands.Notifications.CreateCustomerErrorLog;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Handlers.CommandHandlers.Notifications.CreateCustomerErrorLog
{
    public class CreateCustomerErrorLogNotificationHandler : INotificationHandler<CreateCustomerErrorLogNotification>
    {
        public async Task Handle(CreateCustomerErrorLogNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"[ERROR] {DateTime.Now:dd.MM.yyyy HH:mm:ss} => {notification.ErrorMessage}");

            await Task.CompletedTask;
        }
    }
}
