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
    public class EventoController : ControllerBase
    {

        private readonly EventoService _eventoService;
        public EventoController(EventoService eventoService)
        {
            _eventoService = eventoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Evento>>> Get()
        {
            var listUsuario = await _eventoService.Obtener();
            if (listUsuario.Count < 0)
                return NotFound();

            return Ok(listUsuario);
        }

        [HttpGet("login")]
        public async Task<ActionResult<Evento>> GetByUserNamePassword(int usuarioID)
        {
            var usuario = await _eventoService.ObtenerEvento(usuarioID);
            if (usuario == null)
                return NotFound();

            return usuario;
        }

        [HttpPost]
        public async Task<ActionResult<List<Evento>>> Post(Evento usuario)
        {
            var resultado = await _eventoService.AgregarEvento(usuario);
            if (resultado != null)
                return Ok(resultado);
            else
                return BadRequest("El usuario no ha podido ser añadido");
        }

        [HttpPut]
        public async Task<ActionResult<List<Evento>>> Put(Evento usuario)
        {
            var resultado = await _eventoService.EditarEvento(usuario);

            if (resultado != null)
                return Ok(resultado);
            else
                return BadRequest("El usuario no ha podido ser editado");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Evento>>> Delete(int id)
        {
            var resultado = await _eventoService.EliminarEvento(id);

            if (resultado != null)
                return Ok(resultado);
            else
                return BadRequest("El usuario no ha podido ser eliminado");

        }
    }
}
