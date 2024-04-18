namespace RestaurantApi.Models
{
    public class PlatDetailDto
    {
        public string Nom { get; set; }
        public string ImageUrl { get; set; }
        public string Categorie { get; set; }
        public List<IngredientDto> Ingredients { get; set; }
    }
    public class IngredientDto
    {
        public string Nom { get; set; }
        public double Quantite { get; set; }
        public string Unite { get; set; }
    }
}
