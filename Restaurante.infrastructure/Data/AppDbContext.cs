using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
        }

        private void ConfigurarRestaurante(EntityTypeBuilder<core.Entities.Restaurante> builder)
        {
            builder.Property(r => r.HoraDeCierre).IsRequired();
        }

        public DbSet<core.Entities.Restaurante> Restaurantes { get; set; }
        public DbSet<core.Entities.Mesa> Mesas { get; set; }
        public DbSet<core.Entities.Empleado> Empleados { get; set; }
    }
}
