namespace TodoList.Repositories;

public interface ITaskRepository
{
    public Task<List<Model.Task>> GetAllAsync();
    public Task<Model.Task?> GetByIdAsync(int id);
    public Task<List<Model.Task>> GetByUserIdAsync(int userId);
    public Task<Model.Task> CreateAsync(Model.Task task);
    public Task<Model.Task> UpdateAsync(int id, Model.Task updated);
    public Task<bool> DeleteAsync(int id);
}