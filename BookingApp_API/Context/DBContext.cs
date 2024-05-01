using Microsoft.EntityFrameworkCore;
using BookingApp_API.Models;
namespace BookingApp_API.Context;

public class DBContext : DbContext
{

    public DBContext(DbContextOptions<DBContext> options) : base(options) { }

    public DbSet<ClassRoom> ClassRooms { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<TutorDetail> TutorDetails { get; set; }
    public DbSet<User> User { get; set; }
    public DbSet<UserClassroom> UserClassroom { get; set; }
    public DbSet<UserFriend> UserFriends { get; set; }
    public DbSet<UserPayment> UserPayment { get; set; }
    public DbSet<TopicsForSubject> TopicsForSubject { get; set; }

}