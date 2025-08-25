using CarRentApp.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Queries.Requests.GetCar
{
    public class GetAllCarsRequest :IRequest<List<Car>>
    {
    }
}
