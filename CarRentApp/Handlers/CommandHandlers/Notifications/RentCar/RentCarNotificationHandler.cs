using CarRentApp.Commands.Notifications.RentCar;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Handlers.CommandHandlers.Notifications.RentCar
{
    public class RentCarNotificationHandler : INotificationHandler<RentCarNotification>
    {
        public async Task Handle(RentCarNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"{DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")} => RentCar method called");
            await Task.CompletedTask;
        }
    }
}
