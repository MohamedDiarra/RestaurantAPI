using System.Collections.Generic;
using System.Threading.Tasks;
using RestaurantApi.Models;

namespace RestaurantApi.Data
{
    public interface IPlatRepository { 
        Task<IEnumerable<Plat>> GetAllAsync();
        Task<Plat> GetByIdAsync(int id);
        Task<IEnumerable<Plat>> GetByRestaurantIdAsync(int restaurantId);
        Task<IEnumerable<Plat>> GetPlatsWithIngredientsByRestaurantIdAsync(int restaurantId);
        Task<Plat> GetPlatWithIngredientsByIdAsync(int platId);
        Task<Plat> GetPlatDetailsByIdAsync(int platId);
        Task<Plat> AddAsync(Plat plat);
        Task UpdateAsync(Plat plat);
        Task DeleteAsync(int id);
    }
}
