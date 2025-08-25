using CarRentApp.Queries.Notifications.GetAvailableCarsErrorLog;
using CarRentApp.Queries.Requests.GetAvailableCarsErrorLog;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Handlers.QueryHandlers.Requests.GetAvailableCarsErrorLog
{
    public class GetAvailableCarsErrorLogRequestHandler : IRequestHandler<GetAvailableCarsErrorLogRequest, object>
    {
        private readonly IMediator _mediator;

        public GetAvailableCarsErrorLogRequestHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<object> Handle(GetAvailableCarsErrorLogRequest request, CancellationToken cancellationToken)
        {
            await _mediator.Publish(new GetAvailableCarsErrorLogNotification
            {
                ErrorMessage = request.ErrorMessage
            }, cancellationToken);

            return "ok";
        }
    }
}
