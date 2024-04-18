using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RestaurantApi.Models
{
    public class Ingredient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nom { get; set; }

        [Required]
        public double Quantite { get; set; }

        [Required]
        [StringLength(50)]
        public string Unite { get; set; }

        [ForeignKey("Plat")]
        public int PlatId { get; set; }
        [JsonIgnore]
        public virtual Plat Plat { get; set; }
    }
}