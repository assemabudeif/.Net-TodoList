using Microsoft.EntityFrameworkCore;

namespace TodoList.Repositories;

public class TaskRepository(AppDbContext context) : ITaskRepository
{

    public async Task<List<Model.Task>> GetAllAsync() => await context.Tasks.ToListAsync();

    public async Task<Model.Task?> GetByIdAsync(int id)
    {
        return await context.Tasks.FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<List<Model.Task>> GetByUserIdAsync(int userId)
    {
        return await context.Tasks.Where(t => t.UserId == userId).ToListAsync();
    }

    public async Task<Model.Task> CreateAsync(Model.Task task)
    {
        await context.Tasks.AddAsync(task);
        await context.SaveChangesAsync();
        
        return task;
    }

    public async Task<Model.Task> UpdateAsync(int id, Model.Task updated)
    {
        var task = context.Tasks.FirstOrDefault(t => t.Id == id);
        if (task == null)        {
            return await Task.FromResult<Model.Task>(null);
        }
        task.Name = updated.Name;
        task.Description = updated.Description;
        task.IsDone = updated.IsDone;
        task.DateModified = DateTime.UtcNow;
        await context.SaveChangesAsync();
        
        updated.DateModified = DateTime.UtcNow;

        return updated;
    }

    public Task<bool> DeleteAsync(int id)
    {
        var task = context.Tasks.FirstOrDefault(t => t.Id == id);
        if (task == null) return Task.FromResult(false);
        context.Tasks.Remove(task);
        context.SaveChanges();
        return Task.FromResult(true);
    }
}