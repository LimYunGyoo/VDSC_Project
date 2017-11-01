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
        [BsonElement("node")]
        public string Node { get; set; }
    }
}
