using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace TodoList.DTOs
{
    public class TaskRespond
    {
        public Guid TaskId { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
        public Guid UserId { get; set; }
        public int CategoryId { get; set; }
    }
}
