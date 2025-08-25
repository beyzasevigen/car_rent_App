using CarRentApp.Models;
using CarRentApp.Queries.Requests.GetCar;
using MediatR;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CarRentApp.Handlers.QueryHandlers.Requests.GetAllCars
{
    public class GetAllCarsRequestHandler : IRequestHandler<GetAllCarsRequest, List<Car>>
    {
        private readonly IMongoCollection<Car> _carCollection;
        public GetAllCarsRequestHandler(IMongoDatabase db)
        {
            _carCollection = db.GetCollection<Car>("cars");
        }
        public async Task<List<Car>> Handle(GetAllCarsRequest request, CancellationToken cancellationToken)
        {
            var cars = await _carCollection.Find(c => true).ToListAsync(cancellationToken);
            return cars;
            //var cars = await _carCollection.Find(c => c.IsAvailable).ToListAsync(cancellationToken);

        }
    }
}
