using ClientManagementService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClientManagementService.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public OrderController(
            ILogger<OrderController> logger,
            IUnitOfWork unitOfWork
            )
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var orders = await _unitOfWork.Orders.All();
            _logger.LogInformation($"Total Order:{orders.Count()}");
            return Ok(orders);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(int id)
        {
            var order = await _unitOfWork.Orders.GetByID(id);

            if (order == null)
                return NotFound();
            _logger.LogInformation($"Order Info:{JsonConvert.SerializeObject(order)}");
            return Ok(order);
        }

        [HttpGet("client/{id}")]
        public async Task<IActionResult> GetItemByClient(int id)
        {
            var order = await _unitOfWork.Orders.GetByClient(id);

            if (order == null)
                return NotFound();
            _logger.LogInformation($"Order Info:{order}");
            return Ok(order);
        }

        [HttpGet("client/{id}/{catId}")]
        public async Task<IActionResult> GetItemByClientAndCat(int id, int catId)
        {
            var order = await _unitOfWork.Orders.GetByClientAndCat(id, catId);

            if (order == null)
                return NotFound();
            _logger.LogInformation($"Order Info:{order}");
            return Ok(order);
        }
        // POST api/<OrderController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Order order)
        {
            try
            {
                _logger.LogInformation($"Offer Info:{JsonConvert.SerializeObject(order)}");
                if (order == null || order.OrderItems == null)
                {
                    return BadRequest();
                }
                var orderItems = order.OrderItems;
                await _unitOfWork.Orders.Add(order);
                foreach (var item in orderItems)
                {
                    await _unitOfWork.OrderItems.Add(item);
                }

                foreach (var item in order.ProductAdditionalInfos)
                {
                    await _unitOfWork.ProductAdditionalInfos.Add(item);
                }
                await _unitOfWork.CompleteAsync();
                await Task.FromResult(order);
                _logger.LogInformation($"{order.Id}-Client{order.ArticleNumber} added successfully.");
                return Ok(order);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new JsonResult(ex.InnerException.Message) { StatusCode = 500 };
            }
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Order>> Put(int id, [FromBody] Order order)
        {
            _logger.LogInformation($"Order Update Info:{JsonConvert.SerializeObject(order)}");
            if (id != order.Id)
            {
                return BadRequest();
            }
            var orderExists = await _unitOfWork.Orders.GetByID(id);
            if (orderExists == null)
                return NotFound();
            try
            {
                foreach (var item in order.OrderItems)
                {
                    if (item.Id == 0)
                    {
                        await _unitOfWork.OrderItems.Add(item);
                    }
                    else
                    {
                        await _unitOfWork.OrderItems.Update(item);
                    }
                }

                foreach (var item in order.ProductAdditionalInfos)
                {
                    if (item.Id == 0)
                    {
                        await _unitOfWork.ProductAdditionalInfos.Add(item);
                    }
                    else
                    {
                        await _unitOfWork.ProductAdditionalInfos.Update(item);
                    }
                }
                await _unitOfWork.Orders.Update(order);
                await _unitOfWork.CompleteAsync();
                _logger.LogInformation($"{id}:{order.ArticleNumber} updated successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new JsonResult(ex.Message) { StatusCode = 500 };
            }
            return await Task.FromResult(order);
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Order>> Delete(int id)
        {
            try
            {
                var order = await _unitOfWork.Orders.GetByID(id);
                if (order == null)
                    return NotFound();
                foreach (var item in order.OrderItems)
                {
                    await _unitOfWork.OrderItems.Delete(item.Id);
                }

                foreach (var item in order.ProductAdditionalInfos)
                {
                    await _unitOfWork.ProductAdditionalInfos.Delete(item.Id);
                }

                await _unitOfWork.Orders.Delete(order.Id);
                await _unitOfWork.CompleteAsync();
                _logger.LogInformation($"{id}:{order.ArticleNumber} deleted successfully.");
                return await Task.FromResult(order);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new JsonResult(ex.Message) { StatusCode = 500 };
            }
        }
    }
}
