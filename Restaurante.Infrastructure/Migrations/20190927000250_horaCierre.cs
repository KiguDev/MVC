using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Restaurante.Infrastructure.Migrations
{
    public partial class horaCierre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Telefono",
                table: "Restaurantes",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaAlta",
                table: "Restaurantes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "HoraCierre",
                table: "Restaurantes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaAlta",
                table: "Restaurantes");

            migrationBuilder.DropColumn(
                name: "HoraCierre",
                table: "Restaurantes");

            migrationBuilder.AlterColumn<string>(
                name: "Telefono",
                table: "Restaurantes",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
