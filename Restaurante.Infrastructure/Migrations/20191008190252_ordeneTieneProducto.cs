using Microsoft.EntityFrameworkCore.Migrations;

namespace Restaurante.Infrastructure.Migrations
{
    public partial class ordeneTieneProducto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdenTieneProducto_Ordenes_OrdenId",
                table: "OrdenTieneProducto");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdenTieneProducto_Productos_ProductoId",
                table: "OrdenTieneProducto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrdenTieneProducto",
                table: "OrdenTieneProducto");

            migrationBuilder.RenameTable(
                name: "OrdenTieneProducto",
                newName: "OrdenTieneProductos");

            migrationBuilder.RenameIndex(
                name: "IX_OrdenTieneProducto_ProductoId",
                table: "OrdenTieneProductos",
                newName: "IX_OrdenTieneProductos_ProductoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrdenTieneProductos",
                table: "OrdenTieneProductos",
                columns: new[] { "OrdenId", "ProductoId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrdenTieneProductos_Ordenes_OrdenId",
                table: "OrdenTieneProductos",
                column: "OrdenId",
                principalTable: "Ordenes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdenTieneProductos_Productos_ProductoId",
                table: "OrdenTieneProductos",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdenTieneProductos_Ordenes_OrdenId",
                table: "OrdenTieneProductos");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdenTieneProductos_Productos_ProductoId",
                table: "OrdenTieneProductos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrdenTieneProductos",
                table: "OrdenTieneProductos");

            migrationBuilder.RenameTable(
                name: "OrdenTieneProductos",
                newName: "OrdenTieneProducto");

            migrationBuilder.RenameIndex(
                name: "IX_OrdenTieneProductos_ProductoId",
                table: "OrdenTieneProducto",
                newName: "IX_OrdenTieneProducto_ProductoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrdenTieneProducto",
                table: "OrdenTieneProducto",
                columns: new[] { "OrdenId", "ProductoId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrdenTieneProducto_Ordenes_OrdenId",
                table: "OrdenTieneProducto",
                column: "OrdenId",
                principalTable: "Ordenes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdenTieneProducto_Productos_ProductoId",
                table: "OrdenTieneProducto",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
