using Microsoft.Maui.Controls;
using TaskMaster.UI.ViewModels;

namespace TaskMaster.UI.Views
{
    public partial class CreateTaskPage : ContentPage
    {
        public CreateTaskPage(CreateTaskViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}
