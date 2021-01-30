using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace Test_Platform_POC.Domain.Models
{
    public class Question
    {
        public Question()
        {
            Answers = new List<Answer>();
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public Guid Id { get; set; }

        public string QuizText { get; set; }
        public string Hint { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime SpentTime { get; set; }
        public bool MultiplyCorrectAnswers { get; set; }
        public double Mark { get; set; }

        [BsonRepresentation(BsonType.Array)]
        public ICollection<Answer> Answers { get; set; }

    }
}
