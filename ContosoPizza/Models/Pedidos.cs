using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ContosoPizza.Models;

public class Pedidos
{
    public Pedidos() { }
    [Key]
    public int IdOrder { get; set; }
    public List<Pizza> Pizzas { get; set; } = new List<Pizza>();
    public decimal Price { get; set; }
    //[ForeignKey("Usuario")]
    //public Usuario? User { get; set; }
}