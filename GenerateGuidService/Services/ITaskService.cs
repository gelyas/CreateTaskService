using GenerateGuidService.Models;

namespace GenerateGuidService.Services
{
    public interface ITaskService
    {
        Task<Guid> CreateTaskAsync();
        Task UpdateTaskStateAsync(Guid Id, string State);
        Task<string> GetTaskByIdAsync(Guid Id);
    }
}
