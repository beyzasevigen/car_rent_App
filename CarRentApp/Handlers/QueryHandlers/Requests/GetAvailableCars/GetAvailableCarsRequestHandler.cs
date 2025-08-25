using CarRentApp.Models;
using CarRentApp.Queries.Requests.GetAvailableCars;
using MediatR;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Handlers.QueryHandlers.Requests.GetAvailableCars
{
    public class GetAvailableCarsRequestHandler : IRequestHandler<GetAvailableCarsRequest, List<Car>>
    {
        private readonly IMongoCollection<Car> _carCollection;
        public GetAvailableCarsRequestHandler(IMongoDatabase db)
        {
            _carCollection = db.GetCollection<Car>("cars");
        }
        public async Task<List<Car>> Handle(GetAvailableCarsRequest request, CancellationToken cancellationToken)
        {
            var filterBuilder = Builders<Car>.Filter;
            var filter = filterBuilder.Eq(c => c.IsAvailable, request.IsAvailable);

        // Eğer brand filtrelemek isteniyorsa
        //if (!string.IsNullOrEmpty(request.Brand))
        //{
        //    filter &= filterBuilder.Eq(c => c.Brand, request.Brand);
        //}

        var availableCars = await _carCollection.Find(filter).ToListAsync(cancellationToken);
        return availableCars;
        }
    }
}
