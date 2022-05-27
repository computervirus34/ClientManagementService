using ClientManagementService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var users = await _unitOfWork.Branches.All();

            return Ok(users);
        }
        
        // GET api/<BranchController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(int id)
        {
            var user = await _unitOfWork.Branches.GetByID(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        // post api/<BranchController>
        [HttpPost]
        public async Task<ActionResult<Branch>> Post(Branch branch)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _unitOfWork.Branches.Add(branch);
                    await _unitOfWork.CompleteAsync();

                    return await Task.FromResult(branch);
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
        public async Task<ActionResult<Branch>> Put(int id, Branch branch)
        {
            
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
            }
            catch (Exception ex)
            {
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
                return await Task.FromResult(branch);
            
            }
            catch(Exception ex)
            {
               return new JsonResult(ex.Message) { StatusCode = 500 };
            }
        }
    }
}
