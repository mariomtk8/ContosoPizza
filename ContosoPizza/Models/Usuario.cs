using ContosoPizza.Models;

namespace ContosoPizza.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; }
        public string Direccion { get; set; }
        public List<Pedido> Pedidos { get; set; } = new List<Pedido>();
    }
}