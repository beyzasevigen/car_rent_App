using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Queries.Notifications.GetCarByIdErrorLog
{
    public class GetCarByIdErrorLogNotification : INotification
    {
        public string ErrorMessage { get; set; } = null!;
    }
}
