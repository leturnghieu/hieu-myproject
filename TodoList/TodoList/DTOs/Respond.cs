﻿namespace TodoList.DTOs
{
    public class Respond<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
