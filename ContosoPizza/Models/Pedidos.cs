using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ContosoPizza.Models
{
    public class Pedidos
    {
        [Key]
        public int IdPedido { get; set; }

        public List<PedidoPizza> PedidoPizzas { get; set; } = new List<PedidoPizza>();

        public decimal Price { get; set; }
    }
}
