using ContosoPizza.Models;
using ContosoPizza.Data;
using System.Collections.Generic;

namespace ContosoPizza.Services
{
    public class UsuarioService
    {
        private readonly IUsuariosData _usuariosData;

        public UsuarioService(IUsuariosData usuariosData)
        {
            _usuariosData = usuariosData;
        }

        public Usuario? Get(int id)
        {
            return _usuariosData.Get(id);
        }

        public List<Usuario> GetAll()
        {
            return _usuariosData.GetAll();
        }

        public void Add(Usuario usuario)
        {
            _usuariosData.Add(usuario);
        }

        public void Delete(int id)
        {
            _usuariosData.Delete(id);
        }

        public void Update(Usuario usuario)
        {
            _usuariosData.Update(usuario);
        }

        public void AddPedido(int usuarioId, Pedido pedido)
        {
            var usuario = _usuariosData.Get(usuarioId);
            if (usuario != null)
            {
                usuario.Pedidos.Add(pedido);
                _usuariosData.Update(usuario);
            }
        }
    }
}