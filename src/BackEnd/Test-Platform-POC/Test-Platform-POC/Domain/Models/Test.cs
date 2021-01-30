using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace Test_Platform_POC.Domain.Models
{
    public class Test
    {
        public Test()
        {
            Question = new List<Question>();
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public bool ShowCorrectAnswer { get; set; }
        public bool Switchable { get; set; }
        public int PassingPercent { get; set; }
        public int AllowedAttempts { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime Duration { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime OpenTime { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime CloseTime { get; set; }

        [BsonRepresentation(BsonType.Array)]
        public ICollection<Question> Question { get; set; }
    }
}
