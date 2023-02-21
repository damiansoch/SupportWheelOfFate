using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SupportWheelOfFate.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Engineers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FristShift = table.Column<bool>(type: "bit", nullable: false),
                    SecondShift = table.Column<bool>(type: "bit", nullable: false),
                    FirstShiftDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FirstShiftTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondShiftDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SecondShiftTime = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engineers", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Engineers");
        }
    }
}
