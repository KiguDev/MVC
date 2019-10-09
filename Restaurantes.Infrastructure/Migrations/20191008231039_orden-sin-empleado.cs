using Microsoft.EntityFrameworkCore.Migrations;

namespace Restaurantes.Infrastructure.Migrations
{
    public partial class ordensinempleado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ordenes_Empleados_EmpleadoId",
                table: "Ordenes");

            migrationBuilder.DropIndex(
                name: "IX_Ordenes_EmpleadoId",
                table: "Ordenes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_EmpleadoId",
                table: "Ordenes",
                column: "EmpleadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ordenes_Empleados_EmpleadoId",
                table: "Ordenes",
                column: "EmpleadoId",
                principalTable: "Empleados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
