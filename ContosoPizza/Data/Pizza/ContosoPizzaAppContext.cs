using Microsoft.EntityFrameworkCore;
using ContosoPizza.Models;
using Microsoft.Extensions.Configuration;

namespace ContosoPizza.Data
{
    public class ContosoPizzaAppContext : DbContext
    {

        public ContosoPizzaAppContext(DbContextOptions<ContosoPizzaAppContext> options)
            : base(options)
        {

        }

        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Ingredientes> Ingredientes { get; set; }
        public DbSet<Pedidos> Pedidos { get; set; }

        // public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pizza>().HasData(
                new Pizza { Id = 1, Name = "Classic Italian", Price = 7.02m },
                new Pizza { Id = 2, Name = "Vegetariana", Price = 6.77m },
                new Pizza { Id = 3, Name = "Pepperoni", Price = 9.12m },
                new Pizza { Id = 4, Name = "8 Quesos", Price = 10.50m }
            );
            modelBuilder.Entity<Ingredientes>().HasData(

                new Ingredientes { IdIngredient = 1, PizzaId = 1, NameIngredient = "Tomate", Price = 0.22m, IsGlutenFree = true },
                new Ingredientes { IdIngredient = 2, PizzaId = 1, NameIngredient = "Prosciutto", Price = 1.3m, IsGlutenFree = false },
                new Ingredientes { IdIngredient = 3, PizzaId = 1, NameIngredient = "Queso Parmesano", Price = 2.5m, IsGlutenFree = true },
                new Ingredientes { IdIngredient = 4, PizzaId = 1, NameIngredient = "Aceite de Oliva", Price = 3.0m, IsGlutenFree = true },

                new Ingredientes { IdIngredient = 5, PizzaId = 2, NameIngredient = "Tomate", Price = 0.22m,IsGlutenFree = true },
                new Ingredientes { IdIngredient = 6, PizzaId = 2, NameIngredient = "Espinaca",Price = 0.3m, IsGlutenFree = true },
                new Ingredientes { IdIngredient = 7, PizzaId = 2, NameIngredient = "Champiñones", Price = 0.25m, IsGlutenFree = true },

                new Ingredientes { IdIngredient = 8, PizzaId = 3, NameIngredient = "Tomate", Price = 0.22m,  IsGlutenFree = true },
                new Ingredientes { IdIngredient = 9, PizzaId = 3, NameIngredient = "Pepperoni", Price = 1.5m, IsGlutenFree = false },
                new Ingredientes { IdIngredient = 10, PizzaId = 3, NameIngredient = "Oregano",Price = 0.1m, IsGlutenFree = true },

                new Ingredientes { IdIngredient = 11, PizzaId = 4, NameIngredient = "Tomate", Price = 0.22m, IsGlutenFree = true },
                new Ingredientes { IdIngredient = 12, PizzaId = 4, NameIngredient = "Queso Mozzarella", Price = 2.0m,  IsGlutenFree = true },
                new Ingredientes { IdIngredient = 13, PizzaId = 4, NameIngredient = "Queso Cheddar", Price = 1.5m, IsGlutenFree = true },
                new Ingredientes { IdIngredient = 14, PizzaId = 4, NameIngredient = "Queso Gouda", Price = 1.8m,  IsGlutenFree = true },
                new Ingredientes { IdIngredient = 15, PizzaId = 4, NameIngredient = "Queso Brie" ,Price = 2.2m, IsGlutenFree = true },
                new Ingredientes { IdIngredient = 16, PizzaId = 4, NameIngredient = "Queso Roquefort",  Price = 3.5m, IsGlutenFree = true },
                new Ingredientes { IdIngredient = 17, PizzaId = 4, NameIngredient = "Queso Gruyere",  Price = 2.6m,  IsGlutenFree = true },
                new Ingredientes { IdIngredient = 18, PizzaId = 4, NameIngredient = "Queso Emmental",  Price = 2.3m,  IsGlutenFree = true }
            );
        }
    }
}
