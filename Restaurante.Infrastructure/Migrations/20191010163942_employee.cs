using Microsoft.EntityFrameworkCore.Migrations;

namespace Restaurante.Infrastructure.Migrations
{
    public partial class employee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmpleadoId",
                table: "Ordenes");

            migrationBuilder.AddColumn<string>(
                name: "Foto",
                table: "Empleados",
                nullable: true);

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

            migrationBuilder.DropColumn(
                name: "Foto",
                table: "Empleados");

            migrationBuilder.AddColumn<int>(
                name: "EmpleadoId",
                table: "Ordenes",
                nullable: false,
                defaultValue: 0);
        }
    }
}
