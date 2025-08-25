using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Models
{
    public class Contract
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string Id { get; set; } = null!;

        [BsonElement("carId")]
        public string CarId { get; set; } = null!;

        [BsonElement("customerId")]
        public string CustomerId { get; set; } = null!;

        [BsonElement("companyId")]
        public string CompanyId { get; set; } = null!;

        [BsonElement("rentDate")]
        public DateTime RentDate { get; set; }

        [BsonElement("returnDate")]
        public DateTime ReturnDate { get; set; }

        [BsonElement("totalPrice")]
        public decimal TotalPrice { get; set; }
    }
}

