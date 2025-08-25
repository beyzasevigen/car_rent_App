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

        public class User
        {
            public string Id { get; set; } = Guid.NewGuid().ToString();
            public string Username { get; set; } = null!;
            public string Password { get; set; } = null!;
            public UserRole Role { get; set; }
        }

        public enum UserRole
        {
            Admin,
            Customer
        }
    }
}
