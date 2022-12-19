using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.Models;

namespace TodoList.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly MyDbContext _context;
        public CategoryService(MyDbContext context)
        {
            _context = context;
        }
        public async Task<List<Category>> GetAll()
        {
            var listCategory = _context.Categories.ToListAsync();
            return await listCategory;
        }
    }
}
