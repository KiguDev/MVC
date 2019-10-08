using Microsoft.EntityFrameworkCore.Migrations;

namespace Restaurantes.Infrastructure.Migrations
{
    public partial class productos2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ingredientes",
                table: "Productos",
                newName: "Descripcion");

            migrationBuilder.RenameColumn(
                name: "Cantidad",
                table: "Productos",
                newName: "RestauranteId");

            migrationBuilder.AddColumn<double>(
                name: "Precio",
                table: "Productos",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_Productos_RestauranteId",
                table: "Productos",
                column: "RestauranteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Restaurantes_RestauranteId",
                table: "Productos",
                column: "RestauranteId",
                principalTable: "Restaurantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Restaurantes_RestauranteId",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_RestauranteId",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "Precio",
                table: "Productos");

            migrationBuilder.RenameColumn(
                name: "RestauranteId",
                table: "Productos",
                newName: "Cantidad");

            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "Productos",
                newName: "Ingredientes");
        }
    }
}
