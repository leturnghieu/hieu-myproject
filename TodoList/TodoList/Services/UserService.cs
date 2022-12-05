using TodoList.Models;
using TodoList.DTOs;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace TodoList.Services
{

    public class UserService : IUserService
    {
        private readonly MyDbContext _context;
        private readonly ILogger<UserService> _logger;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public UserService(MyDbContext context, ILogger<UserService> logger, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
            _configuration = configuration;
        }
        public async Task<Register> SignUp(Register user)
        {
            var query = await _context.users.FirstOrDefaultAsync(u => u.UserName == user.UserName);
            if (query == null)
            {
                User userAdd = _mapper.Map<User>(user);
                _context.Add(userAdd);
                await _context.SaveChangesAsync();
                return user;
            }
            _logger.LogInformation("Ten tai khoan da ton tai");
            return null;
        }
        public async Task<ActionResult<string>> Login(Login user)
        {
            var User = await _context.users.FirstOrDefaultAsync(u => u.UserName == user.UserName);
            if(User != null)
            {
                bool isValidPassword = BCrypt.Net.BCrypt.Verify(user.Password, User.Password);
                if (isValidPassword == true)
                {

                    _logger.LogInformation("Đăng nhập thành công!");
                    return GenerateToken(User);
                }
            }
            _logger.LogInformation("Đăng nhập thất bại!");
            return null ;
        }
        public string GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
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
