using ToDoApp_API.Interfaces;
using ToDoApp_API.Repository;
using ToDoApp_API.Services;
using Microsoft.EntityFrameworkCore;
using ToDoApp_API.Context;


var builder = WebApplication.CreateBuilder(args);

// Configure services
builder.Services.AddDbContext<DBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<Userervice>();

// Add controllers
builder.Services.AddControllers();

// Add Swagger
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapControllers();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
