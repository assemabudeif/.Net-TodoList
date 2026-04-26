using Microsoft.EntityFrameworkCore;

namespace TodoList;

public class AppDbContext : DbContext
{
    DbSet<Model.Task> Tasks { get; set; }
    DbSet<Model.User> Users { get; set; }
}