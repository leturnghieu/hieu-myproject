using TodoList.Models;
using TodoList.DTOs;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TodoList.Mappings;
using AutoMapper;

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
                Users userAdd = _mapper.Map<Users>(user);
                _context.Add(userAdd);
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
