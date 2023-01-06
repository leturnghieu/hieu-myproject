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
        public async Task<ActionResult<Respond<TaskRespond>>> CreateTask(ToDoRequest toDoRequest)
        {
            var userId = HttpContext.User.GetUserId();
            TaskRespond Task = await _toDoService.CreateTask(userId, toDoRequest);
            return Ok(new Respond<TaskRespond>(){
                Success = true,
                Message = "Tạo thành công!",
                Data = Task
            });
        }
        [HttpGet]
        public async Task<ActionResult<Respond<List<TaskRespond>>>> GetAll()
        {
            var userId = HttpContext.User.GetUserId();
            List<TaskRespond> listTask = await _toDoService.GetTasks(userId);
            return Ok(new Respond<List<TaskRespond>>()
            {
                Success = true,
                Message = "Lấy danh sách task thành công!",
                Data = listTask
            });
        }
        [HttpGet("{taskId}")]
        public async Task<ActionResult<Respond<TaskRespond>>> GetTaskById(Guid taskId)
        {
            var userId = HttpContext.User.GetUserId();
            TaskRespond task = await _toDoService.GetTaskById(userId, taskId);
            if(task != null)
            {
                return Ok(new Respond<TaskRespond>()
                {
                    Success = true,
                    Message = "Lấy task theo ID thành công!",
                    Data = task
                });
            }
            return NotFound();
        }
        [HttpGet("tasks")]
        public async Task<ActionResult<Respond<List<TaskRespond>>>> GetTaskByDateAndStatus(DateTime date, bool status)
        {
            var userId = HttpContext.User.GetUserId();
            List<TaskRespond> listTask = await _toDoService.GetTaskByDateAndStatus(userId, date, status);
            if(listTask.Count > 0)
            {
                return Ok(new Respond<List<TaskRespond>>
                {
                    Success = true,
                    Message = "Tìm thành công!",
                    Data = listTask
                });
            }
            return NotFound();
            
        }
        [HttpPut("{taskId}")]
        public async Task<ActionResult<Respond<TaskRespond>>> UpdateTask(Guid taskId, ToDoRequest toDoRequest)
        {
            var userId = HttpContext.User.GetUserId();
            TaskRespond task = await _toDoService.UpdateTask(userId, taskId, toDoRequest);
            if(task == null)
            {
                return NotFound();
            }
            return Ok(new Respond<TaskRespond>()
            {
                Success = true,
                Message = "Sửa task theo ID thành công!",
                Data = task
            });
        }
        [HttpDelete("{taskId}")]
        public async Task<ActionResult<Respond<List<TaskRespond>>>> DeleteTask(Guid taskId)
        {
            var userId = HttpContext.User.GetUserId();
            List<TaskRespond> deletedTask = await _toDoService.DeleteTask(userId, taskId);
            if (deletedTask == null)
            {
                return NotFound();
            }
            return Ok(new Respond<List<TaskRespond>>()
            {
                Success = true,
                Message = "Xóa task theo ID thành công!",
                Data = deletedTask
            });
        }
        [HttpPatch("complete")]
        public async Task<ActionResult<Respond<List<TaskRespond>>>> CompleteTasks(List<Guid> listTaskId)
        {
            var userId = HttpContext.User.GetUserId();
            List<TaskRespond> listTasks = await _toDoService.CompleteTasks(userId, listTaskId);
            return Ok(new Respond<List<TaskRespond>>
            {
                Success = true,
                Message = "Complete task thành công !",
                Data = listTasks
            });
        }
    }
}
