using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LavandierAirLine.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModels3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pagos_MetodosPagos_MetodosPagosMetodoPagoId",
                table: "Pagos");

            migrationBuilder.AlterColumn<int>(
                name: "MetodosPagosMetodoPagoId",
                table: "Pagos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Pagos_MetodosPagos_MetodosPagosMetodoPagoId",
                table: "Pagos",
                column: "MetodosPagosMetodoPagoId",
                principalTable: "MetodosPagos",
                principalColumn: "MetodoPagoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pagos_MetodosPagos_MetodosPagosMetodoPagoId",
                table: "Pagos");

            migrationBuilder.AlterColumn<int>(
                name: "MetodosPagosMetodoPagoId",
                table: "Pagos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pagos_MetodosPagos_MetodosPagosMetodoPagoId",
                table: "Pagos",
                column: "MetodosPagosMetodoPagoId",
                principalTable: "MetodosPagos",
                principalColumn: "MetodoPagoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
