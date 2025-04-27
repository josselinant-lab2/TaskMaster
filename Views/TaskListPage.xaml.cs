using Microsoft.Maui.Controls;
using TaskMaster.UI.ViewModels;

namespace TaskMaster.UI.Views
{
    public partial class TaskListPage : ContentPage
    {
        public TaskListPage(TaskListViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (BindingContext is TaskListViewModel vm)
            {
                vm.LoadTasksCommand.Execute(null);
            }
        }
    }
}
