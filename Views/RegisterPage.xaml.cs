using Microsoft.Maui.Controls;
using TaskMaster.UI.ViewModels;

namespace TaskMaster.UI.Views
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage(RegisterPageViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}
