var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


// Add-Migration Init -Project TodoList.Infrastructure -StartupProject TodoList.API
// Update-Database -Project TodoList.Infrastructure


/* Zu machen:
 * 
 * CRUD für Category
 * CRUD für TODO Items
 * 
 * API für CRUD Category
 * API für CRUD TODO Items
 * 
 * Validieren oder kreieren vom Schedule
 * 
 * Frontend bauen
 * 
 */



/*  TEST FOR DB

using TodoList.Domain.Entities;
using TodoList.Infrastructure.Repositories;
var repo = new CategoryRepository();
var cat = new Category()
{
    Name = "Kat2",
    Color = "#223456"
};
Console.WriteLine(await repo.AddCategory(cat));
var result = await repo.GetCategories();
foreach (var item in result)
{
    Console.WriteLine(item.Id);
    Console.WriteLine(item.Name);
    Console.WriteLine(item.Color);
    if (item.Name == "Kat2")
    {
        cat.Id = item.Id;
    }
}
Console.WriteLine();

cat.Name = "Kat2Test";

await repo.UpdateCategory(cat);

result = await repo.GetCategories();

foreach (var item in result)
{
    Console.WriteLine(item.Id);
    Console.WriteLine(item.Name);
    Console.WriteLine(item.Color);
}
Console.WriteLine();

await repo.DeleteCategory(cat.Id);

result = await repo.GetCategories();

foreach (var item in result)
{
    Console.WriteLine(item.Id);
    Console.WriteLine(item.Name);
    Console.WriteLine(item.Color);
}
 
 
 */