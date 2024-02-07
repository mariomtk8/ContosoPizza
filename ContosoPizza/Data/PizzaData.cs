using ContosoPizza.Models;

namespace ContosoPizza.Data;

public class PizzaData : IPizzaData
{
    public List<Pizza> Pizzas { get; set; }
    public int nextId = 3;
    public PizzaData()
    {
        Pizzas = new List<Pizza>
        {
        new Pizza { Id = 1,
            Name = "Classic Italian",
            Price = 12,
            IsGlutenFree = false,
            Ingredientes = new List<Ingrediente>
            {
            new Ingrediente{IngredienteId = 0,Nombre = "Queso Mozzarella"},
            new Ingrediente{IngredienteId = 1,Nombre = "Salsa de Tomate"},
            new Ingrediente{IngredienteId = 2,Nombre = "Tomates Cherry"},
            new Ingrediente{IngredienteId = 3,Nombre = "Albahaca"},
            new Ingrediente{IngredienteId = 6,Nombre = "Orégano"},
            }

            },
        new Pizza { 
            Id = 2, 
            Name = "Veggie",
            Price = 12,
            IsGlutenFree = true,
            Ingredientes = new List<Ingrediente>
                {   
            new Ingrediente {IngredienteId = 0, Nombre = "Queso Mozzarella"},
            new Ingrediente{IngredienteId = 1,Nombre = "Salsa de Tomate"},
            new Ingrediente{IngredienteId = 2,Nombre = "Tomates Cherry"},
            new Ingrediente{IngredienteId = 4,Nombre = "Cebolla"},
            new Ingrediente{IngredienteId = 5,Nombre = "Champiñones"},
            new Ingrediente{IngredienteId = 7,Nombre = "Aceitunas Negras"},
            new Ingrediente{IngredienteId = 8,Nombre = "Alcachofas"},
                }
            },
        new Pizza { 
            Id = 3, 
            Name = "Hawaiian",
            Price = 11,
            IsGlutenFree = false,
            Ingredientes = new List<Ingrediente>
            {
                new Ingrediente { IngredienteId = 0, Nombre = "Queso Mozzarella" },
                new Ingrediente { IngredienteId = 1, Nombre = "Salsa de Tomate" },
                new Ingrediente { IngredienteId = 9, Nombre = "Jamón" },
                new Ingrediente { IngredienteId = 10, Nombre = "Piña" }
            }
        },
        new Pizza { 
            Id = 4, 
            Name = "Pepperoni",
            Price = 10,
            IsGlutenFree = false,
            Ingredientes = new List<Ingrediente>
            {
                new Ingrediente { IngredienteId = 0, Nombre = "Queso Mozzarella" },
                new Ingrediente { IngredienteId = 1, Nombre = "Salsa de Tomate" },
                new Ingrediente { IngredienteId = 11, Nombre = "Pepperoni" }
            }
        },
        new Pizza { 
            Id = 5, 
            Name = "Margherita",
            Price = 9,
            IsGlutenFree = false,
            Ingredientes = new List<Ingrediente>
            {
                new Ingrediente { IngredienteId = 0, Nombre = "Queso Mozzarella" },
                new Ingrediente { IngredienteId = 1, Nombre = "Salsa de Tomate" },
                new Ingrediente { IngredienteId = 3, Nombre = "Albahaca" }
            }
        }
    };
}

    public List<Pizza> GetAll() => Pizzas;

    public Pizza? Get(int id) => Pizzas.FirstOrDefault(p => p.Id == id);

    public void Add(Pizza Pizza)
    {
        Pizza.Id = nextId++;
        Pizzas.Add(Pizza);
    }

    public void Delete(int id)
    {
        var pizza = Get(id);
        if (pizza is null)
            return;

        Pizzas.Remove(pizza);
    }

    public void Update(Pizza pizza)
    {
        var index = Pizzas.FindIndex(p => p.Id == pizza.Id);
        if (index == -1)
            return;

        Pizzas[index] = pizza;
    }
}
