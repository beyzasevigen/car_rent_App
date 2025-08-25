using CarRentApp.Queries.Notifications.GetAllContractsErrorLog;
using CarRentApp.Queries.Requests.GetAllContractsErrorLog;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Handlers.QueryHandlers.Requests.GetAllContractsErrorLog
{
    public class GetAllContractsErrorLogRequestHandler : IRequestHandler<GetAllContractsErrorLogRequest, object>
    {
        private readonly IMediator _mediator;

        public GetAllContractsErrorLogRequestHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<object> Handle(GetAllContractsErrorLogRequest request, CancellationToken cancellationToken)
        {
            await _mediator.Publish(new GetAllContractsErrorLogNotification
            {
                ErrorMessage = request.ErrorMessage
            }, cancellationToken);

            return "ok";
        }
    }
}
