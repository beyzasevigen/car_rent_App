using CarRentApp.Commands.Requests.CreateCustomer;
using CarRentApp.Models.CarRentApp.Models;
using MediatR;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Handlers.CommandHandlers.Requests.CreateCustomer
{
    public class CreateCustomerRequestHandler : IRequestHandler<CreateCustomerRequest, string>
    {
        private readonly IMongoCollection<Customer> _customerCollection;
        public CreateCustomerRequestHandler(IMongoDatabase db) 
        {
            _customerCollection = db.GetCollection<Customer>("customers");
        }
        public async Task<string> Handle(CreateCustomerRequest request, CancellationToken cancellationToken)
        {
            var existingCustomer = await _customerCollection.Find(c => c.Id == request.CustomerId).FirstOrDefaultAsync(cancellationToken);
            if (existingCustomer != null)
                return "";

            var customer = new Customer
            {
                Id = request.CustomerId,
                FullName = request.Fullname,
                Phone = request.Phone,
                Email = request.Email,
                Username = request.Username,
                Password = request.Password
            };
            await _customerCollection.InsertOneAsync(customer, cancellationToken: cancellationToken);
            return customer.FullName;
        }
    }
}
