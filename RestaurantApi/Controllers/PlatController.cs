using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestaurantApi.Models;
using RestaurantApi.Services;
using System.Linq;

namespace RestaurantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatController : ControllerBase
    {
        // Services injectés via le constructeur
        private readonly PlatService _platService;
        private readonly RestaurantDbContext _context;
        private readonly TheMealDbService _mealService;

        public PlatController(PlatService platService, RestaurantDbContext context, TheMealDbService mealService)
        {
            _platService = platService;
            _context = context;
            _mealService = mealService;
        }

        // Récupérer les détails d'un plat par son ID
        [HttpGet("{id}")]
        public async Task<ActionResult<PlatDetailDto>> GetPlatDetails(int id)
        {
            var plat = await _platService.GetPlatDetailsByIdAsync(id);
            if (plat == null)
            {
                return NotFound("Plat non trouvé.");
            }

            // Convertir en DTO pour la réponse
            var platDetailDto = new PlatDetailDto
            {
                Nom = plat.Nom,
                ImageUrl = plat.ImageUrl,
                Categorie = plat.Categorie,
                Ingredients = plat.Ingredients.Select(i => new IngredientDto
                {
                    Nom = i.Nom,
                    Quantite = i.Quantite,
                    Unite = i.Unite
                }).ToList()
            };

            return Ok(platDetailDto);
        }

        // Récupérer tous les plats associés à un restaurant donné
        [HttpGet("byRestaurant/{restaurantId}")]
        public async Task<ActionResult<IEnumerable<Plat>>> GetPlatsByRestaurant(int restaurantId)
        {
            var plats = await _platService.GetPlatsByRestaurantIdAsync(restaurantId);
            if (plats == null)
            {
                return NotFound("Aucun plat trouvé pour ce restaurant.");
            }
            return Ok(plats);
        }

        // Ajouter un plat spécifique de TheMealDb à un restaurant
        [HttpPost("add/{restaurantId}/{mealName}")]
        public async Task<IActionResult> AddMealToRestaurant(int restaurantId, string mealName)
        {
            var mealResponse = await _mealService.FetchMealByNameAsync(mealName);
            if (mealResponse == null || !mealResponse.Meals.Any())
            {
                return NotFound("Aucun plat trouvé avec ce nom.");
            }

            var meal = mealResponse.Meals.First();
            Plat plat = new Plat
            {
                Nom = meal.StrMeal,
                ImageUrl = meal.StrMealThumb,
                Categorie = meal.StrCategory,
                RestaurantId = restaurantId
            };

            _context.Plats.Add(plat);
            await _context.SaveChangesAsync();

            return Ok(plat);
        }

        // Ajouter un plat aléatoire de TheMealDb à un restaurant spécifié
        [HttpPost("ajouter-aleatoire/{restaurantId}")]
        public async Task<IActionResult> AjouterPlatAleatoire(int restaurantId)
        {
            var platAleatoire = await _mealService.FetchRandomMealAsync();
            if (platAleatoire == null)
            {
                return NotFound("Aucun plat trouvé.");
            }

            // Extraction et ajout des ingrédients
            var ingredients = _mealService.ParseIngredients(platAleatoire);
            var nouveauPlat = new Plat
            {
                Nom = platAleatoire.StrMeal,
                ImageUrl = platAleatoire.StrMealThumb,
                Categorie = platAleatoire.StrCategory,
                RestaurantId = restaurantId,
                Ingredients = ingredients
            };

            _context.Plats.Add(nouveauPlat);
            await _context.SaveChangesAsync();

            return Ok(nouveauPlat);
        }

        // Mettre à jour un plat existant
        [HttpPut]
        public async Task UpdatePlatAsync(Plat plat)
        {
            await _platService.UpdatePlatAsync(plat);
        }

        // Supprimer un plat spécifié par ID
        [HttpDelete("{id}")]
        public async Task DeletePlatAsync(int id)
        {
            await _platService.DeletePlatAsync(id);
        }
    }
}