using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Test_Platform_POC.Data.Models
{
    public class Test
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Duration { get; set; }
        public bool ShowCorrectAnswer { get; set; }
        public bool Switchable { get; set; }
        public int PassingPercent { get; set; }
    }
}
