using TodoList.Models;
using TodoList.DTOs;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using AutoMapper;
using TodoList.Model;
using System.Collections.Generic;

namespace TodoList.Services
{
    public class UserService : IUserService
    {
        private readonly MyDbContext _context;
        private readonly ILogger<UserService> _logger;
        private readonly IMapper _mapper;

        public UserService(MyDbContext context, ILogger<UserService> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
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
        public async Task<bool> Login(Login user)
        {
            var query = await _context.users.FirstOrDefaultAsync(u => u.UserName == user.UserName);
            if(query != null)
            {
                try
                {
                    bool isValidPassword = BCrypt.Net.BCrypt.Verify(user.Password, query.Password);
                    if (isValidPassword == true)
                    {
                        return true;
                    }
                }
                catch (System.Exception)
                {

                    return false;
                }
            }
            return false;
        }
    }
}
