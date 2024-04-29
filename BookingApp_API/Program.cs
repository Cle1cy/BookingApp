using BookingApp_API.Interfaces;
using BookingApp_API.Repository;
using BookingApp_API.Services;
using Microsoft.EntityFrameworkCore;
using BookingApp_API.Context;
using BookingApp_API.Helpers;


var builder = WebApplication.CreateBuilder(args);

// Configure services

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddDbContext<DBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<UserService>();

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
