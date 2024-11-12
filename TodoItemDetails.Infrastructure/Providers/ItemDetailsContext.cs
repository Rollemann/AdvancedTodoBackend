using Microsoft.EntityFrameworkCore;
using TodoItemDetails.Domain.Entities;
using MongoDB.EntityFrameworkCore.Extensions;

namespace TodoItemDetails.Infrastructure.Providers;

public class ItemDetailsContext : DbContext
{
    public DbSet<ItemDetails> ItemDetails { get; set; }


    public ItemDetailsContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ItemDetails>().ToCollection("ItemDetails");
    }
}
