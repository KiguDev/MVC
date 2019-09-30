using Microsoft.EntityFrameworkCore.Migrations;

namespace Restaurante.infrastructure.Migrations
{
    public partial class empleadoRestaurante : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Empleados_RestauranteId",
                table: "Empleados",
                column: "RestauranteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_Restaurantes_RestauranteId",
                table: "Empleados",
                column: "RestauranteId",
                principalTable: "Restaurantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_Restaurantes_RestauranteId",
                table: "Empleados");

            migrationBuilder.DropIndex(
                name: "IX_Empleados_RestauranteId",
                table: "Empleados");
        }
    }
}
