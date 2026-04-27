namespace TodoList.DTOs;

public class TaskDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public bool IsDone { get; set; } = false;
    public int UserId { get; set; }
    public string? UserName { get; set; } = string.Empty;
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    public DateTime DateModified { get; set; }
}