using CarRentApp.Commands.Requests.CreateCompany;
using CarRentApp.Models;
using MediatR;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Handlers.CommandHandlers.Requests.CreateCompany
{
    public class CreateCompanyRequestHandler : IRequestHandler<CreateCompanyRequest, string>
    {
        private readonly IMongoCollection<Company> _companyCollection;
        public CreateCompanyRequestHandler(IMongoDatabase db) 
        {
            _companyCollection = db.GetCollection<Company>("companies");
        }

        public async Task<string> Handle(CreateCompanyRequest request, CancellationToken cancellationToken)
        {
            var existingCompany = await _companyCollection.Find(c => c.Id == request.CompId).FirstOrDefaultAsync(cancellationToken);
            if (existingCompany != null)
                return "";

            var company = new Company
            {
                Id = request.CompId,
                Name = request.Name,
                Address = request.Address,
                Phone = request.Phone
            };
            await _companyCollection.InsertOneAsync(company, cancellationToken: cancellationToken);
            return company.Id;
        }
    }
}
