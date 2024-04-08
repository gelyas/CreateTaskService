
//using GenerateGuidService.Data;
using GenerateGuidService.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Net;

namespace GenerateGuidService.Services
{
    public class TaskService : ITaskService
    {
        private readonly PlanningContext _context;
        public TaskService(PlanningContext context)
        {
            _context = context;
        }
        public async Task<Guid> CreateTask()
        {
            var newTask = new Tasks
            {
                Id = Guid.NewGuid(),
                Timestamp = DateTime.Now,
                State = "created"
            };

            //_context.Tasks.Add(newTask);
            _context.Tasks.Add(newTask);
            _context.SaveChanges();

            return newTask.Id;
        }

        public Task<ResponseModel<Tasks>> GetTaskById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateTaskState(Guid _id, string _state)
        {
            var _task = _context.Tasks.Where(x=>x.Id == _id).FirstOrDefault();

            if(_task == null)
            {
                //return Internal;
            }

            _task.State = _state;
            _task.Timestamp = DateTime.Now;

            //await _context.Tasks.AddAsync(_task);
             _context.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
