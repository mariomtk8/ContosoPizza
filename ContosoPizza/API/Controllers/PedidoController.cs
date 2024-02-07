using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ContosoPizza.Controllers{
    [ApiController]
    [Route("[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly PedidoService _pedidosService;

        public PedidoController(PedidoService pedidosService)
        {
            _pedidosService = pedidosService;
        }

        [HttpGet("{id}")]
        public ActionResult<Pedido> Get(int id)
        {
            var pedido = _pedidosService.Get(id);

            if (pedido == null)
                return NotFound();

            return pedido;
        }
        [HttpPost]
        public ActionResult<Pedido> Post([FromBody] Pedido nuevoPedido)
        {
            _pedidosService.Add(nuevoPedido);
            return CreatedAtAction(nameof(Get), new { id = nuevoPedido.Id }, nuevoPedido);
        }
    }
}
