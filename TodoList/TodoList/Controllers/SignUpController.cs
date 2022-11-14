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
    public class SignUpController : ControllerBase
    {
        private readonly MyDbContext _context;

        public SignUpController(MyDbContext context)
        {
            _context = context;
        }

        [HttpPost("Signup")]
        public IActionResult SignUpUser(SignUp user)
        {
            var useradd = new Users();
            var usertest = _context.users.SingleOrDefault(p => p.UserName == user.UserName);
            if (usertest == null)
            {
                if (user.Password != user.ConfirmPassword)
                {
                    return Ok(new Respond
                    {
                        Success = false,
                        Message = "Mat khau khong giong nhau"
                    });
                }
                else
                {
                    useradd.UserName = user.UserName;
                    useradd.Password = user.Password;
                    _context.Add(useradd);
                    _context.SaveChanges();
                    return Ok(new Respond
                    {
                        Success = true,
                        Message = "Thanh cong",
                    });
                }

            }
            else
            {
                return Ok(new Respond
                {
                    Success = false,
                    Message = "Ten dang nhap da ton tai"
                });
            }
        }
    }
}
