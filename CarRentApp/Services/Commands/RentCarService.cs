using CarRentApp.Commands.Notifications.CreateCustomer;
using CarRentApp.Commands.Notifications.RentCar;
using CarRentApp.Commands.Requests.CreateCustomer;
using CarRentApp.Commands.Requests.CreateCustomerErrorLog;
using CarRentApp.Commands.Requests.RentCar;
using CarRentApp.Commands.Requests.RentCarErrorLog;
using CarRentApp.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Services.Commands
{
    public class RentCarService
    {
        private readonly IMediator _mediator;

        public RentCarService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IServiceResult> RentCarAsync(RentCarRequest request, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _mediator.Send(request, cancellationToken);

                if (string.IsNullOrEmpty(result))
                {
                    await _mediator.Send(new RentCarErrorLogRequest("Database log not succeded"), cancellationToken);

                    return ServiceResult.Failure("Database log not succeded");
                }
                await _mediator.Publish(new RentCarNotification(), cancellationToken);

                return ServiceResult.IsSuccess(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
