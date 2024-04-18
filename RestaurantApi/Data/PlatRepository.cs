using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestaurantApi.Models;

namespace RestaurantApi.Data
{
    public class PlatRepository : IPlatRepository
    {
        private readonly RestaurantDbContext _context;

        public PlatRepository(RestaurantDbContext context)
        {
            _context = context;
        }
        // Implémenter Task<Plat> GetPlatDetailsByIdAsync(int id)
        public async Task<Plat> GetPlatDetailsByIdAsync(int id)
        {
            return await _context.Plats
                             .Include(p => p.Ingredients)  // Inclure les ingrédients liés au plat
                             .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Plat>> GetAllAsync()
        {
            return await _context.Plats.ToListAsync();
        }

        public async Task<Plat> GetByIdAsync(int id)
        {
            return await _context.Plats
                             .Include(p => p.Ingredients)  // Inclure les ingrédients liés au plat
                             .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Plat>> GetByRestaurantIdAsync(int restaurantId)
        {
            return await _context.Plats.Where(p => p.RestaurantId == restaurantId).ToListAsync();
        }
        public async Task<IEnumerable<Plat>> GetPlatsWithIngredientsByRestaurantIdAsync(int restaurantId)
        {
            var plats = await _context.Plats
                                      .Where(p => p.RestaurantId == restaurantId)
                                      .ToListAsync();
            foreach (var plat in plats)
            {
                plat.Ingredients = await _context.Ingredients
                                                .Where(i => i.PlatId == plat.Id)
                                                .ToListAsync();
            }
            return plats;
        }

        public async Task<Plat> GetPlatWithIngredientsByIdAsync(int platId)
        {
            var plat = await _context.Plats
                                     .FirstOrDefaultAsync(p => p.Id == platId);
            if (plat != null)
            {
                plat.Ingredients = await _context.Ingredients
                                                .Where(i => i.PlatId == plat.Id)
                                                .ToListAsync();
            }
            return plat;
        }

        public async Task<Plat> AddAsync(Plat plat)
        {
            _context.Plats.Add(plat);
            await _context.SaveChangesAsync();
            return plat;
        }

        public async Task UpdateAsync(Plat plat)
        {
            _context.Plats.Update(plat);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var plat = await _context.Plats.FindAsync(id);
            if (plat != null)
            {
                _context.Plats.Remove(plat);
                await _context.SaveChangesAsync();
            }
        }
    }
}
