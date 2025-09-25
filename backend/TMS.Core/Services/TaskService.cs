using Microsoft.EntityFrameworkCore;
using TMS.Core.DB;

namespace TMS.Core.Services
{
    public class TaskService
    {

        private readonly TMSDbContext _dbContext;

        public TaskService(TMSDbContext tMSDbContext)
        {
            _dbContext = tMSDbContext;
        }

        public async Task<List<Models.Task>> GetAllTask()
        {
            return await _dbContext.Tasks.ToListAsync();
        }

        public async Task<Models.Task> CreateTask(Models.Task task)
        {
            _dbContext.Tasks.Add(task);
            await _dbContext.SaveChangesAsync();
            return task;
        }

        public async Task<Models.Task> UpdateTask(Guid id, Models.Task task)
        {
            var existingTask = await _dbContext.Tasks.FindAsync(id);
            if(existingTask is null)
            {
                throw new ArgumentNullException("Invalid Task Id.s");
            }
            existingTask.Title = task.Title;
            existingTask.Description = task.Description;    
            existingTask.AssigneeId = task.AssigneeId;
            existingTask.Priority = task.Priority;
            existingTask.Status = task.Status;  
            existingTask.UpdatedAt= DateTime.Now;

            await _dbContext.SaveChangesAsync();
            return existingTask;
        }

        public async Task<Models.Task> GetTask(Guid id)
        {
            var existingTask = await _dbContext.Tasks.FindAsync(id);
            if(existingTask is null)
            {
                throw new ArgumentNullException("task not found.");
            }

            return existingTask;
        }

        public async Task<bool> DeleteTask(Guid id)
        {
            var existingTask = await _dbContext.Tasks.FindAsync(id);
            if (existingTask is null)
            {
                return false;
            }
            _dbContext.Tasks.Remove(existingTask);
            _dbContext.SaveChanges();
            return true;
        }


        public async Task<List<Models.Task>> GetTasksByStatusAndAssignee(string status, string assignee)
        {
            var assigneId = _dbContext.Users.Where(x => x.Name == assignee).First();
            var tasks = _dbContext.Tasks.Where(x => x.Status.Equals(status)
                                               && x.AssigneeId.Equals(assigneId.Id)).ToList();
            return tasks;
        }
    }
}
