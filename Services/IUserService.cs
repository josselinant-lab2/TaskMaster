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
        /// Vérifie si l'adresse e-mail est déjà utilisée.
        /// </summary>
        Task<bool> IsEmailUsedAsync(string email);
    }
}
