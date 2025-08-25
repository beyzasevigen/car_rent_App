using CarRentApp.Queries.Notifications.GetAllCompanies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Handlers.QueryHandlers.Notifications.GetAllCompanies
{
    public class GetAllCompaniesNotificationHandler : INotificationHandler<GetAllCompaniesNotification>
    {
        public async Task Handle(GetAllCompaniesNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"{DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")} => GetAllCompanies method called");
            await Task.CompletedTask;
        }
    }
}
