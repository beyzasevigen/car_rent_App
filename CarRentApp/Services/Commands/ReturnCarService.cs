using CarRentApp.Commands.Notifications.CreateCustomer;
using CarRentApp.Commands.Notifications.ReturnCar;
using CarRentApp.Commands.Requests.CreateCustomer;
using CarRentApp.Commands.Requests.CreateCustomerErrorLog;
using CarRentApp.Commands.Requests.ReturnCar;
using CarRentApp.Commands.Requests.ReturnCarErrorLog;
using CarRentApp.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Services.Commands
{
    public class ReturnCarService
    {
        private readonly IMediator _mediator;

        public ReturnCarService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IServiceResult> ReturnCarAsync(ReturnCarRequest request, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _mediator.Send(request, cancellationToken);

                if (string.IsNullOrEmpty(result))
                {
                    await _mediator.Send(new ReturnCarErrorLogRequest("Database log not succeded"), cancellationToken);

                    return ServiceResult.Failure("Database log not succeded");
                }
                await _mediator.Publish(new ReturnCarNotification(), cancellationToken);

                return ServiceResult.IsSuccess(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
