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
            try
            {
                var staffs = await _unitOfWork.BranchStaffs.All();
                _logger.LogInformation($"Total branch:{staffs.Count()}");
                return Ok(staffs);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        // GET api/<BranchController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(int id)
        {
            var staffs = await _unitOfWork.BranchStaffs.GetByID(id);
            
            if (staffs == null)
                return NotFound();
            _logger.LogInformation($"Branch Info:{JsonConvert.SerializeObject(staffs)}");
            return Ok(staffs);
        }

        // post api/<BranchController>
        [HttpPost]
        public async Task<ActionResult<BranchStaff>> Post([FromBody] BranchStaff branchStaff)
        {
            _logger.LogInformation($"Branch Info:{JsonConvert.SerializeObject(branchStaff)}");
            if (ModelState.IsValid)
            {
                try
                {
                    branchStaff.UserId = branchStaff.Email;
                    branchStaff.Password = _unitOfWork.BranchStaffs.GetHash(branchStaff.UserId, branchStaff.Password);

                    await _unitOfWork.BranchStaffs.Add(branchStaff);
                    await _unitOfWork.CompleteAsync();

                    _logger.LogInformation($"{branchStaff.FirstName} added successfully.");

                    var staffDet = await _unitOfWork.BranchStaffs.GetByID(branchStaff.Id);
                    await Task.FromResult(staffDet);

                    return Ok(staffDet);
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
        public async Task<ActionResult<BranchStaff>> Put(int id, BranchStaff branchStaff)
        {
            _logger.LogInformation($"Staff Update Info:{JsonConvert.SerializeObject(branchStaff)}");

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
                var staffDet = await _unitOfWork.BranchStaffs.GetByID(branchStaff.Id);
                _logger.LogInformation($"{id}:{staffDet.FirstName} updated successfully.");

                return await Task.FromResult(staffDet);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new JsonResult(ex.Message) { StatusCode = 500 };
            }
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
                _logger.LogInformation($"{id}:{branchStaff.FirstName} deleted successfully.");
                return await Task.FromResult(branchStaff);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new JsonResult(ex.Message) { StatusCode = 500 };
            }
        }

        [HttpPost]
        [Route("ChangePassword")]
        public async Task<ActionResult<BranchStaff>> ChangePassword([FromBody] PasswordChangeModel passwordChange)
        {
            _logger.LogInformation($"Branch Info:{JsonConvert.SerializeObject(passwordChange)}");
            if(passwordChange.NewPassword!=passwordChange.ConfirmPassword)
                return new JsonResult("New password and confirm password are not same!") { StatusCode = 500 };
            if (ModelState.IsValid)
            {
                try
                {
                    bool isSuccess = await _unitOfWork.BranchStaffs.ChangePassword(passwordChange);
                    await _unitOfWork.CompleteAsync();
                    
                    if(!isSuccess)
                        return NotFound(new { status = "Error", message = "User Id or password is not valid!" });
                    
                    _logger.LogInformation($"{passwordChange.UserId} password changed successfully.");

                    return Ok(new { status="Success", message="Password changed successfully."});
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                    return new JsonResult(ex.Message) { StatusCode = 500 };
                }
            }
            return BadRequest();
        }
    }
}
