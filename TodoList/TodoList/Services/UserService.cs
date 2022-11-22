using TodoList.Models;
using TodoList.DTOs;
using TodoList.Extensions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TodoList.Utils;

namespace TodoList.Services
{
    public class UserService : IUsers
    {
        private readonly MyDbContext _context;
        private readonly ILogger<UserService> _logger;

        public UserService(MyDbContext context, ILogger<UserService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<Register> SignUp(Register user)
        {
            var query = await _context.users.SingleOrDefaultAsync(u => u.UserName == user.UserName);
            if (query == null)
            {
                Users useradd = new Users();
                useradd.UpdateUser(user);
                _context.Add(useradd);
                await _context.SaveChangesAsync();
                return user;
            }
            _logger.LogInformation("Ten tai khoan da ton tai");
            return null;
        }
        /*public async Task<Register> Login(Register user)
        {
            var query = await _context.users.SingleOrDefaultAsync(u => u.UserName == user.UserName && u.Password == EncodePassword.ConvertToEncrypt(user.Password));
            if(query == null)
            {
                return null;
            }
            return user;

        }*/
    }
}
