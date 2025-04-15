using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SystemTask = System.Threading.Tasks.Task;
using TaskMaster.Services;

namespace TaskMaster.UI.ViewModels
{
    public partial class LoginPageViewModel : ObservableObject
    {
        private readonly IUserService _userService;

        // Injection via le constructeur
        public LoginPageViewModel(IUserService userService)
        {
            _userService = userService;
        }

        [ObservableProperty]
        private string email = string.Empty;

        [ObservableProperty]
        private string password = string.Empty;

        [ObservableProperty]
        private string errorMessage = string.Empty;

        [RelayCommand]
        private async SystemTask LoginAsync()
        {

            ErrorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
            {
                ErrorMessage = "Veuillez saisir l'email et le mot de passe.";
                return;
            }

            var user = await _userService.AuthenticateUserAsync(Email, Password);
            if (user == null)
            {
                ErrorMessage = "Email ou mot de passe invalide.";
                return;
            }

            Services.SessionService.CurrentUser = user;
            await Shell.Current.GoToAsync("///TaskListPage");
            return;
        }

        [RelayCommand]
        private async SystemTask NavigateToRegisterAsync()
        {
            await Shell.Current.GoToAsync("///RegisterPage");
            return;
        }
    }
}
