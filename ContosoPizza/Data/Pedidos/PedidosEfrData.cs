using ContosoPizza.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.Data
{
    public class PedidosEfrData : IPedidosData
    {
        private readonly ContosoPizzaAppContext _context;

        public PedidosEfrData(ContosoPizzaAppContext context)
        {
            _context = context;
        }

        public Pedidos Get(int Id)
        {
            return _context.Pedidos.FirstOrDefault(pedido => pedido.IdOrder == Id);
        }

        public void Add(Pedidos pedido)
        {
            _context.Pedidos.Add(pedido);
            SaveChanges();
        }

        public void Delete(int id)
        {
            var pedido = _context.Pedidos.FirstOrDefault(pedido => pedido.IdOrder == id);
            if (pedido != null)
            {
                _context.Pedidos.Remove(pedido);
            }
            SaveChanges();
        }

        public List<Pedidos> GetAll()
        {
            return _context.Pedidos.ToList();
            SaveChanges();
        }

        public void Update(Pedidos pedido)
        {
            _context.Pedidos.Update(pedido);
            SaveChanges();
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}