using Microsoft.EntityFrameworkCore;
using RestaurantApi.Data;
using RestaurantApi.Models;
using RestaurantApi.Services;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);

// Ajouter et configurer le service DbContext avec SQL Server
builder.Services.AddDbContext<RestaurantDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
// Ajoute les services pour les contrôleurs et configure les options JSON
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    options.JsonSerializerOptions.WriteIndented = true;  // Pour un JSON mieux formaté
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Ajouter les services de repository de la couche de données
builder.Services.AddScoped<IRestaurantRepository, RestaurantRepository>();
builder.Services.AddScoped<IPlatRepository, PlatRepository>();
builder.Services.AddScoped<IIngredientRepository, IngredientRepository>();
// Ajouter les services de la couche de logique métier
builder.Services.AddScoped<RestaurantService>();
builder.Services.AddScoped<PlatService>();
builder.Services.AddScoped<IngredientService>();
builder.Services.AddHttpClient<TheMealDbService>();



var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

// Ajouter cette partie pour initialiser la base de données avec des données d'entrée
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<RestaurantDbContext>();
    DbInitializer.Initialize(context);
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
