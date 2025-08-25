using CarRentApp.Queries.Notifications.GetAllContracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Handlers.QueryHandlers.Notifications.GetAllContracts
{
    public class GetAllContractsNotificationHandler : INotificationHandler<GetAllContractsNotification>
    {
        public async Task Handle(GetAllContractsNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"{DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")} => GetAllContracts method called");
            await Task.CompletedTask;
        }
    }
}
