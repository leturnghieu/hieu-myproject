
using System.Threading.Tasks;
using TodoList.DTOs;
using TodoList.Models;

namespace TodoList.Services
{
    public interface IUsers
    {
        Task<Register> SignUp(Register user);
        /*Task<Register> Login(Register user);*/
    }
}
