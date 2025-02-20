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

        // Contructor de las clases
        public DbSet <Seleccion> Seleciones { get; set; }
        public DbSet < Campeonato> Campeonatos { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<GrupoPais> GrupoPaises { get; set; }
        public DbSet <Fase> Fases { get; set; }
        public DbSet <Ciudad> Ciudad { get; set; }
        public DbSet<Estadio> Estadios { get; set; }
        public DbSet<Encuentro> encuentros { get; set; }



        void onModelCreating(ModelBuilder builder) 
        { 
            //Builder de seleccion
          builder.Entity<Seleccion>(entidad => { 
          
          entidad.HasKey(e => e.Id);
          entidad.HasIndex(e => e.Nombre).IsUnique();
          });

            //____________________________________________________________________________________________________
            //Builder de campeonato
            builder.Entity<Campeonato>(entidad =>
            {
              entidad.HasKey(e => e.Id);
              entidad.HasIndex(e => e.Nombre).IsUnique();
            });
                    // Aplicar la clave foranea a campeonato
                    // como se define la clave foranea: campeonato depende de seleccion osea de pais
                    builder.Entity<Campeonato>()
                    .HasOne(e => e.PaisOrganizador)
                    .WithMany()
                    .HasForeignKey(e => e.IdSeleccion);
            //_____________________________________________________________________________________________________

            //Builder de grupo
            builder.Entity<Grupo>(entidad =>
            {
                entidad.HasKey(e => e.Id);
                entidad.HasIndex(e => e.Nombre).IsUnique();
            });
                    //Aplicar la clave foranea a grupo
                    // como se define la clave foranea: grupo depende de campeonato
                    builder.Entity<Grupo>()
                        .HasOne(e => e.Campeonato)
                        .WithMany()
                        .HasForeignKey(e => e.IdCampeonato);

            //_____________________________________________________________________________________________________
            //Builder de grupo pais
            builder.Entity<GrupoPais>(entidad =>
            {
                entidad.HasKey(e => new { e.IdGrupo, e.IdPais });
                
            });
                    //Aplicar la clave foranea a grupo pais
                    builder.Entity<GrupoPais>()
                        .HasOne(e => e.Grupo)               
                        .WithMany()
                        .HasForeignKey(e => e.IdGrupo);

                    builder.Entity<GrupoPais>()
                        .HasOne(e => e.Seleccion)
                        .WithMany()
                        .HasForeignKey(e => e.IdPais);
            //____________________________________________________________________________________________________
            //Builder de fase   
            builder.Entity<Fase>(entidad =>
            {
                entidad.HasKey(e => e.Id);
                entidad.HasIndex(e => e.Nombre).IsUnique();
            });

            //_____________________________________________________________________________________________________
            //Builder de ciudad
           builder.Entity<Ciudad>(entidad =>
           {
               entidad.HasKey(e => e.Id);
               entidad.HasIndex(e => e.IdPais);
               entidad.HasIndex(e => e.Nombre).IsUnique();
           });

                    //Aplicar clave foranea a ciudad
                    builder.Entity<Ciudad>()
                        .HasOne(e => e.Pais)
                        .WithMany()
                        .HasForeignKey(e => e.IdPais);

            //_____________________________________________________________________________________________________
            // Builder de estadio
            builder.Entity<Estadio>(entidad => {
                entidad.HasKey(e => e.Id);
                entidad.HasIndex(e => e.IdCiudad);
                entidad.HasIndex(e => e.Nombre).IsUnique();
            });
                    //Aplicar clave foranea a estadio
                    builder.Entity<Estadio>()
                        .HasOne(e => e.Ciudad)
                        .WithMany()
                        .HasForeignKey(e => e.IdCiudad);
            //_____________________________________________________________________________________________________
            // Builder de encuentro
            
            builder.Entity<Encuentro>(entidad =>
            {
                entidad.HasKey(e => e.Id);
                entidad.HasIndex(e => e.IdPais1).IsUnique();
                entidad.HasIndex(e => e.IdPais2).IsUnique();               
                entidad.HasIndex(e => e.IdEstadio);
                entidad.HasIndex(e => e.IdFase);                
                entidad.HasIndex(e => e.IdCampeonato);
                entidad.HasIndex(e => e.Fecha);
                entidad.HasIndex(e => e.Goles1);
                entidad.HasIndex(e => e.Goles2);
                entidad.HasIndex(e => e.Penalties1);
                entidad.HasIndex(e => e.Penalties2);    

            });

            //Aplicar clave foranea a encuentro
            builder.Entity<Encuentro>()
                .HasOne(e => e.Equipo1)
                .WithMany()
                .HasForeignKey(e => e.IdPais1);
            builder.Entity<Encuentro>()
                .HasOne(e => e.Equipo2)
                .WithMany()
                .HasForeignKey(e => e.IdPais2);
            builder.Entity<Encuentro>()
             .HasOne(e => e.Estadio)
             .WithMany()
             .HasForeignKey(e => e.IdEstadio);
            builder.Entity<Encuentro>()
                .HasOne(e => e.Fase)
                .WithMany()
                .HasForeignKey(e => e.IdFase);
            builder.Entity<Encuentro>()
                .HasOne(e => e.Campeonato)
                .WithMany()
                .HasForeignKey(e => e.IdCampeonato);
            
            





        }



    }
}
