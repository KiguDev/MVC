﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Restaurantes.Infrastructure.Data;

namespace Restaurantes.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20191001234825_test2")]
    partial class test2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Restaurantes.Core.Entities.Empleado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre");

                    b.Property<int>("Puesto");

                    b.Property<int>("RestauranteId");

                    b.HasKey("Id");

                    b.HasIndex("RestauranteId");

                    b.ToTable("Empleados");
                });

            modelBuilder.Entity("Restaurantes.Core.Entities.Mesa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Capacidad");

                    b.Property<string>("Identificador");

                    b.Property<int>("RestauranteId");

                    b.HasKey("Id");

                    b.HasIndex("RestauranteId");

                    b.ToTable("Mesas");
                });

            modelBuilder.Entity("Restaurantes.Core.Entities.Orden", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmpleadoId");

                    b.Property<int>("Estatus");

                    b.Property<DateTime>("FechaAlta");

                    b.Property<int>("RestauranteId");

                    b.Property<decimal>("Total");

                    b.HasKey("Id");

                    b.ToTable("Ordenes");
                });

            modelBuilder.Entity("Restaurantes.Core.Entities.OrdenProducto", b =>
                {
                    b.Property<int>("OrdenId");

                    b.Property<int>("ProductoId");

                    b.Property<int>("Cantidad");

                    b.HasKey("OrdenId", "ProductoId");

                    b.HasIndex("ProductoId");

                    b.ToTable("OrdenProducto");
                });

            modelBuilder.Entity("Restaurantes.Core.Entities.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cantidad");

                    b.Property<string>("Ingredientes");

                    b.Property<string>("Nombre");

                    b.HasKey("Id");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("Restaurantes.Core.Entities.Restaurante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Domicilio");

                    b.Property<DateTime>("FechaDeAlta");

                    b.Property<int?>("HoraDeCierre")
                        .IsRequired();

                    b.Property<string>("Logo");

                    b.Property<string>("Nombre");

                    b.Property<string>("PaginaWeb");

                    b.Property<int>("Telefono");

                    b.HasKey("Id");

                    b.ToTable("Restaurantes");
                });

            modelBuilder.Entity("Restaurantes.Core.Entities.Empleado", b =>
                {
                    b.HasOne("Restaurantes.Core.Entities.Restaurante", "Restaurante")
                        .WithMany()
                        .HasForeignKey("RestauranteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Restaurantes.Core.Entities.Mesa", b =>
                {
                    b.HasOne("Restaurantes.Core.Entities.Restaurante", "Restaurante")
                        .WithMany("Mesas")
                        .HasForeignKey("RestauranteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Restaurantes.Core.Entities.OrdenProducto", b =>
                {
                    b.HasOne("Restaurantes.Core.Entities.Orden", "Orden")
                        .WithMany("Productos")
                        .HasForeignKey("OrdenId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Restaurantes.Core.Entities.Producto", "Producto")
                        .WithMany("Ordenes")
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
