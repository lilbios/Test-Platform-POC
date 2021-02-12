using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Test_Platform_POC.Options;

namespace Test_Platform_POC.Data
{
    public class AppDbContext
    {
        private readonly MongoClient mongoClient;
        public IMongoDatabase MongoDatabase { get; set; }

        public AppDbContext(IOptions<DatabaseSettings> options)
        {
            mongoClient = new MongoClient(options.Value.DataBaseName);
            MongoDatabase = mongoClient.GetDatabase(options.Value.DataBaseName);
        }
    }
}
