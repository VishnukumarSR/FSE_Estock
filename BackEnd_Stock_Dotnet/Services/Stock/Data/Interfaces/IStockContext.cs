using Stock.API.Models;
using MongoDB.Driver;

namespace Company.API.Data.Interfaces
{
    public interface IStockContext
    {
        IMongoCollection<StockDetails> Stocks { get; }
    }
}
