using TaskMaster.Models;

namespace TaskMaster.Services
{
    public static class SessionService
    {
        /// <summary>
        /// L'utilisateur actuellement connecté.
        /// </summary>
        public static User CurrentUser { get; set; }
    }
}
