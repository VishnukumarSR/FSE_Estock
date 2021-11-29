using Company.API.Data.Interfaces;
using Company.API.Repositories.Interfaces;
using EventBus.Messages.Events;
using MassTransit;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Stock.API.Models;

namespace Company.API.Repositories
{
    public class StockDetailsRepository : IStockDetailsRepository
    {
        private readonly IStockContext _context;
        private readonly IPublishEndpoint _publishEndpoint;
        public StockDetailsRepository(IStockContext context, IPublishEndpoint publishEndpoint)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
        }

        public async Task<IEnumerable<StockDetails>> GetStockByCode(string code)
        {
            FilterDefinition<StockDetails> filter = Builders<StockDetails>.Filter.Eq(p => p.CompanyCode, code);

            return await _context
                            .Stocks
                            .Find(filter)
                            .ToListAsync();
        }
        public async Task<IEnumerable<StockDetails>> GetStocks()
        {
            return await _context
                            .Stocks
                            .Find(p => true)
                            .ToListAsync();
        }

        public async Task<StockDetails> GetStock(string ID)
        {
            return await _context
                           .Stocks
                           .Find(p => p.ID == ID)
                           .FirstOrDefaultAsync();
        }

        public async Task CreateStock(StockDetails company)
        {
            await _context.Stocks.InsertOneAsync(company);
        }

        public async Task<bool> UpdateStock(StockDetails company)
        {
            var updateResult = await _context
                                        .Stocks
                                        .ReplaceOneAsync(filter: g => g.ID == company.ID, replacement: company);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> DeleteStock(string id)
        {
            FilterDefinition<StockDetails> filter = Builders<StockDetails>.Filter.Eq(p => p.ID, id);

            //var company = await _context
            //               .Companies
            //               .Find(p => p.Code == code)
            //               .FirstOrDefaultAsync();

            DeleteResult deleteResult = await _context
                                                .Stocks
                                                .DeleteOneAsync(filter);

            if(deleteResult.DeletedCount > 0)
            {
                var msg = new CompanyDeleteEvent();
                msg.Code = id;
                msg.UserId = 1234;
                await _publishEndpoint.Publish(msg);
            }
            

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }
    }
}
