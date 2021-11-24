using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCBarakaldoAPI.Models
{
    public class Usuario
    {
        public int UserID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public byte[] Foto { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public class Mapeo
        {
            public Mapeo(EntityTypeBuilder<Usuario> mapeoUsuario)
            {
                mapeoUsuario.HasKey(x => x.UserID);
            }
        }
    }
}
