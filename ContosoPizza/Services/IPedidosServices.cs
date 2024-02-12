using System.Dynamic;
using ContosoPizza.Models;

namespace ContosoPizza.Services
{
    public interface IPedidosServices
    {
        void Add(Pedidos pedidos);
        Pedidos Get(int id);
        void AddPizzas(int id, List<Pizza> pizza);

        void Update(Pedidos pedidos);

        void Delete(int id);

        List<Pedidos> GetAll();
    }
}
