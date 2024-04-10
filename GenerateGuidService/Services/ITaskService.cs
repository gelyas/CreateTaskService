using GenerateGuidService.Models;

namespace GenerateGuidService.Services
{
    public interface ITaskService
    {
        Task<Guid> CreateTask();
        Task UpdateTaskState(Guid Id, string State);
        Task<string> GetTaskById(Guid Id);
    }
}
