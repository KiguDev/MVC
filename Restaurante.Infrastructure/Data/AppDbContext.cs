using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurante.Core.Entities;

namespace Restaurante.Infrastructure.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Core.Entities.Restaurante>(ConfigureRestaurante);
            modelBuilder.Entity<OrdenProducto>(ConfiggureOrdenTieneProducto);
        }

        private void ConfiggureOrdenTieneProducto(EntityTypeBuilder<OrdenProducto> builder)
        {
            builder.HasKey(c => new
            {
      
                c.ProductoId
            });
            builder.HasOne(c => c.Producto)
                 .WithMany(c => c.Ordenes)
                 .HasForeignKey(c => c.ProductoId);
            builder.HasOne(c => c.Producto)
                .WithMany(c => c.Ordenes)
                .HasForeignKey(c => c.ProductoId);
        }

        private void ConfigureRestaurante(EntityTypeBuilder<Core.Entities.Restaurante> builder)
        {
            builder.Property(r => r.FechaDeAlta).IsRequired();   
        }

        public DbSet<Core.Entities.Restaurante> Restaurantes { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Mesa> Mesa { get; set; }
        public DbSet<Orden> Ordenes{ get; set; }
        public DbSet<Producto> Productos { get; set; }
    }
}
