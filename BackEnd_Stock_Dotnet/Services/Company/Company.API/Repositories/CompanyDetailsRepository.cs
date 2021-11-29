using Company.API.Data;
using Company.API.Entities;
using Company.API.Repositories.Interfaces;
using EventBus.Messages.Events;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Amazon.DynamoDBv2;

namespace Company.API.Repositories
{
    public class CompanyDetailsRepository : ICompanyDetailsRepository
    {
        private readonly CompanyContext _context;
        //private readonly IPublishEndpoint _publishEndpoint;
        //public CompanyDetailsRepository(CompanyContext context, IPublishEndpoint publishEndpoint)
        //{
        //    _context = context; // ?? throw new ArgumentNullException(nameof(context));
        //    _publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
        //}
        public CompanyDetailsRepository(CompanyContext context)
        {
            _context = context; 
        }
        public async Task<IEnumerable<CompanyDetails>> GetCompanies()
        {
            return await _context.Companies.ToListAsync();
        }

        public async Task<CompanyDetails> GetCompany(int id)
        {
            return await _context.Companies.Where(p => p.Id == id)
                           .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<CompanyDetails>> GetCompanyByName(string name)
        {
            //FilterDefinition<CompanyDetails> filter = Builders<CompanyDetails>.Filter.ElemMatch(p => p.Name, name);

            return await _context
                            .Companies
                            .Where(p => p.Name == name)
                            .ToListAsync();
        }

        public async Task<IEnumerable<CompanyDetails>> GetCompanyByCode(string code)
        {
            //FilterDefinition<CompanyDetails> filter = Builders<CompanyDetails>.Filter.Eq(p => p.Code, code);

            return await _context
                            .Companies
                            .Where(p => p.Code == code)
                            .ToListAsync();
        }


        public async Task CreateCompany(CompanyDetails company)
        {
             _context.Companies.Add(company);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateCompany(CompanyDetails company)
        {
            var UpdateCompany= _context.Companies.Where(p => p.Code == company.Code).FirstOrDefault();
            if(UpdateCompany!=null)
            {
                UpdateCompany.CEO = company.CEO;
                UpdateCompany.Name = company.Name;
                UpdateCompany.StockExchange = company.StockExchange;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteCompany(string code)
        {
            var UpdateCompany = _context.Companies.Where(p => p.Code == code).FirstOrDefault();
            if (UpdateCompany != null)
            {
                _context.Remove(UpdateCompany);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;

            //FilterDefinition<CompanyDetails> filter = Builders<CompanyDetails>.Filter.Eq(p => p.Code, code);

            ////var company = await _context
            ////               .Companies
            ////               .Find(p => p.Code == code)
            ////               .FirstOrDefaultAsync();

            //DeleteResult deleteResult = await _context
            //                                    .Companies
            //                                    .DeleteOneAsync(filter);

            //if(deleteResult.DeletedCount > 0)
            //{
            //    var msg = new CompanyDeleteEvent();
            //    msg.Code = code;
            //    msg.UserId = 1234;
            //    await _publishEndpoint.Publish(msg);
            //}


            //return deleteResult.IsAcknowledged
            //    && deleteResult.DeletedCount > 0;
        }
    }
}
