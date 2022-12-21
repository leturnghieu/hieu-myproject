﻿using System.Collections.Generic;
using System.Reflection.Metadata;
using TodoList.Models;

namespace TodoList.DTOs
{
    public class Respond
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
