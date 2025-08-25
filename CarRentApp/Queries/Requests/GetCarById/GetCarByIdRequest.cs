using CarRentApp.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Queries.Requests.GetCarById
{
    public class GetCarByIdRequest : IRequest<Car>
    {
        public string Id { get; set; } = null!;
    }
}
