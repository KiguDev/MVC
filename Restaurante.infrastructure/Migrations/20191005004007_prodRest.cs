using Microsoft.EntityFrameworkCore.Migrations;

namespace Restaurante.infrastructure.Migrations
{
    public partial class prodRest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RestauranteId",
                table: "Productos",
                nullable: true);

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
                onDelete: ReferentialAction.Restrict);
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
