using Microsoft.EntityFrameworkCore.Migrations;

namespace Restaurantes.Infrastructure.Migrations
{
    public partial class ordenes : Migration
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

            migrationBuilder.AlterColumn<decimal>(
                name: "Precio",
                table: "Productos",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AddColumn<decimal>(
                name: "Subtotal",
                table: "OrdenTieneProductos",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrdenTieneProductos",
                table: "OrdenTieneProductos",
                columns: new[] { "OrdenId", "ProductoId" });

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_EmpleadoId",
                table: "Ordenes",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_RestauranteId",
                table: "Ordenes",
                column: "RestauranteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ordenes_Empleados_EmpleadoId",
                table: "Ordenes",
                column: "EmpleadoId",
                principalTable: "Empleados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ordenes_Restaurantes_RestauranteId",
                table: "Ordenes",
                column: "RestauranteId",
                principalTable: "Restaurantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_Ordenes_Empleados_EmpleadoId",
                table: "Ordenes");

            migrationBuilder.DropForeignKey(
                name: "FK_Ordenes_Restaurantes_RestauranteId",
                table: "Ordenes");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdenTieneProductos_Ordenes_OrdenId",
                table: "OrdenTieneProductos");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdenTieneProductos_Productos_ProductoId",
                table: "OrdenTieneProductos");

            migrationBuilder.DropIndex(
                name: "IX_Ordenes_EmpleadoId",
                table: "Ordenes");

            migrationBuilder.DropIndex(
                name: "IX_Ordenes_RestauranteId",
                table: "Ordenes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrdenTieneProductos",
                table: "OrdenTieneProductos");

            migrationBuilder.DropColumn(
                name: "Subtotal",
                table: "OrdenTieneProductos");

            migrationBuilder.RenameTable(
                name: "OrdenTieneProductos",
                newName: "OrdenTieneProducto");

            migrationBuilder.RenameIndex(
                name: "IX_OrdenTieneProductos_ProductoId",
                table: "OrdenTieneProducto",
                newName: "IX_OrdenTieneProducto_ProductoId");

            migrationBuilder.AlterColumn<double>(
                name: "Precio",
                table: "Productos",
                nullable: false,
                oldClrType: typeof(decimal));

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
