using ToDoApp_API.Interfaces;
using ToDoApp_API.Repository;
using ToDoApp_API.Services;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//Add conection to DB

//Add repository
builder.Services.AddScoped<IUserRepository, UserRepository>();

//Add services
builder.Services.AddScoped<UserService>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
app.UseHttpsRedirection();
app.Run();


