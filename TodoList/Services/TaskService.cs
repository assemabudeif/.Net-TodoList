using TodoList.DTOs;
using TodoList.Repositories;
using Task = TodoList.Model.Task;

namespace TodoList.Services;

public class TaskService(ITaskRepository repo) : ITaskService
{
    public async Task<List<Task>> GetAllAsync()
    {
        return await repo.GetAllAsync();
    }

    public async Task<Task?> GetByIdAsync(int id)
    {
        return await repo.GetByIdAsync(id);
    }

    public async Task<List<Task>> GetByUserIdAsync(int userId)
    {
        return await repo.GetByUserIdAsync(userId);
    }

    public async Task<Task> CreateAsync(CreateTaskDto task)
    {
        var created = await repo.CreateAsync(task.ToTask());

        return created;
    }

    public async Task<Task?> UpdateAsync(int id, UpdateTaskDto updated)
    {
        return await repo.UpdateAsync(updated.ToTask(id));
    }

    public Task<bool> DeleteAsync(int id)
    {
        return repo.DeleteAsync(id);
    }
}