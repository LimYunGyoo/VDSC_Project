using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace YEON.VDSC.CORE.Domain
{
    public class Product
    {
        [BsonElement("_id")]
        public Object Id { get; set; }
        [BsonElement("discount")]
        public int Discount { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("price")]
        public string Price { get; set; }
        [BsonElement("detail")]
        public string Detail { get; set; }
    }
}
