using Microsoft.EntityFrameworkCore.Migrations;

namespace ShipwharfMVCSolution.Data.Migrations
{
    public partial class ShipwarfInit_I : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ships_ShipTypes_ShipTypeId",
                table: "Ships");

            migrationBuilder.AlterColumn<int>(
                name: "ShipTypeId",
                table: "Ships",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ships_ShipTypes_ShipTypeId",
                table: "Ships",
                column: "ShipTypeId",
                principalTable: "ShipTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ships_ShipTypes_ShipTypeId",
                table: "Ships");

            migrationBuilder.AlterColumn<int>(
                name: "ShipTypeId",
                table: "Ships",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Ships_ShipTypes_ShipTypeId",
                table: "Ships",
                column: "ShipTypeId",
                principalTable: "ShipTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
