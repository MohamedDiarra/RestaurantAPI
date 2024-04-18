using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestaurantApi.Models;
using RestaurantApi.Services;
using Microsoft.EntityFrameworkCore;

namespace RestaurantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        // Service pour gérer les opérations liées aux restaurants
        private readonly RestaurantService _restaurantService;

        public RestaurantController(RestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        // Récupère et renvoie tous les restaurants disponibles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Restaurant>>> GetAllRestaurants()
        {
            // Appel du service pour obtenir tous les restaurants
            var restaurants = await _restaurantService.GetAllRestaurantsWithDetailsAsync();
            if (restaurants == null)
                return NotFound("Aucun restaurant trouvé.");

            return Ok(restaurants);
        }

        // Ajoute un nouveau restaurant à la base de données
        [HttpPost]
        public async Task<IActionResult> AddRestaurant([FromBody] Restaurant restaurant)
        {
            await _restaurantService.AddRestaurantAsync(restaurant);
            // Retourne un résultat de création avec un lien vers le restaurant créé
            return CreatedAtAction(nameof(GetRestaurant), new { id = restaurant.Id }, restaurant);
        }

        // Récupère un restaurant spécifique par son identifiant
        [HttpGet("{id}")]
        public async Task<ActionResult<Restaurant>> GetRestaurant(int id)
        {
            var restaurant = await _restaurantService.GetRestaurantByIdAsync(id);
            if (restaurant == null)
            {
                return NotFound("Restaurant non trouvé.");
            }
            return Ok(restaurant);
        }

        // Récupère tous les plats associés à un restaurant spécifique
        [HttpGet("{restaurantId}/plats")]
        public async Task<ActionResult<IEnumerable<PlatDto>>> GetPlatsByRestaurant(int restaurantId)
        {
            var plats = await _restaurantService.GetPlatsByRestaurantIdAsync(restaurantId);
            if (plats == null)
                return NotFound("Aucun plat trouvé pour ce restaurant.");

            // Convertit les plats en DTOs pour renvoyer des données simplifiées
            var platDtos = plats.Select(p => new PlatDto
            {
                Nom = p.Nom,
                ImageUrl = p.ImageUrl
            }).ToList();

            return Ok(platDtos);
        }
    }
}