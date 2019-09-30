using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurante.Core.Entities;
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
            modelBuilder.Entity<Restaurante>(ConfigureRestaurante);
        }

        private void ConfigureRestaurante(EntityTypeBuilder<Core.Entities.Restaurante> builder)
        {
            builder.Property(r => r.HoraDeCierre)
                .IsRequired();
        }

        public DbSet<Core.Entities.Restaurante> Restaurantes { get; set; }
        public DbSet<Mesa> Mesas { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
    }
}
