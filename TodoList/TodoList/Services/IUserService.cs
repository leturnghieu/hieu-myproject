using System.Threading.Tasks;
using TodoList.DTOs;

namespace TodoList.Services
{
    public interface IUserService
    {
        Task<Register> SignUp(Register user);
        /*Task<Register> Login(Register user);*/
    }
}
