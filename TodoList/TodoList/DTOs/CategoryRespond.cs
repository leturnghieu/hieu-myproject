using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TodoList.Models;

namespace TodoList.DTOs
{
    public class CategoryRespond
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
