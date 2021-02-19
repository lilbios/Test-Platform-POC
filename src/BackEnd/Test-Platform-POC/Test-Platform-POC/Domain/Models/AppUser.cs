using Microsoft.AspNetCore.Identity;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace Test_Platform_POC.Domain.Models
{
    public class AppUser : IdentityUser
    {
        public AppUser()
        {
            Tests = new List<Test>();
            Results = new List<Result>();
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public Guid _Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime LastVisit { get; set; }
        public bool Busy { get; set; }

        public DateTime RemindTime { get; set; }

        [BsonRepresentation(BsonType.Array)]
        public ICollection<Test> Tests { get; private set; }

        [BsonRepresentation(BsonType.Array)]
        public ICollection<Result> Results { get; set; }
    }
}
