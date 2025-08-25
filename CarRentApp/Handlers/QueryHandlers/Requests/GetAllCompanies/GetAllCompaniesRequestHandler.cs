using CarRentApp.Models;
using CarRentApp.Queries.Requests.GetAllCompanies;
using MediatR;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Handlers.QueryHandlers.Requests.GetAllCompanies
{
    public class GetAllCompaniesRequestHandler : IRequestHandler<GetAllCompaniesRequest, List<Company>>
    {
        private readonly IMongoCollection<Company> _companyCollection;
        public GetAllCompaniesRequestHandler(IMongoDatabase db) 
        {
            _companyCollection = db.GetCollection<Company>("companies");
        }
        public async Task<List<Company>> Handle(GetAllCompaniesRequest request, CancellationToken cancellationToken)
        {
            var companies = await _companyCollection.Find(com => true).ToListAsync(cancellationToken);
            return companies;
        }
    }
}
