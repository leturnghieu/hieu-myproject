using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.DTOs;
using TodoList.Model;
using TodoList.Models;

namespace TodoList.Services
{
    public interface IUserService
    {
        Task<Register> SignUp(Register user);
        Task<bool> Login(Login user);
    }
}
