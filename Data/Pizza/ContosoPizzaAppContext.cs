using Microsoft.EntityFrameworkCore;
using ContosoPizza.Models;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PedidoPizza>()
                .HasKey(pp => new { pp.PedidoId, pp.PizzaId });

            modelBuilder.Entity<PedidoPizza>()
                .HasOne(pp => pp.Pedido)
                .WithMany(p => p.PedidoPizzas) // Asegúrate de tener una propiedad adecuada en Pedidos
                .HasForeignKey(pp => pp.PedidoId);

            modelBuilder.Entity<PedidoPizza>()
                .HasOne(pp => pp.Pizza)
                .WithMany(p => p.PedidoPizzas)
                .HasForeignKey(pp => pp.PizzaId);

            modelBuilder.Entity<Pizza>().HasData(
                new Pizza { Id = 1, Name = "Margherita", Price = 8.50m },
                new Pizza { Id = 2, Name = "Hawaiana", Price = 9.99m },
                new Pizza { Id = 3, Name = "Cuatro Estaciones", Price = 10.75m },
                new Pizza { Id = 4, Name = "Barbacoa", Price = 11.25m },
                new Pizza { Id = 5, Name = "Vegana", Price = 12.00m }
            );

            modelBuilder.Entity<Ingredientes>().HasData(

                new Ingredientes { IdIngredient = 1, PizzaId = 1, NameIngredient = "Salsa de Tomate", Price = 0.5m, IsGlutenFree = true },
                new Ingredientes { IdIngredient = 2, PizzaId = 1, NameIngredient = "Queso Mozzarella", Price = 1.0m, IsGlutenFree = true },
                new Ingredientes { IdIngredient = 3, PizzaId = 1, NameIngredient = "Albahaca", Price = 0.3m, IsGlutenFree = true },

                new Ingredientes { IdIngredient = 4, PizzaId = 2, NameIngredient = "Jamón", Price = 1.2m, IsGlutenFree = false },
                new Ingredientes { IdIngredient = 5, PizzaId = 2, NameIngredient = "Piña", Price = 0.8m, IsGlutenFree = true },

                new Ingredientes { IdIngredient = 6, PizzaId = 3, NameIngredient = "Hongos", Price = 0.6m, IsGlutenFree = true },
                new Ingredientes { IdIngredient = 7, PizzaId = 3, NameIngredient = "Alcachofas", Price = 0.7m, IsGlutenFree = true },
                new Ingredientes { IdIngredient = 8, PizzaId = 3, NameIngredient = "Aceitunas", Price = 0.5m, IsGlutenFree = true },

                new Ingredientes { IdIngredient = 9, PizzaId = 4, NameIngredient = "Carne de Res", Price = 1.5m, IsGlutenFree = false },
                new Ingredientes { IdIngredient = 10, PizzaId = 4, NameIngredient = "Salsa Barbacoa", Price = 0.9m, IsGlutenFree = true },

                new Ingredientes { IdIngredient = 11, PizzaId = 5, NameIngredient = "Queso Vegano", Price = 2.0m, IsGlutenFree = true },
                new Ingredientes { IdIngredient = 12, PizzaId = 5, NameIngredient = "Pimiento", Price = 0.4m, IsGlutenFree = true },
                new Ingredientes { IdIngredient = 13, PizzaId = 5, NameIngredient = "Cebolla Morada", Price = 0.3m, IsGlutenFree = true },
                new Ingredientes { IdIngredient = 14, PizzaId = 5, NameIngredient = "Calabacín", Price = 0.45m, IsGlutenFree = true }
            );
            
            modelBuilder.Entity<Pedidos>().HasData(
                new Pedidos { IdPedido = 1, Price = 100.00m },
                new Pedidos { IdPedido = 2, Price = 150.00m }
    );
            modelBuilder.Entity<PedidoPizza>().HasData(

                new PedidoPizza { PedidoId = 1, PizzaId = 1 },
                new PedidoPizza { PedidoId = 1, PizzaId = 2 },
                new PedidoPizza { PedidoId = 2, PizzaId = 1 }
            );
        }
    }
}
