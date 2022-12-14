using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoList.Models
{
    public class ToDo
    {
        [Key]
        public Guid TaskId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Detail { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public bool Status { get; set; }
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
    }
}
