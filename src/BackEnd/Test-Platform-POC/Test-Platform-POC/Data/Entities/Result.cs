using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Test_Platform_POC.Data.Entities
{
    public class Result
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public Guid Id { get; set; }
        public bool IsPassed { get; set; }
        public int CorrectQuestions { get; set; }
        public int FailedQuestions { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime TotalSpentTime { get; set; }

        public User User { get; set; }
        public Test Test { get; set; }
    }
}
