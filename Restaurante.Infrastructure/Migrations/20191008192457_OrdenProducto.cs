using Microsoft.EntityFrameworkCore.Migrations;

namespace Restaurante.Infrastructure.Migrations
{
    public partial class OrdenProducto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdenProducto_Ordenes_OrdenId",
                table: "OrdenProducto");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdenProducto_Productos_ProductoId",
                table: "OrdenProducto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrdenProducto",
                table: "OrdenProducto");

            migrationBuilder.RenameTable(
                name: "OrdenProducto",
                newName: "OrdenProductos");

            migrationBuilder.RenameIndex(
                name: "IX_OrdenProducto_ProductoId",
                table: "OrdenProductos",
                newName: "IX_OrdenProductos_ProductoId");

            migrationBuilder.AddColumn<double>(
                name: "Subtotal",
                table: "OrdenProductos",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrdenProductos",
                table: "OrdenProductos",
                columns: new[] { "OrdenId", "ProductoId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrdenProductos_Ordenes_OrdenId",
                table: "OrdenProductos",
                column: "OrdenId",
                principalTable: "Ordenes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdenProductos_Productos_ProductoId",
                table: "OrdenProductos",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdenProductos_Ordenes_OrdenId",
                table: "OrdenProductos");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdenProductos_Productos_ProductoId",
                table: "OrdenProductos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrdenProductos",
                table: "OrdenProductos");

            migrationBuilder.DropColumn(
                name: "Subtotal",
                table: "OrdenProductos");

            migrationBuilder.RenameTable(
                name: "OrdenProductos",
                newName: "OrdenProducto");

            migrationBuilder.RenameIndex(
                name: "IX_OrdenProductos_ProductoId",
                table: "OrdenProducto",
                newName: "IX_OrdenProducto_ProductoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrdenProducto",
                table: "OrdenProducto",
                columns: new[] { "OrdenId", "ProductoId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrdenProducto_Ordenes_OrdenId",
                table: "OrdenProducto",
                column: "OrdenId",
                principalTable: "Ordenes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdenProducto_Productos_ProductoId",
                table: "OrdenProducto",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
