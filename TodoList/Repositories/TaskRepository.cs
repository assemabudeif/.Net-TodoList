using Microsoft.EntityFrameworkCore;
using TodoList.DTOs;
using Task = TodoList.Model.Task;

namespace TodoList.Repositories;

public class TaskRepository(AppDbContext context) : ITaskRepository
{
    public async Task<List<Task>> GetAllAsync()
    {
        return await context.Tasks.ToListAsync();
    }

    public async Task<TaskDto?> GetByIdAsync(int id)
    {
        var task = await context.Tasks
            .Include(t => t.User)
            .FirstOrDefaultAsync(t => t.Id == id);
        if (task == null) return null;
        return new TaskDto
        {
            Id = task.Id,
            Name = task.Name,
            Description = task.Description,
            IsDone = task.IsDone,
            DateCreated = task.DateCreated,
            DateModified = task.DateModified,
            UserId = task.UserId,
            UserName = task.User?.Name
        };
    }

    public async Task<List<Task>> GetByUserIdAsync(int userId)
    {
        return await context.Tasks.Where(t => t.UserId == userId).ToListAsync();
    }

    public async Task<Task> CreateAsync(Task task)
    {
        await context.Tasks.AddAsync(task);
        await context.SaveChangesAsync();

        return task;
    }

    public async Task<Task?> UpdateAsync(Task updated)
    {
        var task = await context.Tasks.FirstOrDefaultAsync(t => t.Id == updated.Id);
        if (task == null) return null;
        task.Name = updated.Name;
        task.Description = updated.Description;
        task.IsDone = updated.IsDone;
        task.DateCreated = updated.DateCreated;
        task.DateModified = DateTime.UtcNow;
        task.UserId = updated.UserId;
        await context.SaveChangesAsync();

        updated.DateModified = DateTime.UtcNow;

        return updated;
    }

    public Task<bool> DeleteAsync(int id)
    {
        var task = context.Tasks.FirstOrDefault(t => t.Id == id);
        if (task == null) return System.Threading.Tasks.Task.FromResult(false);
        context.Tasks.Remove(task);
        context.SaveChanges();
        return System.Threading.Tasks.Task.FromResult(true);
    }
}