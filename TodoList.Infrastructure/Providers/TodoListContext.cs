using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TodoList.Domain.Entities;

namespace TodoList.Infrastructure.Providers;

public class TodoListContext(IConfiguration configuration) : DbContext
{
    public DbSet<TodoItem> TodoItems { get; set; }

    private readonly IConfiguration Configuration = configuration;

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseNpgsql(Configuration.GetConnectionString("TodoListDatabase"));
    }
}
