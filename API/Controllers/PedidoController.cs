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
        public IActionResult Create([FromBody] Pedidos pedido)
        {
            _pedidosService.Add(pedido);
            // Aquí se asume que el pedido ya contiene la propiedad IdPedido configurada correctamente después de agregarlo
            return CreatedAtAction(nameof(Get), new { id = pedido.IdPedido }, pedido);
        }

        [HttpPost("{pedidoId}/AddPizzas")]
        public IActionResult AddPizzas(int pedidoId, [FromBody] List<Pizza> pizzas)
        {
            var existingPedido = _pedidosService.Get(pedidoId);
            if (existingPedido == null)
            {
                return NotFound();
            }

            _pedidosService.AddPizzas(pedidoId, pizzas);

            // No se retorna el pedido en sí para seguir las buenas prácticas de la API REST en operaciones POST
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Pedidos pedido)
        {
            if (id != pedido.IdPedido)
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
