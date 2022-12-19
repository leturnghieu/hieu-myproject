using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TodoList.DTOs;
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
        [HttpPost("add")]
        public async Task<ActionResult<ToDo>> CreateTask(ToDoRequest toDoRequest)
        {
            var userId = Guid.Parse(HttpContext.User.Claims.Where(t => t.Type == ClaimTypes.NameIdentifier).Select(v => v.Value).FirstOrDefault());
            return Ok(await _toDoService.AddTask(userId, toDoRequest));
        }
        [HttpGet("getall")]
        public async Task<ActionResult<List<ToDo>>> GetAll()
        {
            var userId = Guid.Parse(HttpContext.User.Claims.Where(t => t.Type == ClaimTypes.NameIdentifier).Select(v => v.Value).FirstOrDefault());
            return Ok(await _toDoService.GetTask(userId));
        }
        [HttpGet("getbyid/{taskId}")]
        public async Task<ActionResult<ToDo>> GetTaskById(Guid taskId)
        {
            var userId = Guid.Parse(HttpContext.User.Claims.Where(t => t.Type == ClaimTypes.NameIdentifier).Select(v => v.Value).FirstOrDefault());
            return Ok(await _toDoService.GetTaskById(userId, taskId));
        }
        [HttpPut("update")]
        public async Task<ActionResult<ToDo>> UpdateTask(Guid taskId, ToDoRequest toDoRequest)
        {
            var userId = Guid.Parse(HttpContext.User.Claims.Where(t => t.Type == ClaimTypes.NameIdentifier).Select(v => v.Value).FirstOrDefault());
            return Ok(await _toDoService.UpdateTask(userId, taskId, toDoRequest));
        }
        [HttpDelete("delete")]
        public async Task<ActionResult<List<ToDo>>> DeleteTask(Guid taskId)
        {
            var userId = Guid.Parse(HttpContext.User.Claims.Where(t => t.Type == ClaimTypes.NameIdentifier).Select(v => v.Value).FirstOrDefault());
            return Ok(await _toDoService.DeleteTask(userId, taskId));
        }
    }
}
