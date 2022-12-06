using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TodoList.DTOs;

namespace TodoList.Services
{
    public interface IUserService
    {
        Task<Register> SignUp(Register user);
        Task<ActionResult<string>> Login(Login user);
    }
}
