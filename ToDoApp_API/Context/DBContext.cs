using Microsoft.EntityFrameworkCore;
using ToDoApp_API.Models;
using ToDoApp_App.Models;
namespace ToDoApp_API.Context;

public class DBContext : DbContext
{

    public DBContext(DbContextOptions<DBContext> options) : base(options) { }

    public DbSet<User> User { get; set; }
    public DbSet<Note> Note { get; set; }

}