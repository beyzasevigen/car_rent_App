using CarRentApp.Commands.Notifications.CreateCompany;
using CarRentApp.Commands.Requests.CreateCar;
using CarRentApp.Commands.Requests.CreateCompany;
using CarRentApp.Commands.Requests.CreateCompanyErroLog;
using CarRentApp.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Services.Commands
{
    public class CreateCompanyService
    {
        private readonly IMediator _mediator;
        public CreateCompanyService(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IServiceResult> CreateCompanyAsync(CreateCompanyRequest request, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _mediator.Send(request, cancellationToken);
                if (string.IsNullOrEmpty(result))
                {
                    await _mediator.Send(new CreateCompanyErrorLogRequest("Database log not succeded"), cancellationToken);
                    return ServiceResult.Failure("Database log not succeded");
                }
                await _mediator.Publish(new CreateCompanyNotification(), cancellationToken);
                return ServiceResult.IsSuccess(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
