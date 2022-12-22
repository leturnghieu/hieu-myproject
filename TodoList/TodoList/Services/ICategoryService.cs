using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.DTOs;
using TodoList.Models;

namespace TodoList.Services
{
    public interface ICategoryService
    {
        Task<List<CategoryRespond>> GetAll();
    }
}
