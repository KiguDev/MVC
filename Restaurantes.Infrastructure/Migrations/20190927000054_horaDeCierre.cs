using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Restaurantes.Infrastructure.Migrations
{
    public partial class horaDeCierre : Migration
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
                name: "FechaDeAlta",
                table: "Restaurantes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "HoraDeCierre",
                table: "Restaurantes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaDeAlta",
                table: "Restaurantes");

            migrationBuilder.DropColumn(
                name: "HoraDeCierre",
                table: "Restaurantes");

            migrationBuilder.AlterColumn<string>(
                name: "Telefono",
                table: "Restaurantes",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
