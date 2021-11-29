using Company.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Stock.API.Models;
using Stock.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Stock.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class StockController : ControllerBase
    {
        private readonly IStockDetailsRepository _repository;
        private readonly ILogger<StockController> _logger;

        public StockController(IStockDetailsRepository repository, ILogger<StockController> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        [Route("[action]/{code}", Name = "GetStocksByCompanyCode")]
        public async Task<IActionResult> Get(string code)
        {
            var Stock = await _repository.GetStockByCode(code);
            return Ok(Stock);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _repository.GetStocks();
            return Ok(products);
        }

        [HttpPost]
        [ProducesResponseType(typeof(StockDetails), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> CreateAsync(StockDetails Stock)
        {
            await _repository.CreateStock(Stock);
            return CreatedAtRoute("GetCompanyByCode", new { code = Stock.CompanyCode }, Stock);
        }

        [HttpDelete]
        [ProducesResponseType(typeof(StockDetails), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> RemoveAsync(string code)
        {
            return Ok(await _repository.DeleteStock(code));
        }
    }
}
