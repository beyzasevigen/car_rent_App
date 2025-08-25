using CarRentApp.Commands.Notifications.CreateCompanyErrorLog;
using CarRentApp.Commands.Requests.CreateCompanyErroLog;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Handlers.CommandHandlers.Requests.CreateCompanyErrorLog
{
    public class CreateCompanyErrorLogRequestHandler : IRequestHandler<CreateCompanyErrorLogRequest, object>
    {
        private readonly IMediator _mediator;

        public CreateCompanyErrorLogRequestHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<object> Handle(CreateCompanyErrorLogRequest request, CancellationToken cancellationToken)
        {
            await _mediator.Publish(new CreateCompanyErrorLogNotification
            {
                ErrorMessage = request.ErrorMessage
            }, cancellationToken);

            return "ok";
        }
    }
}
