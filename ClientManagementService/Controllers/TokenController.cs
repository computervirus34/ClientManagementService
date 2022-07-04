using ClientManagementService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ClientManagementService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ILogger<TokenController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public IConfiguration _configuration;
        public TokenController(
            ILogger<TokenController> logger,
            IUnitOfWork unitOfWork,
            IConfiguration config
            )
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _configuration = config;
        }
        [HttpPost]
        public async Task<IActionResult> Post(UserToken _userData)
        {
            _logger.LogInformation(JsonConvert.SerializeObject(_userData));
            try
            {
                if (_userData != null && _userData.UserId != null && _userData.Password != null)
                {
                    var user = await _unitOfWork.BranchStaffs.ValidateUser(_userData.UserId, _userData.Password);

                    if (user != null)
                    {
                        //create claims details based on the user information
                        var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", user.Email.ToString()),
                        new Claim("FirstName", user.FirstName),
                        new Claim("LastName", user.LastName),
                        new Claim("Email", user.Email)
                    };

                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                        var token = new JwtSecurityToken(
                            _configuration["Jwt:Issuer"],
                            _configuration["Jwt:Audience"],
                            claims,
                            expires: DateTime.UtcNow.AddMinutes(30),
                            signingCredentials: signIn);

                        _logger.LogInformation(JsonConvert.SerializeObject(new
                        {
                            Token = new JwtSecurityTokenHandler().WriteToken(token),
                            Expiration = token.ValidTo
                        }));

                        return Ok(new
                        {
                            Token = new JwtSecurityTokenHandler().WriteToken(token),
                            Expiration = token.ValidTo
                        });
                        //return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                    }
                    else
                    {
                        _logger.LogError("Invalid credentials");
                        return BadRequest("Invalid credentials");
                    }
                }
                else
                {
                    return BadRequest();
                }
            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex);
            }
        }
    }
}
