using TodoList.Application.Repositories;
using TodoList.Infrastructure.Providers;
using TodoList.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(conf =>
{
    conf.RegisterServicesFromAssembly(typeof(ICategoryRepository).Assembly);
});

builder.Services.AddDbContext<TodoListContext>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ITodoListRepository, TodoListRepository>();



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
// Docker compose laufen lassen
// Update-Database -Project TodoList.Infrastructure


/* Zu machen:
 * 
 * API für CRUD Category
 * API für CRUD TODO Items
 * 
 * API für die Details
 * 
 * Validieren oder kreieren vom Schedule
 * 
 * Frontend bauen
 * 
 */