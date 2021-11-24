using SCBarakaldoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCBarakaldoAPI.Services
{
    public class EventoService
    {
        private readonly SCBarakaldoContext _sCBarakaldoContext;
        public EventoService(SCBarakaldoContext sCBarakaldoContext)
        {
            _sCBarakaldoContext = sCBarakaldoContext;
        }

        public async Task<List<Evento>> Obtener()
        {
            var resultado = _sCBarakaldoContext.Evento.ToList();
            return resultado;
        }

        public async Task<Evento> ObtenerEvento(int id)
        {
            var resultado = _sCBarakaldoContext.Evento.Where(busqueda => busqueda.EventoID == id).FirstOrDefault();
            return resultado;
        }

        public async Task<Evento> AgregarEvento(Evento _evento)
        {
            _evento.CreatedAt = DateTime.Now;
            _evento.UpdatedAt = DateTime.Now;
            _sCBarakaldoContext.Evento.Add(_evento);
            _sCBarakaldoContext.SaveChanges();
            return _evento;
        }

        public async Task<Evento> EditarEvento(Evento _evento)
        {
            var eventoBaseDatos = _sCBarakaldoContext.Evento.Where(busqueda => busqueda.EventoID == _evento.EventoID).FirstOrDefault();
            eventoBaseDatos.Titulo = _evento.Titulo;
            eventoBaseDatos.Imagen = _evento.Imagen;
            eventoBaseDatos.Descripcion = _evento.Descripcion;
            eventoBaseDatos.Resumen = _evento.Resumen;
            eventoBaseDatos.FechaInicio = _evento.FechaInicio;
            eventoBaseDatos.FechaFin = _evento.FechaFin;
            eventoBaseDatos.Publicado = _evento.Publicado;
            eventoBaseDatos.Finalizado = _evento.Finalizado;
            eventoBaseDatos.UpdatedAt = DateTime.Now;
            _sCBarakaldoContext.SaveChanges();

            return eventoBaseDatos;
        }

        public async Task<Evento> EliminarEvento(int _eventoID)
        {
            var eventoBaseDatos = _sCBarakaldoContext.Evento.Where(buequeda => buequeda.EventoID == _eventoID).FirstOrDefault();
            _sCBarakaldoContext.Evento.Remove(eventoBaseDatos);
            _sCBarakaldoContext.SaveChanges();
            return eventoBaseDatos;
        }
    }
}
