using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Services
{
    public class MongoDBSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string CarsCollectionName { get; set; } = null!;
        public string CompaniesCollectionName { get; set; } = null!;
        public string CustomersCollectionName { get; set; } = null!;
        public string ContractsCollectionName { get; set; } = null!;
    }
}
