//using MongoDB.Bson;
//using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace Company.API.Entities
{
    public class CompanyDetails
    {
       // [BsonId]
       // [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }
        [Key]
        public string Code { get; set; }
       // [BsonElement("Name")]
        public string Name { get; set; }
        public string CEO { get; set; }
        public string TurnOver { get; set; }
        public string Website { get; set; }
        public string StockExchange { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
