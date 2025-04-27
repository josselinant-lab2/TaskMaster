using Microsoft.Maui.Controls;
using TaskMaster.UI.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace TaskMaster.UI.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage(LoginPageViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
        public LoginPage() : this(App.Current.Services.GetService<LoginPageViewModel>())
        {
        }
    }
}
