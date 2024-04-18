using Microsoft.EntityFrameworkCore;
using RestaurantApi.Models;

public class RestaurantDbContext : DbContext
{
    public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options)
    {
    }

    public DbSet<Restaurant> Restaurants { get; set; }
    public DbSet<Plat> Plats { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuration pour Restaurant
        modelBuilder.Entity<Restaurant>()
            .HasKey(r => r.Id);
        modelBuilder.Entity<Restaurant>()
            .Property(r => r.Nom)
            .IsRequired()
            .HasMaxLength(100);
        modelBuilder.Entity<Restaurant>()
            .Property(r => r.Adresse)
            .IsRequired()
            .HasMaxLength(200);
        modelBuilder.Entity<Restaurant>()
            .HasMany(r => r.Plats)
            .WithOne(p => p.Restaurant)
            .HasForeignKey(p => p.RestaurantId)
            .OnDelete(DeleteBehavior.Cascade);

        // Configuration pour Plat
        modelBuilder.Entity<Plat>()
            .HasKey(p => p.Id);
        modelBuilder.Entity<Plat>()
            .Property(p => p.Nom)
            .IsRequired()
            .HasMaxLength(100);
        modelBuilder.Entity<Plat>()
            .Property(p => p.Categorie)
            .IsRequired()
            .HasMaxLength(100);
        modelBuilder.Entity<Plat>()
            .Property(p => p.ImageUrl)
            .HasMaxLength(255);
        modelBuilder.Entity<Plat>()
        .HasMany(p => p.Ingredients)
        .WithOne(i => i.Plat)
        .HasForeignKey(i => i.PlatId)
        .OnDelete(DeleteBehavior.Cascade);

        // Configuration pour Ingredient
        modelBuilder.Entity<Ingredient>()
            .HasKey(i => i.Id);
        modelBuilder.Entity<Ingredient>()
            .Property(i => i.Nom)
            .IsRequired()
            .HasMaxLength(100);
        modelBuilder.Entity<Ingredient>()
           .Property(i => i.Quantite); // Assurez-vous que ce champ est bien configuré en fonction de vos besoins
        modelBuilder.Entity<Ingredient>()
            .Property(i => i.Unite)
            .IsRequired()
            .HasMaxLength(50);
   
    }
}