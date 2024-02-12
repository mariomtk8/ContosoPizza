using ContosoPizza.Models;
using ContosoPizza.Data;
using System.Collections.Generic;

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

            if (pedido != null)
            {
                pedido.Pizzas.AddRange(pizzas);
                pedido.Price = pedido.Pizzas.Sum(p => p.Price);
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
