using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TodoList.Domain.Entities;

namespace TodoList.Infrastructure.Providers;

public class TodoListContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<TodoItem> TodoItems { get; set; }

    private readonly IConfiguration _configuration;

    public TodoListContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseNpgsql(_configuration.GetConnectionString("TodoListDatabase"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(new Category()
        {
            Id = 1,
            Name = "Default",
            Color = "ffffff",
            TodoItems = []
        });
    }
}
