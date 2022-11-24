using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TodoList.DTOs;
using TodoList.Services;

namespace TodoList.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUserService _userService;

        public UsersController(ILogger<UsersController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
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
        /*[HttpPost("login")]
        public async Task<ActionResult> Login(Register user)
        {
            if(await _users.Login(user) == null)
            {
                return Ok(new Respond {
                    Success = false,
                    Message = "Dang nhap that bai"
                });
            }
            return Ok(new Respond
            {
                Success = true,
                Message = "Dang nhap thanh cong"
            });
        }*/
    }
}
