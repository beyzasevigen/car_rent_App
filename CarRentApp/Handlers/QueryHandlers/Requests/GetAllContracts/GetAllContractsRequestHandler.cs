using CarRentApp.Models;
using CarRentApp.Queries.Requests.GetAllCompanies;
using CarRentApp.Queries.Requests.GetAllContracts;
using MediatR;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Handlers.QueryHandlers.Requests.GetAllContracts
{
    public class GetAllContractsRequestHandler : IRequestHandler<GetAllContractsRequest, List<Contract>>
    {
        private readonly IMongoCollection<Contract> _contractCollection;
        public GetAllContractsRequestHandler(IMongoDatabase db)
        {
            _contractCollection = db.GetCollection<Contract>("contracts");
        }
        public async Task<List<Contract>> Handle(GetAllContractsRequest request, CancellationToken cancellationToken)
        {
            var contracts = await _contractCollection.Find(con => true).ToListAsync(cancellationToken);
            return contracts;
        }
    }
}
