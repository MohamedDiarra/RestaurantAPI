using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RestaurantApi.Models
{
    public class Restaurant
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nom { get; set; }

        [Required]
        [StringLength(200)]
        public string Adresse { get; set; }

        // Relation avec Plat: Un restaurant peut avoir plusieurs plats
        public virtual List<Plat> Plats { get; set; } = new List<Plat>();

    }
}
