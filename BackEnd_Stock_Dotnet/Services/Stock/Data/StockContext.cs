using Company.API.Data.Interfaces;
using Stock.API.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Company.API.Data
{
    public class StockContext : IStockContext
    {
        public StockContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            Stocks = database.GetCollection<StockDetails>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            StockContextSeed.SeedData(Stocks);
        } 

        public IMongoCollection<StockDetails> Stocks { get; }
    }
}
