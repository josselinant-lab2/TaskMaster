using System.Collections.Generic;
using System.Threading.Tasks;
using TaskModel = TaskMaster.Models.Task;

namespace TaskMaster.Services
{
    public interface ITaskService
    {
        /// <summary>
        /// Récupère toutes les tâches associées à un utilisateur.
        /// </summary>
        Task<List<TaskModel>> GetTasksForUserAsync(int userId);

        /// <summary>
        /// Ajoute une nouvelle tâche.
        /// </summary>
        Task AddTaskAsync(TaskModel newTask);
    }
}
