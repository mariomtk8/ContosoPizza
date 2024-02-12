using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ContosoPizza.Models;

public class Ingredientes
{
    public Ingredientes() { }
    [Key]
    public int IdIngredient { get; set; }
    public string NameIngredient { get; set; }
    public int PizzaId { get; set; }
    public decimal Price { get; set; }
    public bool IsGlutenFree { get; set; }
}