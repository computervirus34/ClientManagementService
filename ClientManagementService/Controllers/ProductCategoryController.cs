using ClientManagementService.Models;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly ILogger<ProductCategoryController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public ProductCategoryController(
            ILogger<ProductCategoryController> logger,
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
            var categories = await _unitOfWork.ProductCategories.All();
            _logger.LogInformation($"Total client:{categories.Count()}");
            return Ok(categories);
        }

        // GET api/client/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(int id)
        {
            var categories = await _unitOfWork.ProductCategories.GetByID(id);
            _logger.LogInformation($"Branch Info:{JsonConvert.SerializeObject(categories)}");
            if (categories == null)
                return NotFound();

            return Ok(categories);
        }

        // post api/<BranchController>
        [HttpPost]
        public async Task<ActionResult<ProductCategory>> Post(ProductCategory category)
        {
            _logger.LogInformation($"Category Info:{JsonConvert.SerializeObject(category)}");
            if (ModelState.IsValid)
            {
                try
                {
                    await _unitOfWork.ProductCategories.Add(category);
                    await _unitOfWork.CompleteAsync();
                    var categoryDet = await _unitOfWork.ProductCategories.GetByID(category.Id);
                    _logger.LogInformation($"category Info:{JsonConvert.SerializeObject(categoryDet)}");

                    return await Task.FromResult(categoryDet);
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
        public async Task<ActionResult<ProductCategory>> Put(int id, ProductCategory category)
        {
            _logger.LogInformation($"category Update Info:{JsonConvert.SerializeObject(category)}");
            if (id != category.Id)
            {
                return BadRequest();
            }
            var categoryExists = await _unitOfWork.ProductCategories.GetByID(id);
            if (categoryExists == null)
                return NotFound();
            try
            {
                await _unitOfWork.ProductCategories.Update(category);
                await _unitOfWork.CompleteAsync();
                var categoryDet = await _unitOfWork.ProductCategories.GetByID(category.Id);
                _logger.LogInformation($"{id}:{category.Name} updated successfully.");
                return await Task.FromResult(categoryDet);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new JsonResult(ex.Message) { StatusCode = 500 };
            }
        }

        // DELETE api/client/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductCategory>> Delete(int id)
        {
            try
            {
                var category = await _unitOfWork.ProductCategories.GetByID(id);
                if (category == null)
                    return NotFound();
                await _unitOfWork.ProductCategories.Delete(id);
                await _unitOfWork.CompleteAsync();
                _logger.LogInformation($"{id}:{category.Name} deleted successfully.");

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
