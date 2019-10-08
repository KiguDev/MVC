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
            builder.HasOne(c => c.Producto).WithMany(c => c.Ordenes).HasForeignKey(c => c.ProductoId).OnDelete(DeleteBehavior.Restrict); 
            builder.HasOne(c => c.Orden).WithMany(c => c.Productos).HasForeignKey(c => c.OrdenId).OnDelete(DeleteBehavior.Restrict);
        }

        private void ConfigureRestaurante(EntityTypeBuilder<Restaurante> builder)
        {
            builder.Property(r => r.HoraDeCierre)
                .IsRequired();

            builder.HasMany(o => o.Ordenes).WithOne(d => d.Restaurante).HasForeignKey(r=>r.RestauranteId)
              .OnDelete(DeleteBehavior.Restrict);
        }


        public DbSet<Restaurante> Restaurantes { get; set; }
        public DbSet<Mesa> Mesas { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Orden> Ordenes { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<OrdenTieneProducto> OrdenTieneProductos { get; set; }
    }
}
