using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Commands.Requests.ReturnCarErrorLog
{
    public class ReturnCarErrorLogRequest(string errorMessage) : IRequest<object>
    {
        public string ErrorMessage => errorMessage;
    }
}
