using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.DTOs;
using TodoList.Services;

namespace TodoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<ActionResult<Respond<List<CategoryRespond>>>> GetAll()
        {
            var item = await _categoryService.GetAll();
            return Ok(new Respond<List<CategoryRespond>>
            {
                Success = true,
                Message = "Lấy dữ liệu Category thành công!",
                Data = item
            });
        }
    }
}
