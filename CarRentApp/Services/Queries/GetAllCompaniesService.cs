using CarRentApp.Commands.Notifications.CreateCar;
using CarRentApp.Commands.Requests.CreateCar;
using CarRentApp.Commands.Requests.CreateCarErrorLog;
using CarRentApp.Queries.Notifications.GetAllCompanies;
using CarRentApp.Queries.Notifications.GetCar;
using CarRentApp.Queries.Requests.GetAllCarsErrorLog;
using CarRentApp.Queries.Requests.GetAllCompanies;
using CarRentApp.Queries.Requests.GetAllCompaniesErrorLog;
using CarRentApp.Queries.Requests.GetCar;
using CarRentApp.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Services.Queries
{
    public class GetAllCompaniesService
    {
        private readonly IMediator _mediator;

        public GetAllCompaniesService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IServiceResult> GetAllCompaniesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var companies = await _mediator.Send(new GetAllCompaniesRequest(), cancellationToken);

                if (companies == null || !companies.Any())
                {
                    await _mediator.Send(new GetAllCompaniesErrorLogRequest("No company found"), cancellationToken);
                    return ServiceResult.Failure("company not found");
                }

                await _mediator.Publish(new GetAllCompaniesNotification(), cancellationToken);
                return ServiceResult.IsSuccess(companies);
            }
            catch
            {
                throw;
            }
        }
    }
}
