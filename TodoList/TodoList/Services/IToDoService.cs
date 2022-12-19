using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.DTOs;
using TodoList.Models;

namespace TodoList.Services
{
    public interface IToDoService
    {
        Task<ToDo> AddTask(Guid userId, ToDoRequest toDoRequest);
        Task<List<ToDo>> GetTask(Guid userId);
        Task<ToDo> GetTaskById(Guid userId, Guid taskId);
        Task<ToDo> UpdateTask(Guid userId, Guid taskId, ToDoRequest toDoRequest);
        Task<List<ToDo>> DeleteTask(Guid userId, Guid taskId);
    }
}
