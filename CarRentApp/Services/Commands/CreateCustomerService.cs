using CarRentApp.Commands.Notifications.CreateCar;
using CarRentApp.Commands.Notifications.CreateCustomer;
using CarRentApp.Commands.Requests.CreateCar;
using CarRentApp.Commands.Requests.CreateCarErrorLog;
using CarRentApp.Commands.Requests.CreateCustomer;
using CarRentApp.Commands.Requests.CreateCustomerErrorLog;
using CarRentApp.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Services.Commands
{
    public class CreateCustomerService
    {
        private readonly IMediator _mediator;

        public CreateCustomerService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IServiceResult> CreateCustomerAsync(CreateCustomerRequest request, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _mediator.Send(request, cancellationToken);

                if (string.IsNullOrEmpty(result))
                {
                    await _mediator.Send(new CreateCustomerErrorLogRequest("Database log not succeded"), cancellationToken);

                    return ServiceResult.Failure("Database log not succeded");
                }
                await _mediator.Publish(new CreateCustomerNotification(), cancellationToken);

                return ServiceResult.IsSuccess(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
