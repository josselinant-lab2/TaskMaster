using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskMaster.Data;
using TaskMaster.Models;

namespace TaskMaster.Services
{
    public class ReferenceDataService : IReferenceDataService
    {
        private readonly AppDbContext _context;

        public ReferenceDataService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Categorie>> GetCategoriesAsync(int userId)
        {
            return await _context.Categories
                .Where(c => c.Id_User == userId)
                .ToListAsync();
        }

        public async Task<List<Priorite>> GetPrioritesAsync()
        {
            return await _context.Priorites.ToListAsync();
        }

        public async Task<List<Statut>> GetStatutsAsync()
        {
            return await _context.Statuts.ToListAsync();
        }
    }
}
