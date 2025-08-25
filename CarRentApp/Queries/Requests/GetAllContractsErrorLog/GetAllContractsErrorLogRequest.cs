using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Queries.Requests.GetAllContractsErrorLog
{
    public class GetAllContractsErrorLogRequest(string errorMessage) : IRequest<object>
    {
        public string ErrorMessage => errorMessage;
    }
}
