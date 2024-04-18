using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestaurantApi.Models;

namespace RestaurantApi.Data
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly RestaurantDbContext _context;

        public RestaurantRepository(RestaurantDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Restaurant>> GetAllRestaurantsWithDetailsAsync()
        {
            return await _context.Restaurants
                .Include(r => r.Plats)
                    .ThenInclude(p => p.Ingredients)
                .ToListAsync();
        }

        public async Task<IEnumerable<Restaurant>> GetAllRestaurantsAsync()
        {
            return await _context.Restaurants.ToListAsync();
        }

        public async Task<Restaurant> GetRestaurantByIdAsync(int id)
        {
            return await _context.Restaurants.Include(r => r.Plats).ThenInclude(p => p.Ingredients).FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task AddRestaurantAsync(Restaurant restaurant)
        {
            _context.Restaurants.Add(restaurant);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRestaurantAsync(Restaurant restaurant)
        {
            _context.Restaurants.Update(restaurant);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRestaurantAsync(int id)
        {
            var restaurant = await _context.Restaurants.FindAsync(id);
            if (restaurant != null)
            {
                _context.Restaurants.Remove(restaurant);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Plat>> GetPlatsByRestaurantIdAsync(int restaurantId)
        {
            return await _context.Plats
                                 .Where(p => p.RestaurantId == restaurantId)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Plat>> GetPlatsWithIngredientsByRestaurantIdAsync(int restaurantId)
        {
            var plats = await GetPlatsByRestaurantIdAsync(restaurantId);
            foreach (var plat in plats)
            {
                var ingredients = await _context.Ingredients
                                                .Where(i => i.PlatId == plat.Id)
                                                .ToListAsync();
                // Assuming Plat has a property to hold ingredients which is not mapped to database
                plat.Ingredients = ingredients;
            }
            return plats;
        }

    }       
    

   
}
