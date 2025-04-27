using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TaskMaster.Models;
using TaskMaster.Services;

namespace TaskMaster.UI.ViewModels
{
    using TaskModel = TaskMaster.Models.Task;

    public partial class TaskListViewModel : ObservableObject
    {
        private readonly ITaskService _taskService;

        public ObservableCollection<TaskModel> Tasks { get; } = new ObservableCollection<TaskModel>();

        public IAsyncRelayCommand LoadTasksCommand { get; }

        public TaskListViewModel(ITaskService taskService)
        {
            _taskService = taskService;
            LoadTasksCommand = new AsyncRelayCommand(LoadTasksAsync);
        }

        /// <summary>
        /// Charge les tâches associées à l'utilisateur connecté.
        /// </summary>
        private async System.Threading.Tasks.Task LoadTasksAsync()
        {
            var currentUser = SessionService.CurrentUser;
            if (currentUser == null)
            {

                Tasks.Clear();
                return;
            }

            var tasksFromDb = await _taskService.GetTasksForUserAsync(currentUser.Id_User);

            Tasks.Clear();
            foreach (var task in tasksFromDb)
            {
                Tasks.Add(task);
            }
        }

        [RelayCommand]
        private async System.Threading.Tasks.Task AddTaskAsync()
        {
            await Shell.Current.GoToAsync("///CreateTaskPage");
        }


    }
}
