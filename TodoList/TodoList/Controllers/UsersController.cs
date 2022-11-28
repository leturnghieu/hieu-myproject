using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TodoList.DTOs;
using TodoList.Model;
using TodoList.Models;
using TodoList.Services;

namespace TodoList.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public UsersController(ILogger<UsersController> logger, IUserService userService, IConfiguration configuration)
        {
            _logger = logger;
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<ActionResult<Respond>> SignUp(Register user)
        {
            if (await _userService.SignUp(user) == null)
            {
                _logger.LogInformation("Tao tai khoan that bai!");
                return Ok(new Respond {
                    Success = false,
                    Message = "Tao tai khoan that bai"
                });
            }
            else
            {
                _logger.LogInformation("Tao tai khoan thanh cong!");
                return Ok(new Respond
                {
                    Success = true,
                    Message = "Tao tai khoan thanh cong"
                });
            }
        }
        [HttpPost("login")]
        public async Task<ActionResult> Login(Login user)
        {
            if (await _userService.Login(user))
            {
                return Ok(new Respond
                {
                    Success = true,
                    Message = "Dang nhap thanh cong",
                    Data = GenerateToken(user)
                });           
            }
            return Ok(new Respond
            {
                Success = false,
                Message = "Dang nhap that bai"
            });
        }
        private string GenerateToken(Login user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.UserName)
            };
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
