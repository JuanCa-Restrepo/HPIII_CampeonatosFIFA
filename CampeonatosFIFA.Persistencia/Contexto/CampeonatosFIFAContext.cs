using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CampeonatosFIFA.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace CampeonatosFIFA.Persistencia.Contexto
{
    public class CampeonatosFIFAContext : DbContext
    {
        public CampeonatosFIFAContext(DbContextOptions<CampeonatosFIFAContext> options) : base(options)
        {

        }

        public DbSet <Seleccion> Seleciones { get; set; }
        public DbSet < Campeonato> Campeonatos { get; set; }

        void onModelCreating(ModelBuilder builder) 
        { 
          builder.Entity<Seleccion>(entidad => { 
          
          entidad.HasKey(e => e.Id);
          entidad.HasIndex(e => e.Nombre).IsUnique();
          });

          builder.Entity<Seleccion>(entidad =>
            {
              entidad.HasKey(e => e.Id);
              entidad.HasIndex(e => e.Nombre).IsUnique();
            });

            // como se define la clave foranea: campeonato depende de seleccion y de pais
            builder.Entity<Campeonato>()
                .HasOne(e => e.PaisOrganizador)
                .WithMany()
                .HasForeignKey(e => e.IdSeleccion);


        }

         

    }
}
