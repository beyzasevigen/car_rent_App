using CarRentApp.Commands.Requests.RentCar;
using CarRentApp.Commands.Requests.ReturnCar;
using CarRentApp.Models;
using MediatR;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Handlers.CommandHandlers.Requests.ReturnCar
{
    public class ReturnCarRequestHandler : IRequestHandler<ReturnCarRequest, string>
    {
        private readonly IMongoCollection<Car> _carCollection;
        private readonly IMongoCollection<Contract> _contractCollection;
        public ReturnCarRequestHandler(IMongoDatabase db) 
        {
            _carCollection = db.GetCollection<Car>("cars");
            _contractCollection = db.GetCollection<Contract>("contracts");
        }

        public async Task<string> Handle(ReturnCarRequest request, CancellationToken cancellationToken)
        {
            var car = await _carCollection.Find(c => c.Id == request.CarId).FirstOrDefaultAsync(cancellationToken);
            if (car == null) 
                throw new Exception("car not found");
            if (car.IsAvailable)
                throw new Exception("car never rented or already returned");

            var contract = await _contractCollection.Find(c => c.CarId == request.CarId).SortByDescending(c => c.RentDate).FirstOrDefaultAsync(cancellationToken);
            //if (contract == null)
            //    throw new Exception("contract not found");
            if (request.ActualReturnDate > contract.ReturnDate)
            {
                var plusDays = (request.ActualReturnDate - contract.ReturnDate).Days;
                var penalty = plusDays * 500;
                contract.TotalPrice += penalty;
            }

            var updateCar = Builders<Car>.Update.Set(c => c.IsAvailable, true);
            await _carCollection.UpdateOneAsync(c => c.Id == request.CarId, updateCar, cancellationToken: cancellationToken);

            var updateContract = Builders<Contract>.Update
                .Set(c => c.TotalPrice, contract.TotalPrice)
                .Set(c => c.ReturnDate, request.ActualReturnDate);
            await _contractCollection.UpdateOneAsync(c => c.Id == contract.Id, updateContract, cancellationToken: cancellationToken);

            return request.CarId;
            
        }
    }
}
