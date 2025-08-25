using CarRentApp.Queries.Notifications.GetAvailableCars;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Handlers.QueryHandlers.Notifications.GetAvailableCars
{
    public class GetAvailableCarsNotificationHandler : INotificationHandler<GetAvailableCarsNotification>
    {
        public async Task Handle(GetAvailableCarsNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"{DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")} => GetAvailableCars method called");
            await Task.CompletedTask;
        }
    }
}
