using Microsoft.EntityFrameworkCore.Migrations;

namespace Restaurante.infrastructure.Migrations
{
    public partial class resIdProduc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Restaurantes_RestauranteId",
                table: "Productos");

            migrationBuilder.AlterColumn<int>(
                name: "RestauranteId",
                table: "Productos",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

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

            migrationBuilder.AlterColumn<int>(
                name: "RestauranteId",
                table: "Productos",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Restaurantes_RestauranteId",
                table: "Productos",
                column: "RestauranteId",
                principalTable: "Restaurantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
