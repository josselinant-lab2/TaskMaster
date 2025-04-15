using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskMaster.Data;
using TaskModel = TaskMaster.Models.Task;  

namespace TaskMaster.Services
{
    public class TaskService : ITaskService
    {
        private readonly AppDbContext _context;

        public TaskService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<TaskModel>> GetTasksForUserAsync(int userId)
        {
            return await _context.Tasks
                .Include(t => t.RelationUserTasks)
                .Where(t => t.RelationUserTasks.Any(r => r.Id_User == userId))
                .ToListAsync();
        }

        public async Task AddTaskAsync(TaskModel newTask)
        {
            _context.Tasks.Add(newTask);
            await _context.SaveChangesAsync();
        }
    }
}
