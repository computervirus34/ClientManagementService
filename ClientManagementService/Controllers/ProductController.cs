using ClientManagementService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ClientManagementService.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(
            ILogger<ProductController> logger,
            IUnitOfWork unitOfWork
            )
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _unitOfWork.Products.All();
            _logger.LogInformation($"Total Product:{products.Count()}");
            return Ok(products);
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(int id)
        {
            var product = await _unitOfWork.Products.GetByID(id);

            if (product == null)
                return NotFound();
            _logger.LogInformation($"Order Info:{product}");
            return Ok(product);
        }

        [HttpGet("category/{id}")]
        public async Task<IActionResult> GetCategoryItem(int id)
        {
            var products = await _unitOfWork.Products.GetByCategory(id);

            if (products == null)
                return NotFound();
            _logger.LogInformation($"Order Info:{JsonConvert.SerializeObject(products.Count())}");
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product product)
        {
            try 
            {
                _logger.LogInformation($"Product Info:{JsonConvert.SerializeObject(product)}");
                if (product==null || product.ProductPrices == null)
                {
                    return BadRequest();
                }
                var productPrices = product.ProductPrices;
                await _unitOfWork.Products.Add(product);
                foreach(var item in productPrices)
                {
                    //item.ProductId = product.Id;
                    await _unitOfWork.ProductPrices.Add(item);
                }

                foreach (var item in product.CourseSchedules)
                {
                    //item.ProductId = product.Id;
                    await _unitOfWork.CourseSchedules.Add(item);
                }

                await _unitOfWork.CompleteAsync();
                await Task.FromResult(product);
                _logger.LogInformation($"{product.Id}-{product.Name} added successfully.");
                return Ok(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new JsonResult(ex.Message) { StatusCode = 500 };
            }
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> Put(int id, [FromBody] Product product)
        {
            _logger.LogInformation($"Product Update Info:{JsonConvert.SerializeObject(product)}");
            if (id != product.Id)
            {
                return BadRequest();
            }
            var productExists = await _unitOfWork.Products.GetByID(id);
            if (productExists == null)
                return NotFound();
            try
            {
                foreach(var item in product.ProductPrices)
                {
                    //var itemExists = _unitOfWork.ProductPrices.GetByID()
                    if (item.Id == 0)
                    {
                        await _unitOfWork.ProductPrices.Add(item);
                    }
                    else
                    {
                        await _unitOfWork.ProductPrices.Update(item);
                    }
                }
                foreach (var item in product.CourseSchedules)
                {
                    //var itemExists = _unitOfWork.ProductPrices.GetByID()
                    if (item.Id == 0)
                    {
                        await _unitOfWork.CourseSchedules.Add(item);
                    }
                    else
                    {
                        await _unitOfWork.CourseSchedules.Update(item);
                    }
                }

                await _unitOfWork.Products.Update(product);
                await _unitOfWork.CompleteAsync();
                _logger.LogInformation($"{product.Id}-{product.Name} added successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new JsonResult(ex.Message) { StatusCode = 500 };
            }
            product = await _unitOfWork.Products.GetByID(product.Id);
            return await Task.FromResult(product);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> Delete(int id)
        {
            try
            {
                var product = await _unitOfWork.Products.GetByID(id);
                if (product == null)
                    return NotFound();
                foreach (var item in product.ProductPrices)
                {
                    await _unitOfWork.ProductPrices.Delete(item.Id);
                }

                foreach (var item in product.CourseSchedules)
                {
                    await _unitOfWork.CourseSchedules.Delete(item.Id);
                }

                await _unitOfWork.Products.Delete(product.Id);
                await _unitOfWork.CompleteAsync();
                _logger.LogInformation($"{id}:{product.Name} deleted successfully.");
                return await Task.FromResult(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new JsonResult(ex.Message) { StatusCode = 500 };
            }
        }

        //[Route("api/[controller]/ProductPrice/{prodcutId}/{quantity}/{clientId}")]
        [HttpGet("{id}/{quantity}/{clientId}")]
        public async Task<ActionResult<ProductPriceCalculationModel>> GetProductPrice(int id, 
            int quantity, int clientId)
        {
            try
            {
                var productPrice = await _unitOfWork.Products.GetProductPrice(id, quantity, clientId);
                if (productPrice == null)
                    return NotFound();
                
                return await Task.FromResult(productPrice);

            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message) { StatusCode = 500 };
            }
        }
    }
}
