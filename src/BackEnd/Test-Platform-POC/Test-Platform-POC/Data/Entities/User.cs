using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace Test_Platform_POC.Data.Entities
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public Guid Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PassWord { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime LastVisit { get; set; }
        public bool Busy { get; set; }

        [BsonRepresentation(BsonType.Array)]
        public ICollection<Test> Tests { get; set; }

        [BsonRepresentation(BsonType.Array)]
        public ICollection<Result> Results { get; set; }
    }
}
