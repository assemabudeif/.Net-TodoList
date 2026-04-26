using Microsoft.EntityFrameworkCore;

namespace TodoList;

public class AppDbContext : DbContext
{
    public DbSet<Model.Task> Tasks { get; set; }
    public DbSet<Model.User> Users { get; set; }
}