﻿using Microsoft.EntityFrameworkCore;
using TodoList.DTOs;

namespace TodoList.Data
{
    public class MyDbContext: DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Users> users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
        
    }
}