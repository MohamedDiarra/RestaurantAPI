using System.Collections.Generic;
using RestaurantApi.Models;

namespace RestaurantApi.Data
{
    public class DbInitializer
    {
        public static void Initialize(RestaurantDbContext context)
        {
            context.Database.EnsureCreated();
            //Regarde si la base de données a déjà été initialisée
            if (context.Restaurants.Any())
            {
                return;   // la base de données a déjà été initialisée
            }
            var restaurants = new Restaurant[]
            {
                new Restaurant{Nom="La Belle Vue", Adresse="12 rue des Lilas"},
                new Restaurant{Nom="Le Petit Jardin", Adresse="5 rue des Roses"},
                new Restaurant{Nom="Le Bon Boeuf", Adresse="3 rue des Violettes"}
            };
            foreach (Restaurant r in restaurants)
            {
                context.Restaurants.Add(r);
            }
            context.SaveChanges();
            var plats = new Plat[]
            {
                new Plat{Nom="Salade César", ImageUrl="images/plats/salade-cesar.jfif", Categorie="Entrée", RestaurantId=1},
                new Plat{Nom="Entrecôte grillée", ImageUrl="images/plats/entrecote-grille.jpeg", Categorie="Plat", RestaurantId=1},
                new Plat{Nom="Tarte aux pommes", ImageUrl="images/plats/tarte-aux-pommes.jfif", Categorie="Dessert", RestaurantId=1},
                new Plat{Nom="Salade de chèvre chaud", ImageUrl="images/plats/salade-chevre.jfif", Categorie="Entrée", RestaurantId=2},
                new Plat{Nom="Filet de bar", ImageUrl="images/plats/filet-bar.jfif", Categorie="Plat", RestaurantId=2},
                new Plat{Nom="Moelleux au chocolat", ImageUrl="images/plats/moelleux-choco.jfif", Categorie="Dessert", RestaurantId=2},
                new Plat{Nom="Salade niçoise", ImageUrl="images/plats/salade-nicoise.jfif", Categorie="Entrée", RestaurantId=3},
                new Plat{Nom="Magret de canard", ImageUrl="images/plats/magret-canard.jfif", Categorie="Plat", RestaurantId=3},
                new Plat{Nom="Tarte au citron", ImageUrl="images/plats/tarte-citron.jfif", Categorie="Dessert", RestaurantId=3}
            };
            foreach (Plat p in plats)
            {
                context.Plats.Add(p);
            }
            context.SaveChanges();
            var ingredients = new Ingredient[]
            {
                new Ingredient{Nom="Laitue", Quantite=1, Unite="tête", PlatId=1},
                new Ingredient{Nom="Croûtons", Quantite=50, Unite="g", PlatId=1},
                new Ingredient{Nom="Poulet", Quantite=150, Unite="g", PlatId=1},
                new Ingredient{Nom="Parmesan", Quantite=30, Unite="g", PlatId=1},
                new Ingredient{Nom="Huile d'olive", Quantite=1, Unite="c. à soupe", PlatId=1},
                new Ingredient{Nom="Citron", Quantite=1, Unite="c. à soupe", PlatId=1},
                new Ingredient{Nom="Sel", Quantite=1, Unite="pincée", PlatId=1},
                new Ingredient{Nom="Poivre", Quantite=1, Unite="pincée", PlatId=1},
                new Ingredient{Nom="Entrecôte", Quantite=1, Unite="pièce", PlatId=2},
                new Ingredient{Nom="Sel", Quantite=1, Unite="pincée", PlatId=2},
                new Ingredient{Nom="Poivre", Quantite=1, Unite="pincée", PlatId=2},
                new Ingredient{Nom="Pommes", Quantite=2, Unite="pièces", PlatId=3},
                new Ingredient{Nom="Pâte brisée", Quantite=1, Unite="pièce", PlatId=3},
                new Ingredient{Nom="Sucre", Quantite=50, Unite="g", PlatId=3},
                new Ingredient{Nom="Crème fraîche", Quantite=1, Unite="c. à soupe", PlatId=3},
                new Ingredient{Nom="Oeuf", Quantite=1, Unite="pièce", PlatId=3},
                new Ingredient{Nom="Chèvre", Quantite=1, Unite="bûche", PlatId=4},
                new Ingredient{Nom="Miel", Quantite=1, Unite="c. à soupe", PlatId=4},
                new Ingredient{Nom="Pignons de pin", Quantite=1, Unite="c. à soupe", PlatId=4},
                new Ingredient{Nom="Bar", Quantite=1, Unite="pièce", PlatId=5},
                new Ingredient{Nom="Sel", Quantite=1, Unite="pincée", PlatId=5},
                new Ingredient{Nom="Poivre", Quantite=1, Unite="pincée", PlatId=5},
                new Ingredient{Nom="Beurre", Quantite=1, Unite="noisette", PlatId=5},
                new Ingredient{Nom="Chocolat noir", Quantite=100, Unite="g", PlatId=6},
                new Ingredient{Nom="Sucre", Quantite=50, Unite="g", PlatId=6},
                new Ingredient{Nom="Oeuf", Quantite=1, Unite="pièce", PlatId=6},
                new Ingredient{Nom="Farine", Quantite=1, Unite="c. à soupe", PlatId=6},
                new Ingredient{Nom="Salade", Quantite=1, Unite="tête", PlatId=7},
                new Ingredient{Nom="Tomate", Quantite=1, Unite="pièce", PlatId=7},
                new Ingredient{Nom="Oeuf", Quantite=1, Unite="pièce", PlatId=7},
                new Ingredient{Nom="Anchois", Quantite=2, Unite="filets", PlatId=7},
                new Ingredient{Nom="Thon", Quantite=50, Unite="g", PlatId=7},
                new Ingredient{Nom="Haricots verts", Quantite=50, Unite="g", PlatId=7},
                new Ingredient{Nom="Olives", Quantite=5, Unite="pièces", PlatId=7},
                new Ingredient{Nom="Magret de canard", Quantite=1, Unite="pièce", PlatId=8},
                new Ingredient{Nom="Sel", Quantite=1, Unite="pincée", PlatId=8},
                new Ingredient{Nom="Poivre", Quantite=1, Unite="pincée", PlatId=8},
                new Ingredient{Nom="Pommes", Quantite=2, Unite="pièces", PlatId=9},
                new Ingredient{Nom="Pâte brisée", Quantite=1, Unite="pièce", PlatId=9},
                new Ingredient{Nom="Sucre", Quantite=50, Unite="g", PlatId=9},
                new Ingredient{Nom="Crème fraîche", Quantite=1, Unite="c. à soupe", PlatId=9},
                new Ingredient{Nom="Oeuf", Quantite=1, Unite="pièce", PlatId=9}
                };
            foreach (Ingredient i in ingredients)
            {
                context.Ingredients.Add(i);
            }
            context.SaveChanges();
        }
                
    }
}
