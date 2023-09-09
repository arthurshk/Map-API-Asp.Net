using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Scaffold2.Migrations.CalendarDB
{
    public partial class CalendarMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Calendar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    eventTitle = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    eventDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    eventDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calendar", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Calendar");
        }
    }
}
