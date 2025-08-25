using CarRentApp.Commands.Requests.CreateCar;
using CarRentApp.Models;
using MediatR;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Handlers.CommandHandlers.Requests.CreateCar
{
    public class CreateCarRequestHandler : IRequestHandler<CreateCarRequest, string>
    {
        private readonly IMongoCollection<Car> _carCollection;
        public CreateCarRequestHandler(IMongoDatabase db) 
        {
            _carCollection = db.GetCollection<Car>("cars");
        }
        public async Task<string> Handle(CreateCarRequest request, CancellationToken cancellationToken)
        {
            var existingCar = await _carCollection.Find(c => c.Id == request.CarcId).FirstOrDefaultAsync(cancellationToken);
            if (existingCar != null)
                return "";

            var car = new Car
            {
                Id = request.CarcId,
                Brand = request.Brand,
                Model = request.Model,
                GearType = request.GearType,
                FuelType = request.FuelType,
                CompanyId = request.CompanyId,
                IsAvailable = true
            };
        await _carCollection.InsertOneAsync(car, cancellationToken : cancellationToken);
        return car.Id;
        }
    }
}
