using Stock.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Company.API.Repositories.Interfaces
{
    public interface IStockDetailsRepository
    {
        Task<IEnumerable<StockDetails>> GetStocks();
        Task<StockDetails> GetStock(string id);
        Task CreateStock(StockDetails product);
        Task<bool> UpdateStock(StockDetails product);
        Task<bool> DeleteStock(string id);
        Task<IEnumerable<StockDetails>> GetStockByCode(string code);

        //Task<IEnumerable<StockDetails>> GetItemsAsync(string query);
        //Task<StockDetails> GetItemAsync(string id);
        //Task AddItemAsync(StockDetails item);
        //Task UpdateItemAsync(string id, StockDetails item);
        //Task DeleteItemAsync(string id);
    }
}
