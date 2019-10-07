using Microsoft.EntityFrameworkCore.Migrations;

namespace Restaurante.infrastructure.Migrations
{
    public partial class precioProducto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cantidad",
                table: "Productos");

            migrationBuilder.AddColumn<double>(
                name: "Precio",
                table: "Productos",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Precio",
                table: "Productos");

            migrationBuilder.AddColumn<int>(
                name: "Cantidad",
                table: "Productos",
                nullable: false,
                defaultValue: 0);
        }
    }
}
