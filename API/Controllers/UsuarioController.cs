// using ContosoPizza.Models;
// using ContosoPizza.Services;
// using Microsoft.AspNetCore.Mvc;
// using System.Collections.Generic;

// namespace ContosoPizza.Controllers
// {
//     [ApiController]
//     [Route("[controller]")]
//     public class UsuarioController : ControllerBase
//     {
//         private readonly UsuarioService _usuarioService;

//         public UsuarioController(UsuarioService usuarioService)
//         {
//             _usuarioService = usuarioService;
//         }

//         [HttpGet("{id}")]
//         public ActionResult<Usuario> Get(int id)
//         {
//             var usuario = _usuarioService.Get(id);

//             if (usuario == null)
//             {
//                 return NotFound();
//             }

//             return usuario;
//         }

//         // Añade aquí más endpoints según sea necesario, como POST para crear usuarios, etc.
//     }
// }
