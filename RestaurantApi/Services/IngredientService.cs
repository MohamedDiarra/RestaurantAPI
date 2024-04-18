using System.Collections.Generic;
using System.Threading.Tasks;
using RestaurantApi.Data;
using RestaurantApi.Models;

namespace RestaurantApi.Services
{
    public class IngredientService
    {
        private readonly IIngredientRepository _ingredientRepository;

        public IngredientService(IIngredientRepository ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }

        public async Task<IEnumerable<Ingredient>> GetAllIngredientsAsync()
        {
            return await _ingredientRepository.GetAllIngredientsAsync();
        }

        public async Task<Ingredient> GetIngredientByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid ID", nameof(id));
            }
            return await _ingredientRepository.GetIngredientByIdAsync(id);
        }

        public async Task AddIngredientAsync(Ingredient ingredient)
        {
            if (ingredient == null)
            {
                throw new ArgumentNullException(nameof(ingredient));
            }
            await _ingredientRepository.AddIngredientAsync(ingredient);
        }

        public async Task UpdateIngredientAsync(Ingredient ingredient)
        {
            if (ingredient == null)
            {
                throw new ArgumentNullException(nameof(ingredient));
            }
            await _ingredientRepository.UpdateIngredientAsync(ingredient);
        }

        public async Task DeleteIngredientAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid ID", nameof(id));
            }
            await _ingredientRepository.DeleteIngredientAsync(id);
        }
        
    }
}
