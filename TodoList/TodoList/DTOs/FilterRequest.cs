using System;

namespace TodoList.DTOs
{
    public class FilterRequest
    {
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}
