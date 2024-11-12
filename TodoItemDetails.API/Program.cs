using Microsoft.EntityFrameworkCore;
using TodoItemDetails.Application.Repositories;
using TodoItemDetails.Infrastructure.Providers;
using TodoItemDetails.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(conf =>
{
    conf.RegisterServicesFromAssembly(typeof(IItemDetailsRepository).Assembly);
});

builder.Services.AddDbContext<ItemDetailsContext>(options =>
    options.UseMongoDB(builder.Configuration.GetConnectionString("TodoItemDetailsDatabase") ?? "", "TodoItemDetails"));

builder.Services.AddScoped<IItemDetailsRepository, ItemDetailsRepository>();

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
