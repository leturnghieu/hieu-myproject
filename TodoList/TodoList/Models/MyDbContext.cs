using Microsoft.EntityFrameworkCore;

namespace TodoList.Models
{
    public class MyDbContext: DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> users { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<ToDo> toDos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = 1,
                    CategoryName = "Work"
                },
                new Category
                {
                    CategoryId = 2,
                    CategoryName = "Camp"
                },
                new Category
                {
                    CategoryId = 3,
                    CategoryName = "Learn C#"
                },
                new Category
                {
                    CategoryId = 4,
                    CategoryName = "PlayGame"
                }
            );
        }   
    }
}
