using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurante.core.Entities;

namespace Restaurante.infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<core.Entities.Restaurante>(ConfigurarRestaurante);
            modelBuilder.Entity<core.Entities.OrdenProducto>(ConfigureOrdenProductos);
        }

        private void ConfigureOrdenProductos(EntityTypeBuilder<OrdenProducto> builder)
        {
            builder.HasKey(c => new {
                c.OrdenId,
                c.ProductoId
            });
            builder.HasOne(c => c.Producto).WithMany(c => c.Ordenes).HasForeignKey(c => c.ProductoId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.Orden).WithMany(c => c.Productos).HasForeignKey(c => c.OrdenId).OnDelete(DeleteBehavior.Restrict);
        }

        private void ConfigurarRestaurante(EntityTypeBuilder<core.Entities.Restaurante> builder)
        {
            builder.Property(r => r.HoraDeCierre).IsRequired();
            builder.HasMany(r => r.ordenes).WithOne(o => o.Restaurante).HasForeignKey(o => o.RestauranteId).OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<core.Entities.Restaurante> Restaurantes { get; set; }
        public DbSet<core.Entities.Mesa> Mesas { get; set; }
        public DbSet<core.Entities.Empleado> Empleados { get; set; }
        public DbSet<core.Entities.Orden> Ordenes { get; set; }
        public DbSet<core.Entities.Producto> Productos { get; set; }
        public DbSet<core.Entities.OrdenProducto> OrdenProducto { get; set; }
    }
}
