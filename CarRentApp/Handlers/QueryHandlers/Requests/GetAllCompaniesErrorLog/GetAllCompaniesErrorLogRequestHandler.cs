using CarRentApp.Queries.Notifications.GetAllCompaniesErrorLog;
using CarRentApp.Queries.Requests.GetAllCompaniesErrorLog;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Handlers.QueryHandlers.Requests.GetAllCompaniesErrorLog
{
    public class GetAllCompaniesErrorLogRequestHandler : IRequestHandler<GetAllCompaniesErrorLogRequest, object>
    {
        private readonly IMediator _mediator;

        public GetAllCompaniesErrorLogRequestHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<object> Handle(GetAllCompaniesErrorLogRequest request, CancellationToken cancellationToken)
        {
            await _mediator.Publish(new GetAllCompaniesErrorLogNotification
            {
                ErrorMessage = request.ErrorMessage
            }, cancellationToken);

            return "ok";
        }
    }
}
