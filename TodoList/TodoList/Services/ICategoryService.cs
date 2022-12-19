using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.Models;

namespace TodoList.Services
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAll();
    }
}
