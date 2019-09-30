using Microsoft.EntityFrameworkCore.Migrations;

namespace Restaurante.Infrastructure.Migrations
{
    public partial class MuchasMesas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Mesas_RestauranteId",
                table: "Mesas",
                column: "RestauranteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mesas_Restaurantes_RestauranteId",
                table: "Mesas",
                column: "RestauranteId",
                principalTable: "Restaurantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mesas_Restaurantes_RestauranteId",
                table: "Mesas");

            migrationBuilder.DropIndex(
                name: "IX_Mesas_RestauranteId",
                table: "Mesas");
        }
    }
}
