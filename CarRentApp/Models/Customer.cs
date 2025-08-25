using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Models
{
    namespace CarRentApp.Models
    {
        public class Customer
        {
            [BsonElement("id")]
            public string Id { get; set; } = null!;

            [BsonElement("fullName")]
            public string FullName { get; set; } = null!;

            [BsonElement("phone")]
            public string Phone { get; set; } = null!;

            [BsonElement("email")]
            public string Email { get; set; } = null!;
            [BsonElement("username")]
            public string Username { get; set; } = null!;
            [BsonElement("password")]
            public string Password { get; set; } = null!;
        }
    }
}
