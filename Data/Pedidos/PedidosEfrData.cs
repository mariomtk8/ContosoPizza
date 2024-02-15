using ContosoPizza.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

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
            return _context.Pedidos
                .Include(p => p.PedidoPizzas)
                    .ThenInclude(pp => pp.Pizza)
                .FirstOrDefault(pedido => pedido.IdPedido == Id);
        }

        public void Add(Pedidos pedido)
        {
            _context.Pedidos.Add(pedido);
            SaveChanges();
        }

        public void Delete(int id)
        {
            var pedido = _context.Pedidos.FirstOrDefault(pedido => pedido.IdPedido == id);
            if (pedido != null)
            {
                _context.Pedidos.Remove(pedido);
            }
            SaveChanges();
        }

        public List<Pedidos> GetAll()
        {
            return _context.Pedidos.ToList();
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

        // Método nuevo para obtener todos los pedidos con sus pizzas
        public List<PedidoDto> GetAllPedidosWithPizzas()
        {
            var pedidos = _context.Pedidos
                .Include(p => p.PedidoPizzas)
                    .ThenInclude(pp => pp.Pizza)
                .Select(pedido => new PedidoDto
                {
                    PedidoId = pedido.IdPedido,
                    Price = pedido.Price,
                    Pizzas = pedido.PedidoPizzas.Select(pp => new PizzaDto
                    {
                        PizzaId = pp.Pizza.Id,
                    }).ToList()
                }).ToList();

            return pedidos;
        }
    }
}
