using System.Collections.Generic;
using System.Threading.Tasks;
using TaskMaster.Models;

namespace TaskMaster.Services
{
    public interface IReferenceDataService
    {
        Task<List<Categorie>> GetCategoriesAsync(int userId);
        Task<List<Priorite>> GetPrioritesAsync();
        Task<List<Statut>> GetStatutsAsync();
    }
}
