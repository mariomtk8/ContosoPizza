using System.ComponentModel.DataAnnotations;
namespace ContosoPizza.Models
{

    public class Pizza
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public List<Ingredientes> Ingredients { get; set; }

        public List<PedidoPizza> PedidoPizzas { get; set; } = new List<PedidoPizza>();
    }
}