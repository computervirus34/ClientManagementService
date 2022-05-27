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
    public class BranchStaffController : ControllerBase
    {
        private readonly ILogger<BranchStaffController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public BranchStaffController(
            ILogger<BranchStaffController> logger,
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
            var users = await _unitOfWork.BranchStaffs.All();

            return Ok(users);
        }

        // GET api/<BranchController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(int id)
        {
            var user = await _unitOfWork.BranchStaffs.GetByID(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        // post api/<BranchController>
        [HttpPost]
        public async Task<ActionResult<BranchStaff>> Post(BranchStaff branchStaff)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _unitOfWork.BranchStaffs.Add(branchStaff);
                    await _unitOfWork.CompleteAsync();
                    var staffDet = await _unitOfWork.BranchStaffs.GetByID(branchStaff.Id);
                    return await Task.FromResult(staffDet);
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
        public async Task<ActionResult<BranchStaff>> Put(int id, BranchStaff branchStaff)
        {

            if (id != branchStaff.Id)
            {
                return BadRequest();
            }
            var branchExists = _unitOfWork.BranchStaffs.GetByID(id);
            if (branchExists == null)
                return NotFound();
            try
            {
                await _unitOfWork.BranchStaffs.Update(branchStaff);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message) { StatusCode = 500 };
            }
            return await Task.FromResult(branchStaff);
        }

        // DELETE api/employee/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BranchStaff>> Delete(int id)
        {
            try
            {
                var branchStaff = await _unitOfWork.BranchStaffs.GetByID(id);
                if (branchStaff == null)
                    return NotFound();
                await _unitOfWork.BranchStaffs.Delete(id);
                await _unitOfWork.CompleteAsync();
                return await Task.FromResult(branchStaff);

            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message) { StatusCode = 500 };
            }
        }
    }
}
