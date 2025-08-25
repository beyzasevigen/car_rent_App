using CarRentApp.Queries.Notifications.GetCarByIdErrorLog;
using CarRentApp.Queries.Requests.GetCarByIdErrorLog;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Handlers.QueryHandlers.Requests.GetCarByIdErrorLog
{
    public class GetCarByIdErrorLogRequestHandler : IRequestHandler<GetCarByIdErrorLogRequest, object>
    {
        private readonly IMediator _mediator;

        public GetCarByIdErrorLogRequestHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<object> Handle(GetCarByIdErrorLogRequest request, CancellationToken cancellationToken)
        {
            await _mediator.Publish(new GetCarByIdErrorLogNotification
            {
                ErrorMessage = request.ErrorMessage
            }, cancellationToken);

            return "ok";
        }
    }
}
