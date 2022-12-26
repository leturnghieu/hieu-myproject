using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.DTOs;

namespace TodoList.Services
{
    public interface ICategoryService
    {
        Task<List<CategoryRespond>> GetAll();
    }
}
