using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        public async Task<ToDo> CreateTask(Guid userId, ToDoRequest toDoRequest)
        {
            ToDo item = _mapper.Map<ToDo>(toDoRequest);
            item.UserId = userId;
            item.Status = false;
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<List<ToDo>> DeleteTask(Guid userId, Guid taskId)
        {
            var item = await _context.ToDos.FirstOrDefaultAsync(t => t.UserId == userId && t.TaskId == taskId);
            if(item != null)
            {
                _context.Remove(item);
                _context.SaveChanges();
                return await _context.ToDos.ToListAsync();
            }
            return null;
            
        }

        public async Task<ToDo> GetTaskById(Guid userId, Guid taskId)
        {
            return await _context.ToDos.FirstOrDefaultAsync(t => t.UserId == userId && t.TaskId == taskId);
        }
        public async Task<List<ToDo>> GetTasks(Guid userId)
        {
            var item = _context.ToDos.Where(t => t.UserId == userId).ToListAsync();
            return await item;
        }

        public async Task<ToDo> UpdateTask(Guid userId, Guid taskId, ToDoRequest toDoRequest)
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
                return item;
            }
            return null;
            
        }
    }
}
