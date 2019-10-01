using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurante.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Core.Entities.Restaurante>(ConfigureRestaurante);
            modelBuilder.Entity<Core.Entities.OrdenProducto>(ConfigureOrdenProductos);
        }

        private void ConfigureOrdenProductos(EntityTypeBuilder<OrdenProducto> builder)
        {
            builder.HasKey(c => new
            {
                c.OrdenId,
                c.ProductoId
            });
            builder.HasOne(c => c.Productos).WithMany(c => c.Ordenes).HasForeignKey(c => c.ProductoId);
            builder.HasOne(c => c.Ordenes).WithMany(c => c.Productos).HasForeignKey(c => c.OrdenId);
        }

        private void ConfigureRestaurante(EntityTypeBuilder<Core.Entities.Restaurante> builder)
        {
            builder.Property(r => r.HoraDeCierre).IsRequired();
        }
        public DbSet<Restaurante.Core.Entities.Restaurante> Restaurantes { get; set; }
        public DbSet<Restaurante.Core.Entities.Mesa> Mesas { get; set; }
        public DbSet<Restaurante.Core.Entities.Empleado> Empleados { get; set; }
        public DbSet<Restaurante.Core.Entities.Ordenes> Ordenes { get; set; }
        public DbSet<Restaurante.Core.Entities.Productos> Productos { get; set; }
    }
}
