using ContosoPizza.Models;

namespace ContosoPizza.Data
{
    public interface IPedidosData
    {
        Pedidos Get(int id);
        void Add(Pedidos pedido);
        void Update(Pedidos pedidos);

        void Delete(int id);

        List<Pedidos> GetAll();
    }
}
