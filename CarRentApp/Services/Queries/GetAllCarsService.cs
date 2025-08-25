using CarRentApp.Queries.Requests.GetCar;
using CarRentApp.Queries.Requests.GetAllCarsErrorLog;
using CarRentApp.Queries.Notifications.GetCar;
using CarRentApp.Shared;
using MediatR;
using CarRentApp.Models;

namespace CarRentApp.Services
{
    public class GetAllCarsService
    {
        private readonly IMediator _mediator;

        public GetAllCarsService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IServiceResult> GetAllCarsAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var cars = await _mediator.Send(new GetAllCarsRequest(), cancellationToken);

                if (cars == null || !cars.Any())
                {
                    await _mediator.Send(new GetAllCarsErrorLogRequest("car not found."), cancellationToken);
                    return ServiceResult.Failure("car not found.");
                }

                await _mediator.Publish(new GetAllCarsNotification(), cancellationToken);
                return ServiceResult.IsSuccess(cars);
            }
            catch
            {
                throw;
            }
        }
    }
}
