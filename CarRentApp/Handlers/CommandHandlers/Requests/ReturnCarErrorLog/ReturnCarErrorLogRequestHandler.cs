using CarRentApp.Commands.Notifications.ReturnCarErrorLog;
using CarRentApp.Commands.Requests.ReturnCarErrorLog;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Handlers.CommandHandlers.Requests.ReturnCarErrorLog
{
    public class ReturnCarErrorLogRequestHandler : IRequestHandler<ReturnCarErrorLogRequest, object>
    {
        private readonly IMediator _mediator;

        public ReturnCarErrorLogRequestHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<object> Handle(ReturnCarErrorLogRequest request, CancellationToken cancellationToken)
        {
            await _mediator.Publish(new ReturnCarErrorLogNotification
            {
                ErrorMessage = request.ErrorMessage
            }, cancellationToken);

            return "ok";
        }
    }
}
