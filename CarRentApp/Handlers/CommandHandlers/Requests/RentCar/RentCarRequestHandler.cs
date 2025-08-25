using CarRentApp.Commands.Requests.RentCar;
using CarRentApp.Models;
using MediatR;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Handlers.CommandHandlers.Requests.RentCar
{
    public class RentCarRequestHandler : IRequestHandler<RentCarRequest, string>
    {
        private readonly IMongoCollection<Contract> _contractCollection;
        private readonly IMongoCollection<Car> _carCollection;
        public RentCarRequestHandler(IMongoDatabase db) 
        {
            _contractCollection = db.GetCollection<Contract>("contracts");
            _carCollection = db.GetCollection<Car>("cars");
        }

        public async Task<string> Handle(RentCarRequest request, CancellationToken cancellationToken)
        {
            var existingContract = await _contractCollection.Find(c => c.Id == request.CustomerId).FirstOrDefaultAsync(cancellationToken);
            if (existingContract != null)
                return "";

            var car = await _carCollection.Find(c => c.Id == request.CarId).FirstOrDefaultAsync(cancellationToken);
            if (car == null)
                throw new Exception("car not found.");
            if (!car.IsAvailable)
                throw new Exception("car is not available");

            var contract = new Contract
            {
                Id = request.ContractId,
                CarId = request.CarId,
                CustomerId = request.CustomerId,
                CompanyId = request.CompanyId,
                RentDate = request.RentDate,
                ReturnDate = request.ReturnDate,
                TotalPrice = request.TotalPrice
            };

            //bool isHaveCar = IsHaveCar(carId);
            //if(isHaveCar)
            //{
            //  return 
            //}

            var isHaveContract = await _carCollection.Find(c => c.Id == request.CarId).FirstOrDefaultAsync(cancellationToken);
            if (isHaveContract == null)
                return "BU id ile araba var başka id dene";
                //throw new Exception("Contract Bulunamadı");

            await _contractCollection.InsertOneAsync(contract, cancellationToken: cancellationToken);
            var update = Builders<Car>.Update.Set(c => c.IsAvailable, false);
            await _carCollection.UpdateOneAsync(c => c.Id == request.CarId, update, cancellationToken: cancellationToken);
            return contract.Id;
        }
    }
}
