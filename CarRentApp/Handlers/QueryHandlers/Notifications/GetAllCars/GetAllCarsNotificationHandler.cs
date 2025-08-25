using CarRentApp.Queries.Notifications.GetCar;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Handlers.QueryHandlers.Notifications.GetAllCars
{
    public class GetAllCarsNotificationHandler : INotificationHandler<GetAllCarsNotification>
    {
        public async Task Handle(GetAllCarsNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"{DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")} => GetAllCars method called");
            await Task.CompletedTask;
        }
    }
}
