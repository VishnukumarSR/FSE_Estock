using Stock.API.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Company.API.Data
{
    public class StockContextSeed
    {
        public static void SeedData(IMongoCollection<StockDetails> productCollection)
        {
            bool existCompany = productCollection.Find(p => true).Any();
            if (!existCompany)
            {
                productCollection.InsertManyAsync(GetPreconfiguredCompanies());
            }
        }

        private static IEnumerable<StockDetails> GetPreconfiguredCompanies()
        {
            return new List<StockDetails>()
            {
                new StockDetails()
                {
                    ID = "602d2149e773f2a3990b47f6",
                    CompanyCode= "ril",
                    Price = 1000,
                    Date = new DateTime(2021,08,09),
                    IsActive= true
                },
                new StockDetails()
                {
                    ID = "602d2149e773f2a3990b47f6",
                    CompanyCode= "ril",
                    Price = 1100,
                    Date = new DateTime(2021,08,09),
                    IsActive= true
                },
                new StockDetails()
                {
                    ID = "601d2149e773f2a3990b47f9",
                    CompanyCode= "infy",
                    Price = 1000,
                    Date = new DateTime(2021,07,01),
                    IsActive= true
                },
                new StockDetails()
                {
                    ID = "612d2149e773f2a3990b47f9",
                    CompanyCode= "infy",
                    Price = 900,
                    Date = new DateTime(2021,08,01),
                    IsActive= true
                },
                new StockDetails()
                {
                    ID = "613d2149e773f2a3990b47f7",
                    CompanyCode= "cts",
                    Price = 1000,
                    Date = new DateTime(2021,08,01),
                    IsActive= true
                },
                new StockDetails()
                {
                    ID = "613d2149e773f2a3990b47f7",
                    CompanyCode= "cts",
                    Price = 900,
                    Date = new DateTime(2021,08,01),
                    IsActive= true
                },
                new StockDetails()
                {
                    ID = "613d2149e773f2a3990b47f7",
                    CompanyCode= "cts",
                    Price = 950,
                    Date = new DateTime(2021,08,01),
                    IsActive= true
                }
            };
        }
    }
}
