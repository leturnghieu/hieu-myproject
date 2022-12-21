using System.Collections.Generic;
using System.Reflection.Metadata;
using TodoList.Models;

namespace TodoList.DTOs
{
    public class TaskRespond<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
