using TodoList.DTOs;

namespace TodoList.Services;

public interface ITaskService
{
    public Task<List<Model.Task>> GetAllAsync();
    public Task<Model.Task?> GetByIdAsync(int id);
    public Task<List<Model.Task>> GetByUserIdAsync(int userId);
    public Task<Model.Task> CreateAsync(CreateTaskDto task);
    public Task<Model.Task?> UpdateAsync(int id, UpdateTaskDto updated);
    public Task<bool> DeleteAsync(int id);
}