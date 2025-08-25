using CarRentApp.Commands.Notifications.CreateCompany;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Handlers.CommandHandlers.Notifications.CreateCompany
{
    public class CreateCompanyNotificationHandler : INotificationHandler<CreateCompanyNotification>
    {
        public async Task Handle(CreateCompanyNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"{DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")} => CreateCompany method called");
            await Task.CompletedTask;
        }
    }
}
