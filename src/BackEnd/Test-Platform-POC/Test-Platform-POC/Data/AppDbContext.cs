using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Reflection;
using Test_Platform_POC.Domain.Models;
using Test_Platform_POC.Options;

namespace Test_Platform_POC.Data
{
    public class AppDbContext: IdentityDbContext<AppUser>
    {
        private readonly MongoClient mongoClient;
        public IMongoDatabase MongoDatabase { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }

        public AppDbContext(IOptions<DatabaseSettings> options)
        {
            mongoClient = new MongoClient(options.Value.DataBaseName);
            MongoDatabase = mongoClient.GetDatabase(options.Value.DataBaseName);
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder builder) 
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
