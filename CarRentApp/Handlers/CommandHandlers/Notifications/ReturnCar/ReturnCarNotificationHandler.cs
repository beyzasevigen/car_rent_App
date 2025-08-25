using CarRentApp.Commands.Notifications.ReturnCar;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Handlers.CommandHandlers.Notifications.ReturnCar
{
    public class ReturnCarNotificationHandler : INotificationHandler<ReturnCarNotification>
    {
        public async Task Handle(ReturnCarNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"{DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")} => ReturnCar method called");
            await Task.CompletedTask;
        }
    }
}
