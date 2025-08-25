using CarRentApp.Commands.Notifications.CreateCar;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Handlers.CommandHandlers.Notifications.CreateCar
{
    public class CreateCarNotificationHandler : INotificationHandler<CreateCarNotification>
    {
        public async Task Handle(CreateCarNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"{DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")} => CreateCar method called");
            await Task.CompletedTask;
        }
    }
}
