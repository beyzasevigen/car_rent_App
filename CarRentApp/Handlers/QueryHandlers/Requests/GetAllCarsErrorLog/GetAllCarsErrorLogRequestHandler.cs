using CarRentApp.Queries.Notifications.GetCarErrorLog;
using CarRentApp.Queries.Requests.GetAllCarsErrorLog;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Handlers.QueryHandlers.Requests.GetAllCarsErrorLog
{
    public class GetAllCarsErrorLogRequestHandler : IRequestHandler<GetAllCarsErrorLogRequest, object>
    {
        private readonly IMediator _mediator;

        public GetAllCarsErrorLogRequestHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<object> Handle(GetAllCarsErrorLogRequest request, CancellationToken cancellationToken)
        {
            await _mediator.Publish(new GetAllCarsErrorLogNotification
            {
                ErrorMessage = request.ErrorMessage
            }, cancellationToken);

            return "ok";
        }
    }
}
