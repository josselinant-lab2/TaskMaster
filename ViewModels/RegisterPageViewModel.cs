using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;

namespace TaskMaster.UI.ViewModels
{
    public partial class RegisterPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private string pseudo = string.Empty;

        [ObservableProperty]
        private string email = string.Empty;

        [ObservableProperty]
        private string password = string.Empty;

        [ObservableProperty]
        private string confirmPassword = string.Empty;

        [RelayCommand]
        private async Task CreateAccountAsync()
        {
            if (!string.IsNullOrWhiteSpace(Pseudo) &&
                !string.IsNullOrWhiteSpace(Email) &&
                !string.IsNullOrWhiteSpace(Password) &&
                Password == ConfirmPassword)
            {
                await Shell.Current.GoToAsync("LoginPage");
            }
            else
            {
               
            }
        }
    }
}
