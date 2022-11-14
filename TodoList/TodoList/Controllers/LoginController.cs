using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Data;
using TodoList.Model;

namespace TodoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly MyDbContext _context;

        public LoginController(MyDbContext context)
        {
            _context = context;
        }
        [HttpPost("Login")]
        public IActionResult Validate(Login lg)
        {
            var user = _context.users.SingleOrDefault(p => p.UserName == lg.UserName && lg.Password == p.Password);
            if (user == null)
            {
                return Ok(new Respond
                {
                    Success = false,
                    Message = "Tai khoan hoac mat khau khong chinh xac!"
                }
                );
            }
            return Ok(new Respond
            {
                Success = true,
                Message = "Dang nhap thanh cong!",
            }
            );
        }
    }
}
