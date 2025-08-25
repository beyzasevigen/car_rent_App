using CarRentApp.Queries.Notifications.GetCarById;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Handlers.QueryHandlers.Notifications.GetCarById
{
    public class GetCarByIdNotificationHandler : INotificationHandler<GetCarByIdNotification>
    {
        public async Task Handle(GetCarByIdNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"{DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")} => GetCarById method called");
            await Task.CompletedTask;
        }
    }
}
