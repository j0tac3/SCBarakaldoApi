using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SCBarakaldoAPI.Models;
using SCBarakaldoAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCBarakaldoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;
        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet("prueba")]
        public async Task<ActionResult<Usuario>> GetByUserNamePassword()
        {
            var usuario = new Usuario();
            usuario.Nombre = "Prueba";
            if (usuario == null)
                return NotFound();

            return usuario;
        }

        [HttpGet("obtener")]
        public async Task<ActionResult<List<Usuario>>> Get()
        {
            var usuario = new Usuario();
            usuario.Nombre = "Prueba";
            if (usuario == null)
                return NotFound();

            return usuario;
        }

        [HttpGet("login")]
        public async Task<ActionResult<Usuario>> GetByUserNamePassword(int usuarioID)
        {
            var usuario = await _usuarioService.ObtenerUsuario(usuarioID);
            if (usuario == null)
                return NotFound();

            return usuario;
        }

        [HttpPost]
        public async Task<ActionResult<List<Usuario>>> Post(Usuario usuario)
        {
            var resultado = await _usuarioService.AgregarUsuario(usuario);
            if (resultado != null)
                return Ok(resultado);
            else
                return BadRequest("El usuario no ha podido ser añadido");
        }

        [HttpPut]
        public async Task<ActionResult<List<Usuario>>> Put(Usuario usuario)
        {
            var resultado = await _usuarioService.EditarUsuario(usuario);

            if (resultado != null)
                return Ok(resultado);
            else
                return BadRequest("El usuario no ha podido ser editado");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Usuario>>> Delete(int id)
        {
            var resultado = await _usuarioService.EliminarUsuario(id);

            if (resultado != null)
                return Ok(resultado);
            else
                return BadRequest("El usuario no ha podido ser eliminado");

        }
    }
}
