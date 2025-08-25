using CarRentApp.Commands.Notifications.RentCarErrorLog;
using CarRentApp.Commands.Requests.RentCarErrorLog;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Handlers.CommandHandlers.Requests.RentCarErrorLog
{
    public class RentCarErrorLogRequestHandler : IRequestHandler<RentCarErrorLogRequest, object>
    {
        private readonly IMediator _mediator;

        public RentCarErrorLogRequestHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<object> Handle(RentCarErrorLogRequest request, CancellationToken cancellationToken)
        {
            await _mediator.Publish(new RentCarErrorLogNotification
            {
                ErrorMessage = request.ErrorMessage
            }, cancellationToken);

            return "ok";
        }
    }
}
