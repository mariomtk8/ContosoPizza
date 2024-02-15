namespace ContosoPizza.Models;
public class PedidoDto
{
    public int PedidoId { get; set; }
    public decimal Price { get; set; }
    public List<PizzaDto> Pizzas { get; set; }
}