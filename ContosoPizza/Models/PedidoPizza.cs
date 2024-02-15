namespace ContosoPizza.Models;

public class PedidoPizza
{
    public int PedidoId { get; set; }
    public Pedidos Pedido { get; set; }

    public int PizzaId { get; set; }
    public Pizza Pizza { get; set; }
}
