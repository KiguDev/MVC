using Microsoft.EntityFrameworkCore.Migrations;

namespace Restaurante.Infrastructure.Migrations
{
    public partial class updateorder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdenTieneProducto_Ordenes_OrdenId",
                table: "OrdenTieneProducto");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdenTieneProducto_Productos_ProductoId",
                table: "OrdenTieneProducto");

            migrationBuilder.AddColumn<string>(
                name: "Imagen",
                table: "Productos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_RestauranteId",
                table: "Ordenes",
                column: "RestauranteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ordenes_Restaurantes_RestauranteId",
                table: "Ordenes",
                column: "RestauranteId",
                principalTable: "Restaurantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ordenes_Restaurantes_RestauranteId",
                table: "Ordenes");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdenTieneProducto_Ordenes_OrdenId",
                table: "OrdenTieneProducto");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdenTieneProducto_Productos_ProductoId",
                table: "OrdenTieneProducto");

            migrationBuilder.DropIndex(
                name: "IX_Ordenes_RestauranteId",
                table: "Ordenes");

            migrationBuilder.DropColumn(
                name: "Imagen",
                table: "Productos");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdenTieneProducto_Ordenes_OrdenId",
                table: "OrdenTieneProducto",
                column: "OrdenId",
                principalTable: "Ordenes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdenTieneProducto_Productos_ProductoId",
                table: "OrdenTieneProducto",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
