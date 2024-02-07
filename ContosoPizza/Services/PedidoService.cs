    using ContosoPizza.Models;
    using ContosoPizza.Data;
    using System.Collections.Generic;

    namespace ContosoPizza.Services;

    public class PedidoService
    {
        private readonly IPedidosData _pedidoData;

        public PedidoService(IPedidosData pedidoData)
        {
            _pedidoData = pedidoData;
        }



        public Pedido? Get(int id)
        {
            return _pedidoData.Get(id);
        }

        public void Add(Pedido pedido)
        {
            if (pedido == null)
    {
        throw new ArgumentNullException(nameof(pedido));
    }
    if (pedido.Usuario == null)
    {
        throw new InvalidOperationException("El pedido debe tener un usuario asociado.");
    }
            _pedidoData.Add(pedido);
        }
    
        public void Update(Pedido pedido)
        {
            _pedidoData.Update(pedido);
        }

    
        public void AddPizzas(int pedidoId, List<Pizza> pizzas)
        {
            var pedido = _pedidoData.Get(pedidoId);
            if (pedido != null)
            {
                foreach (var pizza in pizzas)
                {
                    pedido.Pizzas.Add(pizza);
                }
                _pedidoData.Update(pedido);
            }
        }
    }



