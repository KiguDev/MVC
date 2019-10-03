using Microsoft.EntityFrameworkCore.Migrations;

namespace Restaurante.Infrastructure.Migrations
{
    public partial class muchasMesas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HoraDeCierre",
                table: "Restaurantes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mesa_RestauranteId",
                table: "Mesa",
                column: "RestauranteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mesa_Restaurantes_RestauranteId",
                table: "Mesa",
                column: "RestauranteId",
                principalTable: "Restaurantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mesa_Restaurantes_RestauranteId",
                table: "Mesa");

            migrationBuilder.DropIndex(
                name: "IX_Mesa_RestauranteId",
                table: "Mesa");

            migrationBuilder.DropColumn(
                name: "HoraDeCierre",
                table: "Restaurantes");
        }
    }
}
