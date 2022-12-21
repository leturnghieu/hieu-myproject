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
    [Route("api/[controller]")]
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
        public async Task<ActionResult<TaskRespond<ToDo>>> CreateTask(ToDoRequest toDoRequest)
        {
            var userId = HttpContext.User.GetUserId();
            ToDo Task = await _toDoService.CreateTask(userId, toDoRequest);
            return Ok(new TaskRespond<ToDo>(){
                Success = true,
                Message = "Tạo thành công!",
                Data = Task
            });
        }
        [HttpGet]
        public async Task<ActionResult<TaskRespond<List<ToDo>>>> GetAll()
        {
            var userId = HttpContext.User.GetUserId();
            List<ToDo> ListTask = await _toDoService.GetTasks(userId);
            return Ok(new TaskRespond<List<ToDo>>()
            {
                Success = true,
                Message = "Lấy danh sách task thành công!",
                Data = ListTask
            });
        }
        [HttpGet("{taskId}")]
        public async Task<ActionResult<TaskRespond<ToDo>>> GetTaskById(Guid taskId)
        {
            var userId = HttpContext.User.GetUserId();
            ToDo Task = await _toDoService.GetTaskById(userId, taskId);
            if(Task != null)
            {
                return Ok(new TaskRespond<ToDo>()
                {
                    Success = true,
                    Message = "Lấy task theo ID thành công!",
                    Data = Task
                });
            }
            return NotFound();
        }
        [HttpGet("tasks")]
        public async Task<ActionResult<TaskRespond<List<ToDo>>>> GetTaskByDateAndStatus(DateTime date, bool status)
        {
            var userId = HttpContext.User.GetUserId();
            List<ToDo> ListTask = await _toDoService.GetTaskByDateAndStatus(userId, date, status);
            if(ListTask.Count > 0)
            {
                return Ok(new TaskRespond<List<ToDo>>
                {
                    Success = true,
                    Message = "Tìm thành công!",
                    Data = ListTask
                });
            }
            return NotFound();
            
        }
        [HttpPut("{taskId}")]
        public async Task<ActionResult<TaskRespond<ToDo>>> UpdateTask(Guid taskId, ToDoRequest toDoRequest)
        {
            var userId = HttpContext.User.GetUserId();
            ToDo Task = await _toDoService.UpdateTask(userId, taskId, toDoRequest);
            if(Task == null)
            {
                return NotFound();
            }
            return Ok(new TaskRespond<ToDo>()
            {
                Success = true,
                Message = "Sửa task theo ID thành công!",
                Data = Task
            });
        }
        [HttpDelete("{taskId}")]
        public async Task<ActionResult<TaskRespond<List<ToDo>>>> DeleteTask(Guid taskId)
        {
            var userId = HttpContext.User.GetUserId();
            List<ToDo> ListTask = await _toDoService.DeleteTask(userId, taskId);
            if (ListTask == null)
            {
                return NotFound();
            }
            return Ok(new TaskRespond<List<ToDo>>()
            {
                Success = true,
                Message = "Xóa task theo ID thành công!",
                Data = ListTask
            });
        }
        [HttpPatch("complete")]
        public async Task<ActionResult<TaskRespond<List<ToDo>>>> CompleteTasks(List<Guid> listTaskId)
        {
            var userId = HttpContext.User.GetUserId();
            List<ToDo> ListTasks = await _toDoService.CompleteTasks(userId, listTaskId);
            return Ok(new TaskRespond<List<ToDo>>
            {
                Success = true,
                Message = "Complete task thành công !",
                Data = ListTasks
            });
        }
    }
}
