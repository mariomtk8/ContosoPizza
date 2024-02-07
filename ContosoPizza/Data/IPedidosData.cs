using System.Dynamic;
using ContosoPizza.Models;

namespace ContosoPizza.Data
{
    public interface IPedidosData
    {
        Pedido Get(int id);
        void Add(Pedido pedido);
        void Update(Pedido pedidos);
    }
}