using CarRentApp.Queries.Notifications.GetCarById;
using CarRentApp.Queries.Requests.GetCarById;
using CarRentApp.Queries.Requests.GetCarByIdErrorLog;
using CarRentApp.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Services.Queries
{
    public class GetCarByIdService
    {
        private readonly IMediator _mediator;

        public GetCarByIdService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IServiceResult> GetCarByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _mediator.Send(new GetCarByIdRequest { Id = id }, cancellationToken);

                if (result == null)
                {
                    await _mediator.Send(new GetCarByIdErrorLogRequest("Searched car not found."), cancellationToken);
                    return ServiceResult.Failure("Searched car not found.");
                }

                await _mediator.Publish(new GetCarByIdNotification(), cancellationToken);
                return ServiceResult.IsSuccess(result);
            }
            catch
            {
                throw;
            }
        }
    }
}
