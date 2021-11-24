using SCBarakaldoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCBarakaldoAPI.Services
{
    public class UsuarioService
    {
        private readonly SCBarakaldoContext _sCBarakaldoContext;
        public UsuarioService(SCBarakaldoContext sCBarakaldoContext)
        {
            _sCBarakaldoContext = sCBarakaldoContext;
        }

        public async Task<List<Usuario>> Obtener()
        {
            var resultado = _sCBarakaldoContext.Usuario.ToList();
            return resultado;
        }

        public async Task<Usuario> ObtenerUsuario(int _usuarioID)
        {
            var resultado = _sCBarakaldoContext.Usuario.Where(busqueda => busqueda.UserID == _usuarioID).FirstOrDefault();
            return resultado;
        }

        public async Task<Usuario> AgregarUsuario(Usuario _usuario)
        {
            try
            {
                _usuario.CreatedAt = DateTime.Now;
                _usuario.UpdatedAt= DateTime.Now;
                _sCBarakaldoContext.Usuario.Add(_usuario);
                _sCBarakaldoContext.SaveChanges();
                return _usuario;
            }
            catch(Exception error)
            {
                return null;
            }
        }

        public async Task<Usuario> EditarUsuario(Usuario _usuario)
        {
            try
            {
                var usuarioBaseDatos = _sCBarakaldoContext.Usuario.Where(busqueda => busqueda.UserID == _usuario.UserID).FirstOrDefault();
                usuarioBaseDatos.Email = _usuario.Email;
                usuarioBaseDatos.Password = _usuario.Password;
                usuarioBaseDatos.Nombre = _usuario.Nombre;
                usuarioBaseDatos.Apellido = _usuario.Apellido;
                usuarioBaseDatos.Foto = _usuario.Foto;
                usuarioBaseDatos.UpdatedAt = DateTime.Now;

                _sCBarakaldoContext.SaveChanges();
                return usuarioBaseDatos;
            }
            catch(Exception error)
            {
                return null;
            }
        }

        public async Task<Usuario> EliminarUsuario(int _usuarioID)
        {
            try
            {
                var usuarioBaseDatos = _sCBarakaldoContext.Usuario.Where(busqueda => busqueda.UserID == _usuarioID).FirstOrDefault();
                _sCBarakaldoContext.Usuario.Remove(usuarioBaseDatos);
                _sCBarakaldoContext.SaveChanges();
                return usuarioBaseDatos;
            }
            catch(Exception error)
            {
                return null;
            }
        }
    }
}
