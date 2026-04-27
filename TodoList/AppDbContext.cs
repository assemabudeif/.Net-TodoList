using Microsoft.EntityFrameworkCore;
using TodoList.Model;
using Task = TodoList.Model.Task;

namespace TodoList;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Task> Tasks { get; set; }
    public DbSet<User> Users { get; set; }
}