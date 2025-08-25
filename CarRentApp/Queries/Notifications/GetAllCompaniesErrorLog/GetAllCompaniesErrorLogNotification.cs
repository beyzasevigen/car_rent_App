using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Queries.Notifications.GetAllCompaniesErrorLog
{
    public class GetAllCompaniesErrorLogNotification : INotification
    {
        public string ErrorMessage { get; set; } = null!;
    }
}
