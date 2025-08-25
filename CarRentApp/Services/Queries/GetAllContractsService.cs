using CarRentApp.Queries.Notifications.GetAllContracts;
using CarRentApp.Queries.Notifications.GetCar;
using CarRentApp.Queries.Requests.GetAllCarsErrorLog;
using CarRentApp.Queries.Requests.GetAllContracts;
using CarRentApp.Queries.Requests.GetAllContractsErrorLog;
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
    public class GetAllContractsService
    {
        private readonly IMediator _mediator;

        public GetAllContractsService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IServiceResult> GetAllContractsAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var contracts = await _mediator.Send(new GetAllContractsRequest(), cancellationToken);

                if (contracts == null || !contracts.Any())
                {
                    await _mediator.Send(new GetAllContractsErrorLogRequest("No contract found."), cancellationToken);
                    return ServiceResult.Failure("contract not found.");
                }

                await _mediator.Publish(new GetAllContractsNotification(), cancellationToken);
                return ServiceResult.IsSuccess(contracts);
            }
            catch
            {
                throw;
            }
        }
    }
}
