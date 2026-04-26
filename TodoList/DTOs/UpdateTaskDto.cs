using System.ComponentModel.DataAnnotations;

namespace TodoList.DTOs;

public class UpdateTaskDto
{
    [Required] 
    [MinLength(5)]
    public string Name { get; set; }
    [Required]
    [MinLength(10)]
    public string? Description { get; set; }
    public bool IsDone { get; set; } = false;
    public DateTime DateCreated { get; set; }  = DateTime.UtcNow;
    public DateTime DateModified { get; set; } 
}