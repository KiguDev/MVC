using Microsoft.EntityFrameworkCore.Migrations;

namespace Restaurante.Infrastructure.Migrations
{
    public partial class UpdateProductos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FechaAltra",
                table: "Ordenes",
                newName: "FechaAlta");

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

            migrationBuilder.RenameColumn(
                name: "FechaAlta",
                table: "Ordenes",
                newName: "FechaAltra");
        }
    }
}
