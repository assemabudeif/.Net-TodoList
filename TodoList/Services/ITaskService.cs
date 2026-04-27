using TodoList.DTOs;
using Task = TodoList.Model.Task;

namespace TodoList.Services;

public interface ITaskService
{
    public Task<List<Task>> GetAllAsync();
    public Task<TaskDto?> GetByIdAsync(int id);
    public Task<List<Task>> GetByUserIdAsync(int userId);
    public Task<Task> CreateAsync(CreateTaskDto task);
    public Task<Task?> UpdateAsync(int Id, UpdateTaskDto updated, int UserId);
    public Task<bool> DeleteAsync(int id);
}