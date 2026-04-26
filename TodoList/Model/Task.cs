namespace TodoList.Model;

public class Task
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public bool IsDone { get; set; } = false;
    public int UserId { get; set; }
    public User User { get; set; }
    public DateTime DateCreated { get; set; }  = DateTime.UtcNow;
    public DateTime DateModified { get; set; } 
}