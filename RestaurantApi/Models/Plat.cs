using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RestaurantApi.Models
{
    public class Plat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nom { get; set; }

        [StringLength(255)]
        public string ImageUrl { get; set; }

        [Required]
        [StringLength(100)]
        public string Categorie { get; set; }

        [ForeignKey("Restaurant")]
        public int RestaurantId { get; set; }
        [JsonIgnore]
        public virtual Restaurant Restaurant { get; set; }

        // Relation avec Ingredient: Un plat peut avoir plusieurs ingrédients
        public virtual List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    }
}