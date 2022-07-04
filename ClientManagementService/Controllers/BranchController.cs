using ClientManagementService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class BranchController : ControllerBase
    {
        private readonly ILogger<BranchController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public BranchController(
            ILogger<BranchController> logger,
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
            try
            {
                var branches = await _unitOfWork.Branches.All();
                _logger.LogInformation($"Total branch:{branches.Count()}");
                return Ok(branches);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }
        
        // GET api/<BranchController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(int id)
        {
            var branch = await _unitOfWork.Branches.GetByID(id);
            
            if (branch == null)
                return NotFound();
            _logger.LogInformation($"Branch Info:{JsonConvert.SerializeObject(branch)}");
            return Ok(branch);
        }

        // post api/<BranchController>
        [HttpPost]
        public async Task<ActionResult<Branch>> Post(Branch branch)
        {
            _logger.LogInformation($"Branch Info:{JsonConvert.SerializeObject(branch)}");
            if (ModelState.IsValid)
            {
                try
                {
                    await _unitOfWork.Branches.Add(branch);
                    await _unitOfWork.CompleteAsync();
                    _logger.LogInformation($"{branch.BranchName} Branch added successfully.");
                    return await Task.FromResult(branch);
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
        public async Task<ActionResult<Branch>> Put(int id, Branch branch)
        {
            _logger.LogInformation($"Branch Update Info:{JsonConvert.SerializeObject(branch)}");
            if (id != branch.Id)
            {
                return BadRequest();
            }
            var branchExists = _unitOfWork.Branches.GetByID(id);
            if (branchExists == null)
                return NotFound();
            try
            {
                await _unitOfWork.Branches.Update(branch);
                await _unitOfWork.CompleteAsync();
                _logger.LogInformation($"{id}:{branch.BranchName} Branch updated successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new JsonResult(ex.Message) { StatusCode = 500 };
            }
            return await Task.FromResult(branch);
        }

        // DELETE api/employee/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Branch>> Delete(int id)
        {
            try
            {
                var branch = await _unitOfWork.Branches.GetByID(id);
                if (branch == null)
                    return NotFound();
                await _unitOfWork.Branches.Delete(id);
                await _unitOfWork.CompleteAsync();
                _logger.LogInformation($"{id}:{branch.BranchName} Branch deleted successfully.");
                return await Task.FromResult(branch);
            
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return new JsonResult(ex.Message) { StatusCode = 500 };
            }
        }
    }
}
