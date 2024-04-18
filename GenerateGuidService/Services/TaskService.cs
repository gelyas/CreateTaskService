
//using GenerateGuidService.Data;
using GenerateGuidService.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
        public async Task<Guid> CreateTaskAsync()
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

        public async Task<string> GetTaskByIdAsync(Guid Id)
        {
            var task = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == Id);
            string getTaskState = task?.State;
            if (!getTaskState.IsNullOrEmpty())
                return getTaskState;
            else
                return string.Empty;
        }

        public async Task UpdateTaskStateAsync(Guid _id, string _state)
        {
            var _task = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == _id);

            if(_task == null)
            {
                //return Internal;
            }

            _task.State = _state;
            _task.Timestamp = DateTime.Now;

            //await _context.Tasks.AddAsync(_task);
             _context.SaveChanges();

            return;
        }
    }
}
