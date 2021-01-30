using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Test_Platform_POC.Data.Models
{
    public class Question
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public Guid Id { get; set; }

        public string QuizText { get; set; }
        public DateTime SpentTime { get; set; }
        public bool MultiplyCorrectAnswers { get; set; }
    }
}
