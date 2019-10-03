using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Restaurante.Infrastructure.Migrations
{
    public partial class inico2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaDeAlta",
                table: "Restaurantes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaDeAlta",
                table: "Restaurantes");
        }
    }
}
