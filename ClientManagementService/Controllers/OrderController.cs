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
        public async Task<IActionResult> Get()
        {
            var orders = await _unitOfWork.Orders.All();

            return Ok(orders);
        }

        public async Task<IActionResult> GetItem(int id)
        {
            var order = await _unitOfWork.Orders.GetByID(id);

            if (order == null)
                return NotFound();

            return Ok(order);
        }
        // POST api/<OrderController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Order order)
        {
            try
            {
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
                await _unitOfWork.CompleteAsync();
                await Task.FromResult(order);
                return Ok(order);
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message) { StatusCode = 500 };
            }
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Order>> Put(int id, [FromBody] Order order)
        {
            if (id != order.Id)
            {
                return BadRequest();
            }
            var orderExists = _unitOfWork.Orders.GetByID(id);
            if (orderExists == null)
                return NotFound();
            try
            {
                foreach (var item in order.OrderItems)
                {
                    await _unitOfWork.OrderItems.Update(item);
                }
                await _unitOfWork.Orders.Update(order);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception ex)
            {
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
                await _unitOfWork.Orders.Delete(order.Id);
                await _unitOfWork.CompleteAsync();
                return await Task.FromResult(order);

            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message) { StatusCode = 500 };
            }
        }
    }
}
