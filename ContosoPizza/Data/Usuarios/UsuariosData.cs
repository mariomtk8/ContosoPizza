// using ContosoPizza.Models;
// using System.Collections.Generic;
// using System.Linq;

// namespace ContosoPizza.Data
// {
//     public class UsuariosData : IUsuariosData
//     {
//         private List<Usuario> usuarios = new List<Usuario>();

//         public UsuariosData()
//         {
//             usuarios.Add(new Usuario { Id = 1, NombreCompleto = "Juan Pérez", Direccion = "Calle Falsa 123" });
//             usuarios.Add(new Usuario { Id = 2, NombreCompleto = "Ana López", Direccion = "Avenida Siempre Viva 456" });
//             usuarios.Add(new Usuario { Id = 3, NombreCompleto = "Carlos García", Direccion = "Boulevard de los Sueños 789" });
//             usuarios.Add(new Usuario { Id = 4, NombreCompleto = "María Fernández", Direccion = "Plaza Central 101" });
//             usuarios.Add(new Usuario { Id = 5, NombreCompleto = "Luis Rodríguez", Direccion = "Calle Nueva 202" });
//             usuarios.Add(new Usuario { Id = 6, NombreCompleto = "Sofía Martínez", Direccion = "Avenida del Parque 303" });
//             usuarios.Add(new Usuario { Id = 7, NombreCompleto = "David Jiménez", Direccion = "Camino Largo 404" });
//         }

//         public Usuario Get(int id)
//         {
//             return usuarios.FirstOrDefault(u => u.Id == id);
//         }

//         public List<Usuario> GetAll()
//         {
//             return usuarios;
//         }

//         public void Add(Usuario usuario)
//         {
//             // Asumiendo que el ID se autoincrementa y es único
//             usuario.Id = usuarios.Count + 1;
//             usuarios.Add(usuario);
//         }

//         public void Delete(int id)
//         {
//             var usuario = Get(id);
//             if (usuario != null)
//             {
//                 usuarios.Remove(usuario);
//             }
//         }

//         public void Update(Usuario usuario)
//         {
//             var index = usuarios.FindIndex(u => u.Id == usuario.Id);
//             if (index != -1)
//             {
//                 usuarios[index] = usuario;
//             }
//         }

//         public void AddPedido(int usuarioId, Pedido pedido)
//         {
//             var usuario = Get(usuarioId);
//             if (usuario != null)
//             {
//                 usuario.Pedidos.Add(pedido);
//                 Update(usuario);
//             }
//         }
//     }
// }
