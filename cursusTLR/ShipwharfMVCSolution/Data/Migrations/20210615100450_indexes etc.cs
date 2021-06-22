using Microsoft.EntityFrameworkCore.Migrations;

namespace ShipwharfMVCSolution.Data.Migrations
{
    public partial class indexesetc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Ships",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EuNumber",
                table: "Ships",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ships_EuNumber",
                table: "Ships",
                column: "EuNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Ships_Name",
                table: "Ships",
                column: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Ships_EuNumber",
                table: "Ships");

            migrationBuilder.DropIndex(
                name: "IX_Ships_Name",
                table: "Ships");

            migrationBuilder.DropColumn(
                name: "EuNumber",
                table: "Ships");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Ships",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);
        }
    }
}
