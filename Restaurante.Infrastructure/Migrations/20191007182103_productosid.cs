using Microsoft.EntityFrameworkCore.Migrations;

namespace Restaurante.Infrastructure.Migrations
{
    public partial class productosid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RestauranteId",
                table: "Productos",
                nullable: false,
                defaultValue: 0);

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
                name: "RestauranteId",
                table: "Productos");
        }
    }
}
