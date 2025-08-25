using CarRentApp.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Queries.Requests.GetAllContracts
{
    public class GetAllContractsRequest : IRequest<List<Contract>>
    {
    }
}
