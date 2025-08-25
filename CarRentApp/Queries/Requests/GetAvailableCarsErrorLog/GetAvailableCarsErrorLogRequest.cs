using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Queries.Requests.GetAvailableCarsErrorLog
{
    public class GetAvailableCarsErrorLogRequest(string errorMessage) : IRequest<object>
    {
        public string ErrorMessage => errorMessage;
    }
}
