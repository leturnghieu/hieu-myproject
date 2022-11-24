using Microsoft.EntityFrameworkCore;
using TodoList.DTOs;

namespace TodoList.Models
{
    public class MyDbContext: DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }   
    }
}
