using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Commands.Notifications.RentCarErrorLog
{
    public class RentCarErrorLogNotification : INotification
    {
        public string ErrorMessage { get; set; }
    }
}
