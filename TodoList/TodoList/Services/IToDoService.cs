using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.DTOs;

namespace TodoList.Services
{
    public interface IToDoService
    {
        Task<TaskRespond> CreateTask(Guid userId, ToDoRequest toDoRequest);
        Task<List<TaskRespond>> GetTasks(Guid userId);
        Task<TaskRespond> GetTaskById(Guid userId, Guid taskId);
        Task<TaskRespond> UpdateTask(Guid userId, Guid taskId, ToDoRequest toDoRequest);
        Task<List<TaskRespond>> DeleteTask(Guid userId, Guid taskId);
        Task<List<TaskRespond>> GetTaskByDateAndStatus(Guid userId, DateTime date, bool status);
        Task<List<TaskRespond>> CompleteTasks(Guid userId, List<Guid> listTaskId);
    }
}
