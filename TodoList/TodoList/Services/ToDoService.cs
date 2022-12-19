using AutoMapper;
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
        public async Task<ToDo> AddTask(Guid userId, ToDoRequest toDoRequest)
        {
            ToDo item = _mapper.Map<ToDo>(toDoRequest);
            item.UserId = userId;
            item.Date = DateTime.Now;
            item.Status = false;
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<ToDo> GetById(Guid userId, Guid taskId)
        {
            return await _context.ToDos.FirstOrDefaultAsync(t => t.UserId == userId && t.TaskId == taskId);
        }
        public async Task<List<ToDo>> GetTask(Guid userId)
        {
            var item = _context.ToDos.Where(t => t.UserId == userId).ToListAsync();
            return await item;
        }

        public async Task<ToDo> UpdateTask(Guid userId, Guid taskId, ToDoRequest toDoRequest)
        {
            var item = await _context.ToDos.Where(t => t.UserId == userId && t.TaskId == taskId).FirstOrDefaultAsync();
            if(item != null)
            {
                item = _mapper.Map<ToDo>(toDoRequest);
                item.Date = DateTime.Now;
                _context.Update(item);
            }
            return item;
        }
    }
}
