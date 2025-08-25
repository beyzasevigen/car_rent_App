using CarRentApp.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Queries.Requests.GetAvailableCars
{
    public class GetAvailableCarsRequest : IRequest<List<Car>>
    {
        public string Brand { get; set; } = null!;
        public bool IsAvailable { get; set; }
    }
}
