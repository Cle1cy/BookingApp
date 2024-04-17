using Microsoft.EntityFrameworkCore;
using ToDoApp_API.Models;
using ToDoApp_App.Models;
namespace ToDoApp_API.Context;

public class DBContext : DbContext
{

    public DBContext(DbContextOptions<DBContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Note> Notes { get; set; }

}