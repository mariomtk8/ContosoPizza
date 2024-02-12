using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ContosoPizza.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidosController : ControllerBase
    {
        private readonly PedidosService _pedidosService;

        public PedidosController(PedidosService pedidosService)
        {
            _pedidosService = pedidosService;
        }

        [HttpGet("{id}")]
        public ActionResult<Pedidos> Get(int id)
        {
            var pedido = _pedidosService.Get(id);

            if (pedido == null)
                return NotFound();

            return pedido;
        }

        [HttpPost]
        public IActionResult Create(Pedidos pedido)
        {
            if (pedido.Pizzas != null && pedido.Pizzas.Count > 0)
            {
                pedido.Price = pedido.Pizzas.Sum(p => p.Price);
            }

            _pedidosService.Add(pedido);
            return CreatedAtAction(nameof(Get), new { id = pedido.IdOrder }, pedido);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Pedidos pedido)
        {
            if (id != pedido.IdOrder)
                return BadRequest();

            var existingPedido = _pedidosService.Get(id);
            if (existingPedido == null)
                return NotFound();

            _pedidosService.Update(pedido);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pedido = _pedidosService.Get(id);

            if (pedido == null)
                return NotFound();

            _pedidosService.Delete(id);

            return NoContent();
        }

        [HttpGet]
        public ActionResult<List<Pedidos>> GetAll()
        {
            var pedidos = _pedidosService.GetAll();
            return Ok(pedidos);
        }

    }
}
