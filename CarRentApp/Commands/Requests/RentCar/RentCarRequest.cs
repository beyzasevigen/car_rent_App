using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Commands.Requests.RentCar
{
    public class RentCarRequest : IRequest<string>
    {
        public string ContractId { get; set; } = null!;
        public string CarId { get; set; } = null!;
        public string CustomerId { get; set; } = null!;
        public string CompanyId { get; set; } = null!;
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
