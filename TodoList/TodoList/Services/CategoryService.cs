using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.DTOs;
using TodoList.Models;

namespace TodoList.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;

        public CategoryService(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<CategoryRespond>> GetAll()
        {
            List<CategoryRespond> categoryResponds = new List<CategoryRespond>();
            var listCategoryModel = await _context.Categories.ToListAsync();
            /*foreach(Category category in listCategoryModel)
            {
                CategoryRespond categoryRespond = _mapper.Map<CategoryRespond>(category);
                categoryResponds.Add(categoryRespond);
            }*/
            categoryResponds = _mapper.Map<List<CategoryRespond>>(listCategoryModel);
            return categoryResponds;
        }
    }
}
