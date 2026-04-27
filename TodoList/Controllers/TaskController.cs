using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoList.DTOs;
using TodoList.Services;

namespace TodoList.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class TaskController(ITaskService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var tasks = await service.GetAllAsync();
        return Ok(tasks);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var task = await service.GetByIdAsync(id);
        if (task == null) return NotFound();
        return Ok(task);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTaskDto task)
    {
        var created = await service.CreateAsync(task);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateTaskDto updated)
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        var task = await service.UpdateAsync(id, updated, userId);
        if (task == null) return NotFound();
        return Ok(task);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await service.DeleteAsync(id);
        if (!success) return NotFound();
        return Ok(new { success = true, message = "Deleted successfully" });
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> ToggleCompleted(int id)
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        var task = await service.GetByIdAsync(id);
        if (task == null) return NotFound();

        var updatedTask = new UpdateTaskDto
        {
            Name = task.Name,
            Description = task.Description,
            IsDone = !task.IsDone
        };

        var updated = await service.UpdateAsync(id, updatedTask, userId);
        return Ok(updated);
    }

    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetByUserId(int userId)
    {
        var tasks = await service.GetByUserIdAsync(userId);
        return Ok(tasks);
    }
}