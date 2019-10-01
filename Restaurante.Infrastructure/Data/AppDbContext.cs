using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurante.Core.Entities;

namespace Restaurante.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Core.Entities.Restaurante>();
            modelBuilder.Entity<OrdenTieneProducto>(ConfigureOrdenTieneProducto);
        }


        private void ConfigureOrdenTieneProducto(EntityTypeBuilder<OrdenTieneProducto> builder)
        {
            builder.HasKey(c => new
            {
                c.OrdenId,
                c.ProductoId
            });

            builder.HasOne(c => c.Producto).WithMany(c => c.Ordenes).HasForeignKey(c => c.ProductoId);
            builder.HasOne(c => c.Orden).WithMany(c => c.Productos).HasForeignKey(c => c.OrdenId);
        }
        private void ConfigureRetaurante(EntityTypeBuilder<Core.Entities.Restaurante> builder)
        {
            builder.Property(r=>r.HoraCierre).IsRequired();
        }
        public DbSet<Restaurante.Core.Entities.Restaurante> Restaurantes { get; set; }
        public DbSet<Restaurante.Core.Entities.Mesa> Mesas { get; set; }
        public DbSet<Restaurante.Core.Entities.Empleado> Empleados { get; set; }

        public DbSet<Restaurante.Core.Entities.Orden> Ordenes { get; set; }

        public DbSet<Restaurante.Core.Entities.Producto> Productos { get; set; }
    }
}
