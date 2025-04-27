using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SystemTask = System.Threading.Tasks.Task;
using TaskMaster.Models;
using TaskMaster.Services;

namespace TaskMaster.UI.ViewModels
{
    public partial class RegisterPageViewModel : ObservableObject
    {
        private readonly IUserService _userService;

        public RegisterPageViewModel(IUserService userService)
        {
            _userService = userService;
        }

        [ObservableProperty]
        private string pseudo = string.Empty;

        [ObservableProperty]
        private string email = string.Empty;

        [ObservableProperty]
        private string password = string.Empty;

        [ObservableProperty]
        private string confirmPassword = string.Empty;

        [ObservableProperty]
        private string errorMessage = string.Empty;

        [RelayCommand]
        private async SystemTask CreateAccountAsync()
        {
            ErrorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(Pseudo) ||
                string.IsNullOrWhiteSpace(Email) ||
                string.IsNullOrWhiteSpace(Password) ||
                string.IsNullOrWhiteSpace(ConfirmPassword))
            {
                ErrorMessage = "Tous les champs doivent être remplis.";
                return;
            }

            if (Password != ConfirmPassword)
            {
                ErrorMessage = "Les mots de passe ne correspondent pas.";
                return;
            }

            if (await _userService.IsEmailUsedAsync(Email))
            {
                ErrorMessage = "Cette adresse e-mail est déjà utilisée.";
                return;
            }

            var newUser = new User
            {
                Pseudo = this.Pseudo,
                Email = this.Email
            };

            bool registrationSucceeded = await _userService.RegisterUserAsync(newUser, Password);
            if (registrationSucceeded)
            {
                await Shell.Current.GoToAsync("///LoginPage");
            }
            else
            {
                ErrorMessage = "Une erreur est survenue lors de la création du compte.";
            }

            return;
        }
    }
}
