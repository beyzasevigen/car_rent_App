using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Queries.Notifications.GetAvailableCarsErrorLog
{
    public class GetAvailableCarsErrorLogNotification : INotification
    {
        public string ErrorMessage { get; set; } = null!;
    }
}
