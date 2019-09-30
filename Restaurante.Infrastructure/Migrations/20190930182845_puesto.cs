using Microsoft.EntityFrameworkCore.Migrations;

namespace Restaurante.Infrastructure.Migrations
{
    public partial class puesto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Puesto",
                table: "Empleados",
                nullable: true,
                oldClrType: typeof(int));

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

            migrationBuilder.AlterColumn<int>(
                name: "Puesto",
                table: "Empleados",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
