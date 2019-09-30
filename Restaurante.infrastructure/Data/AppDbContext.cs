using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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
        }

        private void ConfigureRestaurante(EntityTypeBuilder<Core.Entities.Restaurante> builder)
        {
            builder.Property(r => r.HoraDeCierre).IsRequired();
        }
        public DbSet<Restaurante.Core.Entities.Restaurante> Restaurantes { get; set; }
        public DbSet<Restaurante.Core.Entities.Mesa> Mesas { get; set; }
        public DbSet<Restaurante.Core.Entities.Empleado> Empleados { get; set; }
    }
}
