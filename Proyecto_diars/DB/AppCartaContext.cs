using Microsoft.EntityFrameworkCore;
using Proyecto_diars.DB.Mapping;
using Proyecto_diars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_diars.DB
{
    public class AppCartaContext:DbContext
    {
        public DbSet<Carta> cartas { get; set; }
        public DbSet<Reserva> reservas { get;set ;}
        public DbSet<Usuario> Usuarios { get; set; }
        public AppCartaContext(DbContextOptions<AppCartaContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CartaMap());
            modelBuilder.ApplyConfiguration(new ReservaMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
        }
    }
}
