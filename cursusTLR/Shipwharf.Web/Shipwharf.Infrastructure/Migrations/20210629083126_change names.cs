using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shipwharf.Infrastructure.Migrations
{
    public partial class changenames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShipTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ships",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Hold = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    EuNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    TypeId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ships_ShipTypes_TypeId1",
                        column: x => x.TypeId1,
                        principalTable: "ShipTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ships_EuNumber",
                table: "Ships",
                column: "EuNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Ships_Name",
                table: "Ships",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Ships_TypeId1",
                table: "Ships",
                column: "TypeId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ships");

            migrationBuilder.DropTable(
                name: "ShipTypes");
        }
    }
}
