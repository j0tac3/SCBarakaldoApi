using Microsoft.EntityFrameworkCore;
using SCBarakaldoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCBarakaldoAPI
{
    public class SCBarakaldoContext : DbContext
    {
        public SCBarakaldoContext(DbContextOptions<SCBarakaldoContext> options) : base(options)
        { }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Evento> Evento { get; set; }

        protected override void OnModelCreating(ModelBuilder modelCreator)
        {
            new Usuario.Mapeo(modelCreator.Entity<Usuario>());
            new Evento.Mapeo(modelCreator.Entity<Evento>());
        }
    }
}
