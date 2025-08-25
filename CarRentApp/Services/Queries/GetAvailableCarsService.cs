using CarRentApp.Queries.Notifications.GetAvailableCars;
using CarRentApp.Queries.Notifications.GetCar;
using CarRentApp.Queries.Requests.GetAllCarsErrorLog;
using CarRentApp.Queries.Requests.GetAvailableCars;
using CarRentApp.Queries.Requests.GetAvailableCarsErrorLog;
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
    public class GetAvailableCarsService
    {
        private readonly IMediator _mediator;

        public GetAvailableCarsService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IServiceResult> GetAvailableCarsAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var availableCars = await _mediator.Send(new GetAvailableCarsRequest
                {
                    IsAvailable = true,
                    Brand = " "
                }, cancellationToken);

                if (availableCars == null || !availableCars.Any())
                {
                    await _mediator.Send(new GetAvailableCarsErrorLogRequest("No available cars found."), cancellationToken);
                    return ServiceResult.Failure("Available cars not found.");
                }

                await _mediator.Publish(new GetAvailableCarsNotification(), cancellationToken);
                return ServiceResult.IsSuccess(availableCars);
            }
            catch
            {
                throw;
            }
        }
    }
}
