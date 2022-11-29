using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TodoList.DTOs;
using TodoList.Models;

namespace TodoList.Services
{
    public interface IUserService
    {
        Task<Register> SignUp(Register user);
        Task<string> Login(Login user);
    }
}
