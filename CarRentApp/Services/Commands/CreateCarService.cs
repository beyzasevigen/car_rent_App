using CarRentApp.Commands.Requests.CreateCar;
using CarRentApp.Commands.Requests.CreateCarErrorLog;
using CarRentApp.Commands.Notifications.CreateCar;
using CarRentApp.Shared;
using MediatR;

namespace CarRentApp.Services.Commands
{
    public class CreateCarService
    {
        private readonly IMediator _mediator;

        public CreateCarService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IServiceResult> CreateCarAsync(CreateCarRequest request, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _mediator.Send(request, cancellationToken);

                if (string.IsNullOrEmpty(result))
                {
                    await _mediator.Send(new CreateCarErrorLogRequest("Veritabanına kayıt başarısız."), cancellationToken);

                    return ServiceResult.Failure("Veritabanına kayıt başarısız.");
                }

                
                await _mediator.Publish(new CreateCarNotification(), cancellationToken);

                return ServiceResult.IsSuccess(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

}
