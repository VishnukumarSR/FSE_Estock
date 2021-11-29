using Company.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
//using MongoDB.Driver;

namespace Company.API.Data
{
    public class CompanyContext : DbContext
    {
        //public CompanyContext(IConfiguration configuration)
        //{
        //    var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
        //    var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

        //    Companies = database.GetCollection<CompanyDetails>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
        //    CompanyContextSeed.SeedData(Companies);
        //} 

        //public IMongoCollection<CompanyDetails> Companies { get; }
        public CompanyContext()
        {
        }
        public CompanyContext(DbContextOptions opts) : base(opts)
        {

        }
        public DbSet<CompanyDetails> Companies { get; set; }

    }
}

