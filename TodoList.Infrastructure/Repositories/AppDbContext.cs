using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TodoList.Domain;

namespace TodoList.Infrastructure.Repositories
{
    internal class AppDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public AppDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(Configuration.GetConnectionString("test"));
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
