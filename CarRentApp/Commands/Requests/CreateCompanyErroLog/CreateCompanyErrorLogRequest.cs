using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Commands.Requests.CreateCompanyErroLog
{
    public class CreateCompanyErrorLogRequest(string errorMessage) : IRequest<object>
    {
        public string ErrorMessage => errorMessage;
    }
}
