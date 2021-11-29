using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Stock.API.Models
{
    public class StockDetails
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("id")]
        public string ID { get; set; }
        [BsonElement("price")]
        public double Price { get; set; }
        [BsonElement("date")]
        public DateTime Date { get; set; }
        [BsonElement("isActive")]
        public bool IsActive { get; set; }
        [BsonElement("code")]
        public string CompanyCode { get; set; }
    }
}
