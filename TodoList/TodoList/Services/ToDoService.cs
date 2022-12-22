using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.DTOs;
using TodoList.Models;

namespace TodoList.Services
{
    public class ToDoService : IToDoService
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;

        public ToDoService(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<TaskRespond>> CompleteTasks(Guid userId, List<Guid> taskIds)
        {
            using (IDbContextTransaction transaction = _context.Database.BeginTransaction())
            {
                var tasks = await _context.ToDos.Where(t => taskIds.Contains(t.TaskId) && t.UserId == userId).ToListAsync();
                foreach (var task in tasks)
                {
                    task.Status = true;
                }
                _context.UpdateRange(tasks);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            List<ToDo> toDos = await _context.ToDos.Where(t => t.UserId == userId).ToListAsync();
            List<TaskRespond> responds = _mapper.Map<List<TaskRespond>>(toDos);
            return responds;
        }

        public async Task<TaskRespond> CreateTask(Guid userId, ToDoRequest toDoRequest)
        {
            ToDo item = _mapper.Map<ToDo>(toDoRequest);
            item.UserId = userId;
            item.Status = false;
            _context.Add(item);
            await _context.SaveChangesAsync();
            TaskRespond taskRespond = _mapper.Map<TaskRespond>(item);
            return taskRespond;
        }

        public async Task<List<TaskRespond>> DeleteTask(Guid userId, Guid taskId)
        {
            var item = await _context.ToDos.FirstOrDefaultAsync(t => t.UserId == userId && t.TaskId == taskId);
            if(item != null)
            {
                _context.Remove(item);
                _context.SaveChanges();
                List<ToDo> toDos = await _context.ToDos.Where(t => t.UserId == userId).ToListAsync();
                List<TaskRespond> taskResponds = _mapper.Map<List<TaskRespond>>(toDos);
                return taskResponds;
            }
            return null;
            
        }

        public async Task<List<TaskRespond>> GetTaskByDateAndStatus(Guid userId, DateTime date, bool status)
        {
            var item = await _context.ToDos.Where(t => t.Date == date && t.Status == status && t.UserId == userId).ToListAsync();
            if(item != null)
            {
                List<TaskRespond> taskResponds = _mapper.Map<List<TaskRespond>>(item);
                return taskResponds;
            }
            return null;
        }

        public async Task<TaskRespond> GetTaskById(Guid userId, Guid taskId)
        {
            var item = await _context.ToDos.FirstOrDefaultAsync(t => t.UserId == userId && t.TaskId == taskId);
            if(item != null)
            {
                TaskRespond taskRespond = _mapper.Map<TaskRespond>(item);
                return taskRespond;
            }
            return null;
        }
        public async Task<List<TaskRespond>> GetTasks(Guid userId)
        {
            var item = await _context.ToDos.Where(t => t.UserId == userId).ToListAsync();
            if(item != null)
            {
                List<TaskRespond> listTaskRepond = _mapper.Map<List<TaskRespond>>(item); 
                return listTaskRepond;
            }
            return null;
        }

        public async Task<TaskRespond> UpdateTask(Guid userId, Guid taskId, ToDoRequest toDoRequest)
        {
            var item = _context.ToDos.FirstOrDefault(t => t.UserId == userId && t.TaskId == taskId);
            if(item != null)
            {
                item.CategoryId = toDoRequest.CategoryId;
                item.Title = toDoRequest.Title;
                item.Detail = toDoRequest.Detail;
                item.Date = toDoRequest.Date;
                _context.Update(item);
                await _context.SaveChangesAsync();
                TaskRespond taskRespond = _mapper.Map<TaskRespond>(item);
                return taskRespond;
            }
            return null;
        }

    }
}
