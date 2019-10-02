using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurantes.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurantes.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurante>(ConfigureRestaurante);
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

        private void ConfigureRestaurante(EntityTypeBuilder<Restaurante> builder)
        {
            builder.Property(r => r.HoraDeCierre)
                .IsRequired();
        }


        public DbSet<Restaurante> Restaurantes { get; set; }
        public DbSet<Mesa> Mesas { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Orden> Ordenes { get; set; }
        public DbSet<Producto> Productos { get; set; }
    }
}
