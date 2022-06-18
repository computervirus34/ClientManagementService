using ClientManagementService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ClientManagementService.Controllers
{
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
        public async Task<IActionResult> Get()
        {
            var products = await _unitOfWork.Products.All();

            return Ok(products);
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(int id)
        {
            var product = await _unitOfWork.Products.GetByID(id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }
        // GET api/<ProductController>/5
        //[HttpGet("{category}/{currencyId}")]
        //public async Task<IActionResult> GetItemByCategory(int category, int currencyId)
        //{
        //    var product = await _unitOfWork.Products.GetByCategory(category, currencyId);

        //    if (product == null)
        //        return NotFound();

        //    return Ok(product);
        //}
        // POST api/<ProductController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product product)
        {
            try { 
            if(product==null || product.ProductPrices == null)
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
            await _unitOfWork.CompleteAsync();
            await Task.FromResult(product);
            return Ok(product);
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message) { StatusCode = 500 };
            }
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> Put(int id, [FromBody] Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }
            var productExists = _unitOfWork.Products.GetByID(id);
            if (productExists == null)
                return NotFound();
            try
            {
                foreach(var item in product.ProductPrices)
                {
                    await _unitOfWork.ProductPrices.Update(item);
                }    
                await _unitOfWork.Products.Update(product);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message) { StatusCode = 500 };
            }
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
                await _unitOfWork.Products.Delete(product.Id);
                await _unitOfWork.CompleteAsync();
                return await Task.FromResult(product);

            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message) { StatusCode = 500 };
            }
        }
    }
}
