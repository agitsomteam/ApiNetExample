using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using apitarea.Models;
using Microsoft.Extensions.Configuration;

namespace apitarea.dao
{
    public partial class TareasContext : DbContext
    {            
        public  virtual DbSet<Tarea> Tareas {get;set;}

        public TareasContext()
        {

        }

        public TareasContext(DbContextOptions<TareasContext> options) :base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Tarea>(entity =>
            {
                entity.ToTable("Tarea");

                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.idUnique)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("idUnique");

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasColumnName("Nombres");

                entity.Property(e => e.flagAtendido)
                    .IsRequired()
                    .HasColumnName("flgAtendido");
                

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha");

                entity.Property(e => e.id).HasColumnName("id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }

}