using CarRentApp.Commands.Notifications.CreateCarErrorLog;
using CarRentApp.Commands.Requests.CreateCarErrorLog;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Handlers.CommandHandlers.Requests.CreateCarErrorLog
{
    public class CreateCarErrorLogRequestHandler : IRequestHandler<CreateCarErrorLogRequest, object>
    {
        private readonly IMediator _mediator;
        public CreateCarErrorLogRequestHandler(IMediator mediator) 
        {
            _mediator = mediator;
        }
        public async Task<object> Handle(CreateCarErrorLogRequest request, CancellationToken cancellationToken)
        {
            await _mediator.Publish(new CreateCarErrorLogNotification
            {
                ErrorMessage = request.ErrorMessage
            }, cancellationToken);
            return "ok";
        }
    }
}
