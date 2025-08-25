using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;
#nullable enable


namespace CarRentApp.Models
{
    public class Car
    {
        [BsonElement("id")]
        public string Id { get; set; } = null!;

        [BsonElement("brand")]
        public string Brand { get; set; } = null!;

        [BsonElement("model")]
        public string Model { get; set; } = null!;

        [BsonElement("gearType")]
        public string GearType { get; set; } = null!;

        [BsonElement("fuelType")]
        public string FuelType { get; set; } = null!;

        [BsonElement("isAvailable")]
        public bool IsAvailable { get; set; }

        [BsonElement("companyId")]
        public string CompanyId { get; set; } = null!;

        public override string ToString()
        {
            return $"Marka: {Brand}, Model: {Model}, Vites: {GearType}, Yakıt: {FuelType}, Durum: {(IsAvailable ? "Müsait" : "Dolu")}, Şirket ID: {CompanyId}";
        }
    }
}

