using System.ComponentModel.DataAnnotations;
using System;

namespace TodoList.DTOs
{
    public class ToDoRequest
    {
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string Title { get; set; }
        public string Detail { get; set; }
    }
}
