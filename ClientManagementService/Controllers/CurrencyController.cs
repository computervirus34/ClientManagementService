using ClientManagementService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClientManagementService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly ILogger<CurrencyController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public CurrencyController(
            ILogger<CurrencyController> logger,
            IUnitOfWork unitOfWork
            )
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        // GET api/<CurrencyController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var currencies = await _unitOfWork.Currencies.All();

            return Ok(currencies);
        }

        // GET api/<CurrencyController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(int id)
        {
            var currencies = await _unitOfWork.Currencies.GetByID(id);

            if (currencies == null)
                return NotFound();

            return Ok(currencies);
        }

        // post api/<CurrencyController>
        [HttpPost]
        public async Task<ActionResult<Currency>> Post(Currency currency)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _unitOfWork.Currencies.Add(currency);
                    await _unitOfWork.CompleteAsync();

                    return await Task.FromResult(currency);
                }
                catch (Exception ex)
                {
                    return new JsonResult(ex.Message) { StatusCode = 500 };
                }
            }

            return BadRequest();
        }

        // PUT api/Currency/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Currency>> Put(int id, Currency currency)
        {

            if (id != currency.Id)
            {
                return BadRequest();
            }
            var currencyExists = _unitOfWork.Currencies.GetByID(id);
            if (currencyExists == null)
                return NotFound();
            try
            {
                await _unitOfWork.Currencies.Update(currency);
                await _unitOfWork.CompleteAsync();
                return await Task.FromResult(currency);
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message) { StatusCode = 500 };
            }
        }

        // DELETE api/Currency/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Currency>> Delete(int id)
        {
            try
            {
                var currency = await _unitOfWork.Currencies.GetByID(id);
                if (currency == null)
                    return NotFound();
                await _unitOfWork.Currencies.Delete(id);
                await _unitOfWork.CompleteAsync();
                return await Task.FromResult(currency);

            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message) { StatusCode = 500 };
            }
        }
    }
}
