using System.Collections.Generic;
using System.Threading.Tasks;
using RestaurantApi.Models;

namespace RestaurantApi.Data
{
    public interface IRestaurantRepository
    {
        Task<IEnumerable<Restaurant>> GetAllRestaurantsWithDetailsAsync();
        Task<IEnumerable<Restaurant>> GetAllRestaurantsAsync();

        Task<Restaurant> GetRestaurantByIdAsync(int id);
        Task AddRestaurantAsync(Restaurant restaurant);
        Task UpdateRestaurantAsync(Restaurant restaurant);
        Task DeleteRestaurantAsync(int id);
        Task<IEnumerable<Plat>> GetPlatsByRestaurantIdAsync(int restaurantId);
        Task<IEnumerable<Plat>> GetPlatsWithIngredientsByRestaurantIdAsync(int restaurantId);
    }
}
