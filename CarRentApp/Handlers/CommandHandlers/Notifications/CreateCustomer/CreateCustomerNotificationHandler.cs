using CarRentApp.Commands.Notifications.CreateCustomer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Handlers.CommandHandlers.Notifications.CreateCustomer
{
    public class CreateCustomerNotificationHandler : INotificationHandler<CreateCustomerNotification>
    {
        public async Task Handle(CreateCustomerNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"{DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")} => CreateCustomer method called");
            await Task.CompletedTask;
        }
    }
}
