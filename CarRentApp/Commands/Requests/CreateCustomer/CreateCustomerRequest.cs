using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Commands.Requests.CreateCustomer
{
    public class CreateCustomerRequest : IRequest<string>
    {
        public string CustomerId { get; set; } = null!;
        public string Fullname { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
