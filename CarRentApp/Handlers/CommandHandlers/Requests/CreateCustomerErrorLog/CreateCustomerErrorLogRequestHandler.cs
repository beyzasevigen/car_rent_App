using CarRentApp.Commands.Notifications.CreateCustomerErrorLog;
using CarRentApp.Commands.Requests.CreateCustomerErrorLog;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Handlers.CommandHandlers.Requests.CreateCustomerErrorLog
{
    public class CreateCustomerErrorLogRequestHandler : IRequestHandler<CreateCustomerErrorLogRequest,object>
    {
        private readonly IMediator _mediator;

        public CreateCustomerErrorLogRequestHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<object> Handle(CreateCustomerErrorLogRequest request, CancellationToken cancellationToken)
        {
            await _mediator.Publish(new CreateCustomerErrorLogNotification
            {
                ErrorMessage = request.ErrorMessage
            }, cancellationToken);

            return "ok";
        }
    }
}
