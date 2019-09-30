using Microsoft.EntityFrameworkCore.Migrations;

namespace Restaurante.infrastructure.Migrations
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Puesto",
                table: "Empleados",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
