using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestaurantApi.Models;

namespace RestaurantApi.Services
{
    public class TheMealDbService
    {
        private readonly HttpClient _httpClient;

        public TheMealDbService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Obtenir des suggestions de plat basées sur une recherche par nom
        public async Task<MealApiResponse> FetchMealByNameAsync(string name)
        {
            string url = $"https://www.themealdb.com/api/json/v1/1/search.php?s={name}";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<MealApiResponse>(jsonResponse);
        }

        // Obtenir des suggestions de plat aléatoirement
        public async Task<Meal> FetchRandomMealAsync()
        {
            string url = "https://www.themealdb.com/api/json/v1/1/random.php";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<MealApiResponse>(content);
            return result.Meals.FirstOrDefault();
        }

        // Parse les ingrédients et les quantités à partir d'un objet Meal
        public List<Ingredient> ParseIngredients(Meal meal)
        {
            var ingredients = new List<Ingredient>();
            Regex regex = new Regex(@"(?<quantite>\d*[\.,]?\d+)\s*(?<unite>[^\d]+)");

            for (int i = 1; i <= 20; i++)
            {
                var propertyNameIngredient = $"StrIngredient{i}";
                var propertyNameMeasure = $"StrMeasure{i}";

                var nomIngredient = meal.GetType().GetProperty(propertyNameIngredient)?.GetValue(meal) as string;
                var mesure = meal.GetType().GetProperty(propertyNameMeasure)?.GetValue(meal) as string;

                if (!string.IsNullOrWhiteSpace(nomIngredient) && !string.IsNullOrWhiteSpace(mesure))
                {
                    var match = regex.Match(mesure);
                    if (match.Success)
                    {
                        ingredients.Add(new Ingredient
                        {
                            Nom = nomIngredient.Trim(),
                            Quantite = double.TryParse(match.Groups["quantite"].Value, out double qty) ? qty : 0,
                            Unite = match.Groups["unite"].Value.Trim()
                        });
                    }
                }
            }

            return ingredients;
        }
    }
    // Modèles pour le désérialisation des données JSON de TheMealDb
    public class MealApiResponse
    {
        public List<Meal> Meals { get; set; }
    }

    public class Meal
    {
        public string StrMeal { get; set; }
        public string StrMealThumb { get; set; }
        public string StrCategory { get; set; }
        // Définition complète des propriétés pour les ingrédients et mesures
        public string StrIngredient1 { get; set; }
        public string StrMeasure1 { get; set; }
        public string StrIngredient2 { get; set; }
        public string StrMeasure2 { get; set; }
        public string StrIngredient3 { get; set; }
        public string StrMeasure3 { get; set; }
        public string StrIngredient4 { get; set; }
        public string StrMeasure4 { get; set; }
        public string StrIngredient5 { get; set; }
        public string StrMeasure5 { get; set; }
        public string StrIngredient6 { get; set; }
        public string StrMeasure6 { get; set; }
        public string StrIngredient7 { get; set; }
        public string StrMeasure7 { get; set; }
        public string StrIngredient8 { get; set; }
        public string StrMeasure8 { get; set; }
        public string StrIngredient9 { get; set; }
        public string StrMeasure9 { get; set; }
        public string StrIngredient10 { get; set; }
        public string StrMeasure10 { get; set; }
        public string StrIngredient11 { get; set; }
        public string StrMeasure11 { get; set; }
        public string StrIngredient12 { get; set; }
        public string StrMeasure12 { get; set; }
        public string StrIngredient13 { get; set; }
        public string StrMeasure13 { get; set; }
        public string StrIngredient14 { get; set; }
        public string StrMeasure14 { get; set; }
        public string StrIngredient15 { get; set; }
        public string StrMeasure15 { get; set; }
        public string StrIngredient16 { get; set; }
        public string StrMeasure16 { get; set; }
        public string StrIngredient17 { get; set; }
        public string StrMeasure17 { get; set; }
        public string StrIngredient18 { get; set; }
        public string StrMeasure18 { get; set; }
        public string StrIngredient19 { get; set; }
        public string StrMeasure19 { get; set; }
        public string StrIngredient20 { get; set; }
        public string StrMeasure20 { get; set; }

    }
}

