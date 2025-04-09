using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace TaskMasterTest.UI.ViewModels
{
    public partial class TaskListViewModel : ObservableObject
    {
        public ObservableCollection<string> Tasks { get; } = new ObservableCollection<string>();

        public TaskListViewModel()
        {
            LoadTasks();
        }

        private void LoadTasks()
        {
            Tasks.Add("Tâche 1 - Réunion d'équipe");
            Tasks.Add("Tâche 2 - Rapport mensuel");
            Tasks.Add("Tâche 3 - Vérifier les emails");
        }

        [RelayCommand]
        private async Task AddTaskAsync()
        {
            Tasks.Add("Nouvelle tâche ajoutée");
            await Task.CompletedTask;
        }
    }
}
