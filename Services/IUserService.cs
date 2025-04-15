using System.Threading.Tasks;
using TaskMaster.Models;

namespace TaskMaster.Services
{
    public interface IUserService
    {
        /// <summary>
        /// Enregistre un nouvel utilisateur en hachant son mot de passe.
        /// Retourne true si l'opération a réussi.
        /// </summary>
        Task<bool> RegisterUserAsync(User user, string plainPassword);

        /// <summary>
        /// Vérifie si l'email est déjà utilisé.
        /// </summary>
        Task<bool> IsEmailUsedAsync(string email);

        /// <summary>
        /// Authentifie un utilisateur à partir de son email et mot de passe en clair.
        /// Retourne l'utilisateur si l'authentification réussit, sinon null.
        /// </summary>
        Task<User> AuthenticateUserAsync(string email, string plainPassword);
    }
}
