using System.Collections.Generic;
using System.Threading.Tasks;
using RestaurantApi.Data;
using RestaurantApi.Models;

namespace RestaurantApi.Services
{
    public class PlatService
    {
        private readonly IPlatRepository _platRepository;

        public PlatService(IPlatRepository platRepository)
        {
            _platRepository = platRepository;
        }
        // Implementer  GetPlatDetailsByIdAsync(int id) pour retourner un plat avec les détails
        public async Task<Plat> GetPlatDetailsByIdAsync(int id)
        {
            return await _platRepository.GetPlatDetailsByIdAsync(id);
        }

        public async Task<IEnumerable<Plat>> GetAllPlatsAsync()
        {
            return await _platRepository.GetAllAsync();
        }

        public async Task<Plat> GetPlatByIdAsync(int id)
        {
            return await _platRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Plat>> GetPlatsByRestaurantIdAsync(int restaurantId)
        {
            return await _platRepository.GetByRestaurantIdAsync(restaurantId);
        }

        public async Task<IEnumerable<Plat>> GetPlatsWithIngredientsByRestaurantIdAsync(int restaurantId)
        {
            return await _platRepository.GetPlatsWithIngredientsByRestaurantIdAsync(restaurantId);
        }
        public async Task<Plat> GetPlatWithIngredientsByIdAsync(int platId)
        {
            return await _platRepository.GetPlatWithIngredientsByIdAsync(platId);
        }

        public async Task<Plat> AddPlatAsync(Plat plat)
        {
            if (plat == null)
            {
                throw new ArgumentNullException(nameof(plat));
            }
            return await _platRepository.AddAsync(plat);
        }

        public async Task UpdatePlatAsync(Plat plat)
        {
            if (plat == null)
            {
                throw new ArgumentNullException(nameof(plat));
            }
            await _platRepository.UpdateAsync(plat);
        }

        public async Task DeletePlatAsync(int id)
        {
            await _platRepository.DeleteAsync(id);
        }
    }
}
