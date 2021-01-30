using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Test_Platform_POC.Domain.Models
{
    public class Answer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public Guid Id { get; set; }

        public string TextAnswer { get; set; }
        public bool IsCorrect { get; set; }
    }
}
