using Microsoft.EntityFrameworkCore;

namespace TodoList.Model;

[Index(nameof(Email), IsUnique = true)]
public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public List<Task> Tasks { get; set; } = [];
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    public DateTime? DateModified { get; set; } = null;
}