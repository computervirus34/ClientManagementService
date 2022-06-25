using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientManagementService.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClientManagementService.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ILogger<ClientController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public ClientController(
            ILogger<ClientController> logger,
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
            var clients = await _unitOfWork.Clients.All();

            return Ok(clients);
        }

        // GET api/client/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(int id)
        {
            var clients = await _unitOfWork.Clients.GetByID(id);

            if (clients == null)
                return NotFound();

            return Ok(clients);
        }

        // post api/<BranchController>
        [HttpPost]
        public async Task<ActionResult<Client>> Post(Client client)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _unitOfWork.Clients.Add(client);
                    await _unitOfWork.CompleteAsync();
                    var clientDet = await _unitOfWork.Clients.GetByID(client.Id);
                    return await Task.FromResult(clientDet);
                }
                catch (Exception ex)
                {
                    return new JsonResult(ex.Message) { StatusCode = 500 };
                }
            }
            return BadRequest();
        }

        // PUT api/employee/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Client>> Put(int id, Client client)
        {

            if (id != client.Id)
            {
                return BadRequest();
            }
            var clientExists = _unitOfWork.Clients.GetByID(id);
            if (clientExists == null)
                return NotFound();
            try
            {
                await _unitOfWork.Clients.Update(client);
                await _unitOfWork.CompleteAsync();
                var clientDet = await _unitOfWork.Clients.GetByID(client.Id);
                return await Task.FromResult(clientDet);
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message) { StatusCode = 500 };
            }
        }

        // DELETE api/client/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Client>> Delete(int id)
        {
            try
            {
                var client = await _unitOfWork.Clients.GetByID(id);
                if (client == null)
                    return NotFound();
                await _unitOfWork.Clients.Delete(id);
                await _unitOfWork.CompleteAsync();
                return await Task.FromResult(client);

            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message) { StatusCode = 500 };
            }
        }
    }
}
