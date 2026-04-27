using TodoList.DTOs;
using Task = TodoList.Model.Task;

namespace TodoList.Repositories;

public interface ITaskRepository
{
    public Task<List<Task>> GetAllAsync();
    public Task<TaskDto?> GetByIdAsync(int id);
    public Task<List<Task>> GetByUserIdAsync(int userId);
    public Task<Task> CreateAsync(Task task);
    public Task<Task?> UpdateAsync(Task updated);
    public Task<bool> DeleteAsync(int id);
}