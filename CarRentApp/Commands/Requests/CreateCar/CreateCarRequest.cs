using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Commands.Requests.CreateCar
{
    public class CreateCarRequest : IRequest<string>
    {
        public string CarcId { get; set; } = null!;
        public string Brand { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string GearType { get; set; } = null!;
        public string FuelType { get; set; } = null!;
        public string CompanyId { get; set; } = null!;
        public bool IsAvailable { get; set; } = false;
    }
}
