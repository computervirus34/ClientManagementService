using ClientManagementService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientManagementService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountConfigController : ControllerBase
    {
        private readonly ILogger<DiscountConfigController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public DiscountConfigController(
            ILogger<DiscountConfigController> logger,
            IUnitOfWork unitOfWork
            )
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        // GET api/<BranchController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var discounts = await _unitOfWork.DiscountConfigs.All();
            _logger.LogInformation($"Total client:{discounts.Count()}");
            return Ok(discounts);
        }

        // GET api/client/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(int id)
        {
            var discounts = await _unitOfWork.DiscountConfigs.GetByID(id);
            _logger.LogInformation($"discounts Info:{JsonConvert.SerializeObject(discounts)}");
            if (discounts == null)
                return NotFound();

            return Ok(discounts);
        }

        [HttpGet("category/{id}")]
        public async Task<IActionResult> GetCategoryItems(int id)
        {
            var discounts = await _unitOfWork.DiscountConfigs.GetDiscountByCategory(id);
            _logger.LogInformation($"discounts Info:{JsonConvert.SerializeObject(discounts)}");
            if (discounts == null)
                return NotFound();

            return Ok(discounts);
        }

        // post api/<BranchController>
        [HttpPost]
        public async Task<ActionResult<DiscountRateConfig>> Post([FromBody] List<DiscountRateConfig> discounts)
        {
            _logger.LogInformation($"DiscountRateConfig Info:{JsonConvert.SerializeObject(discounts)}");
            if (ModelState.IsValid)
            {
                try
                {
                    foreach(var discount in discounts)
                    {
                        await _unitOfWork.DiscountConfigs.Add(discount);
                    }
                    await _unitOfWork.CompleteAsync();
                    //var discountDet = await _unitOfWork.DiscountConfigs.GetDiscountByCategory(discounts.);
                    _logger.LogInformation($"discount Info added successfully.");

                    return new JsonResult("Discount added successfully.") { StatusCode = 200 };
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                    return new JsonResult(ex.Message) { StatusCode = 500 };
                }
            }
            return BadRequest();
        }

        // PUT api/employee/5
        [HttpPut("{id}")]
        public async Task<ActionResult<DiscountRateConfig>> Put(int id, DiscountRateConfig discount)
        {
            _logger.LogInformation($"category Update Info:{JsonConvert.SerializeObject(discount)}");
            if (id != discount.Id)
            {
                return BadRequest();
            }
            var discountExists = await _unitOfWork.DiscountConfigs.GetByID(id);
            if (discountExists == null)
                return NotFound();
            try
            {
                await _unitOfWork.DiscountConfigs.Update(discount);
                await _unitOfWork.CompleteAsync();
                var discountDet = await _unitOfWork.DiscountConfigs.GetByID(discount.Id);
                _logger.LogInformation($"{id}:{discount.LicenseType} updated successfully.");
                return await Task.FromResult(discountDet);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new JsonResult(ex.Message) { StatusCode = 500 };
            }
        }

        // DELETE api/client/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DiscountRateConfig>> Delete(int id)
        {
            try
            {
                var category = await _unitOfWork.DiscountConfigs.GetByID(id);
                if (category == null)
                    return NotFound();
                await _unitOfWork.DiscountConfigs.Delete(id);
                await _unitOfWork.CompleteAsync();
                _logger.LogInformation($"{id}:{category.ProductCategoryId} deleted successfully.");

                return await Task.FromResult(category);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new JsonResult(ex.Message) { StatusCode = 500 };
            }
        }
    }
}
