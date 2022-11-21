using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TodoList.Data;
using TodoList.DTOs;
using TodoList.Service;
namespace TodoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IUsers _users;

        public RegisterController(ILogger<RegisterController> logger, IUsers users)
        {
            _logger = logger;
            _users = users;
        }

        [HttpPost("SignUp")]
        public IActionResult SignUpUser(Register user)
        {
            try
            {
                _users.Add(user);
                _logger.LogInformation("Tao tai khoan thanh cong!");
                return Ok(new Respond() {
                    Success = true,
                    Message = "Tao tai khoan thanh cong"
                });
            }
            catch (System.Exception)
            {
                _logger.LogInformation("Tao tai khoan that bai!");
                return Ok(new Respond()
                {
                    Success = false,
                    Message = "Tao tai khoan that bai"
                });
            }
        }
    }
}
