using ContosoPizza.Models;
using System.Collections.Generic;
using System.Linq;

 namespace ContosoPizza.Data
{
    public class PedidoData : IPedidosData
    {
        private List<Pedido> Pedidos { get; set; }
        private int nextId = 1;
        private readonly PizzaData _pizzaData;

        public PedidoData()
        {
            _pizzaData = new PizzaData();
            Pedidos = new List<Pedido>
            {
                new Pedido
                {
                    Id = 0,
                    Pizzas = new List<Pizza>
                    {
                        _pizzaData.Get(1), 
                    },
                    Precio = 17
                },
                new Pedido
                {
                    Id = 1,
                    Pizzas = new List<Pizza>
                    {
                        _pizzaData.Get(2), 
                    },
                    Precio = 17
                },
                new Pedido
                {
                    Id = 2,
                    Pizzas = new List<Pizza>
                    {
                        _pizzaData.Get(3), 
                    },
                    Precio = 16
                },
                new Pedido
                {
                    Id = 3,
                    Pizzas = new List<Pizza>
                    {
                        _pizzaData.Get(4), 
                    },
                    Precio = 15
                },
                new Pedido
                {
                    Id = 4,
                    Pizzas = new List<Pizza>
                    {
                        _pizzaData.Get(5), 
                    },
                    Precio = 14
                }
            };
            
        }
        
        public void Add(Pedido pedido)
        {
            pedido.Id = nextId++;
            Pedidos.Add(pedido);
        }


    public Pedido? Get(int id) => Pedidos.FirstOrDefault(p => p.Id == id);

    public void Update(Pedido pedido)
    {
        var index = Pedidos.FindIndex(p => p.Id == pedido.Id);
        if (index == -1)
            return;

        Pedidos[index] = pedido;
    }
}
}