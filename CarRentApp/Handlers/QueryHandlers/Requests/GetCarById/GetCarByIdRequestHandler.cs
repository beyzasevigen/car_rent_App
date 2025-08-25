using CarRentApp.Models;
using CarRentApp.Queries.Requests.GetCar;
using CarRentApp.Queries.Requests.GetCarById;
using MediatR;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Handlers.QueryHandlers.Requests.GetCarById
{
    public class GetCarByIdRequestHandler : IRequestHandler<GetCarByIdRequest, Car>
    {
        private readonly IMongoCollection<Car> _carCollection;
        public GetCarByIdRequestHandler(IMongoDatabase db)
        {
            _carCollection = db.GetCollection<Car>("cars");
        }
        public async Task<Car> Handle(GetCarByIdRequest request, CancellationToken cancellationToken)
        {
            var carById = await _carCollection.Find(c => c.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
            //if (carById == null)
            //    throw new Exception("Araç bulunamadı.");
            return carById;
        }
    }
}
