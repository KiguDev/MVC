using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Core.Entities.Restaurante>(ConfigureRestaurante);
            modelBuilder.Entity<Core.Entities.OrdenProducto>(ConfigureOrdenProducto);
        }
        private void ConfigureOrdenProducto(EntityTypeBuilder<Core.Entities.OrdenProducto> builder)
        {
            builder.HasKey(c => new { c.OrdenId, c.ProductoId });
            builder.HasOne(c => c.Producto).WithMany(c => c.Ordenes).HasForeignKey(c => c.ProductoId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.Orden).WithMany(c => c.Productos).HasForeignKey(c => c.OrdenId).OnDelete(DeleteBehavior.Restrict);
        }

        private void ConfigureRestaurante(EntityTypeBuilder<Core.Entities.Restaurante> builder)
        {
            builder.Property(r => r.HoraDeCierre).IsRequired();
        }

        public DbSet<Core.Entities.Restaurante> Restaurantes { get; set; }
        public DbSet<Core.Entities.Mesa> Mesas { get; set; }
        public DbSet<Core.Entities.Empleado> Empleados { get; set; }
        public DbSet<Core.Entities.Orden> Ordenes { get; set; }
        public DbSet<Core.Entities.Producto> Productos { get; set; }
        public DbSet<Core.Entities.OrdenProducto> OrdenProductos { get; set; }

    }
}
