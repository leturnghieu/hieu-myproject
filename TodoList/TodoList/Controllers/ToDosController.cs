using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.DTOs;
using TodoList.Extentions;
using TodoList.Models;
using TodoList.Services;

namespace TodoList.Controllers
{
    [Route("api/todos")]
    [ApiController]
    [Authorize]
    public class ToDosController : ControllerBase
    {
        private readonly IToDoService _toDoService;

        public ToDosController(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }
        [HttpPost]
        public async Task<ActionResult<ToDo>> CreateTask(ToDoRequest toDoRequest)
        {
            var userId = Guid.Parse(HttpContext.User.GetUserId());
            ToDo Task = await _toDoService.CreateTask(userId, toDoRequest);
            return Ok(new Respond()
            {
                Success = true,
                Message = "Tạo task thành công!",
                Data = Task
            });
        }
        [HttpGet("tasks")]
        public async Task<ActionResult<List<ToDo>>> GetAll()
        {
            var userId = Guid.Parse(HttpContext.User.GetUserId());
            List<ToDo> ListTask = await _toDoService.GetTasks(userId);
            return Ok(new Respond()
            {
                Success = true,
                Message = "Lấy danh sách task thành công!",
                Data = ListTask
            });
        }
        [HttpGet("tasks/{taskId}")]
        public async Task<ActionResult<ToDo>> GetTaskById(Guid taskId)
        {
            var userId = Guid.Parse(HttpContext.User.GetUserId());
            ToDo Task = await _toDoService.GetTaskById(userId, taskId);
            return Ok(new Respond()
            {
                Success = true,
                Message = "Lấy task theo ID thành công!",
                Data = Task
            });
        }
        [HttpPut]
        public async Task<ActionResult<ToDo>> UpdateTask(Guid taskId, ToDoRequest toDoRequest)
        {
            var userId = Guid.Parse(HttpContext.User.GetUserId());
            ToDo Task = await _toDoService.UpdateTask(userId, taskId, toDoRequest);
            if(Task == null)
            {
                return NotFound();
            }
            return Ok(new Respond()
            {
                Success = true,
                Message = "Sửa task theo ID thành công!",
                Data = Task
            });
        }
        [HttpDelete]
        public async Task<ActionResult<List<ToDo>>> DeleteTask(Guid taskId)
        {
            var userId = Guid.Parse(HttpContext.User.GetUserId());
            List<ToDo> ListTask = await _toDoService.DeleteTask(userId, taskId);
            if (ListTask == null)
            {
                return NotFound();
            }
            return Ok(new Respond()
            {
                Success = true,
                Message = "Xóa task theo ID thành công!",
                Data = ListTask
            });
        }
    }
}
