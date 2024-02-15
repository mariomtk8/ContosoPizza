using ContosoPizza.Models;
using ContosoPizza.Data;
using System.Collections.Generic;
using System.Linq;

namespace ContosoPizza.Services
{
    public class PedidosService : IPedidosServices
    {
        private readonly IPedidosData _pedidosData;

        public PedidosService(IPedidosData pedidosData)
        {
            _pedidosData = pedidosData;
        }

        public void Add(Pedidos pedido)
        {
            _pedidosData.Add(pedido);
        }

        public Pedidos Get(int id)
        {
            return _pedidosData.Get(id);
        }

        public void AddPizzas(int pedidoId, List<Pizza> pizzas)
        {
            var pedido = _pedidosData.Get(pedidoId);

            if (pedido != null && pizzas != null)
            {
                // Asegúrate de que la colección PedidoPizzas no sea nula
                pedido.PedidoPizzas ??= new List<PedidoPizza>();

                foreach (var pizza in pizzas)
                {
                    // Añade cada pizza al pedido mediante la entidad intermedia PedidoPizza
                    var pedidoPizza = new PedidoPizza
                    {
                        PedidoId = pedidoId,
                        PizzaId = pizza.Id,
                        // Opcionalmente, puedes añadir más propiedades si la entidad PedidoPizza las requiere
                    };
                    pedido.PedidoPizzas.Add(pedidoPizza);
                }

                // Recalcula el precio del pedido basado en las pizzas añadidas
                pedido.Price += pizzas.Sum(p => p.Price);
                
                _pedidosData.Update(pedido);
            }
        }

        public void Update(Pedidos pedido)
        {
            _pedidosData.Update(pedido);
        }
        
        public void Delete(int id)
        {
            _pedidosData.Delete(id);
        }

        public List<Pedidos> GetAll()
        {
            return _pedidosData.GetAll();
        }       
    }
}
