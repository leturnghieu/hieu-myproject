using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TodoList.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }
        public ICollection<ToDo> Tasks { get; set; }
    }
}
