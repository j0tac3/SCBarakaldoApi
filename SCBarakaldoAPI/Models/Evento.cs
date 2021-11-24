using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCBarakaldoAPI.Models
{
    public class Evento
    {
        public int EventoID { get; set; }
        public string Titulo { get; set; }
        public byte[] Imagen { get; set; }
        public string Descripcion { get; set; }
        public string Resumen { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public bool Publicado { get; set; }
        public bool Finalizado { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Usuario Usuario { get; set; }

        public class Mapeo
        {
            public Mapeo(EntityTypeBuilder<Evento> mapeoEvento)
            {
                mapeoEvento.HasKey(x => x.EventoID);
                mapeoEvento.HasOne(x => x.Usuario);
            }
        }
    }
}
