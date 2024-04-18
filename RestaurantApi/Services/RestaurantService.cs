using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestaurantApi.Data;
using RestaurantApi.Models;

namespace RestaurantApi.Services
{
    public class RestaurantService 
    {
        private readonly IRestaurantRepository _restaurantRepository;
       

        public RestaurantService(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
            
        }

        public async Task<IEnumerable<Restaurant>> GetAllRestaurantsWithDetailsAsync()
        {
            return await _restaurantRepository.GetAllRestaurantsWithDetailsAsync();
        }

        public async Task<IEnumerable<Restaurant>> GetAllRestaurantsAsync()
        {
            return await _restaurantRepository.GetAllRestaurantsAsync();
        }

        public async Task<Restaurant> GetRestaurantByIdAsync(int id)
        {
            return await _restaurantRepository.GetRestaurantByIdAsync(id);
        }

        public async Task AddRestaurantAsync(Restaurant restaurant)
        {
            await _restaurantRepository.AddRestaurantAsync(restaurant);
        }

        public async Task UpdateRestaurantAsync(Restaurant restaurant)
        {
            await _restaurantRepository.UpdateRestaurantAsync(restaurant);
        }

        public async Task DeleteRestaurantAsync(int id)
        {
            await _restaurantRepository.DeleteRestaurantAsync(id);
        }

        public async Task<IEnumerable<Plat>> GetPlatsByRestaurantIdAsync(int restaurantId)
        {
            return await _restaurantRepository.GetPlatsByRestaurantIdAsync(restaurantId);
        }

        public async Task<IEnumerable<Plat>> GetPlatsWithIngredientsByRestaurantIdAsync(int restaurantId)
        {
            return await _restaurantRepository.GetPlatsWithIngredientsByRestaurantIdAsync(restaurantId);
        }

    }
}
