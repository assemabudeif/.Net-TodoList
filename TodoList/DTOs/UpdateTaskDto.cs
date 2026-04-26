using System.ComponentModel.DataAnnotations;
using Task = TodoList.Model.Task;

namespace TodoList.DTOs;

public class UpdateTaskDto
{
    [Required] [MinLength(5)] public string Name { get; set; }

    [Required] [MinLength(10)] public string? Description { get; set; }

    public bool IsDone { get; set; } = false;
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    public DateTime DateModified { get; set; }

    public Task ToTask(int id)
    {
        return new Task
        {
            Id = id,
            Name = Name,
            Description = Description,
            IsDone = IsDone,
            DateCreated = DateCreated,
            DateModified = DateModified
        };
    }
}