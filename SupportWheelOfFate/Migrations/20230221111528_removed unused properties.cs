using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SupportWheelOfFate.Migrations
{
    /// <inheritdoc />
    public partial class removedunusedproperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstShiftDate",
                table: "Engineers");

            migrationBuilder.DropColumn(
                name: "FirstShiftTime",
                table: "Engineers");

            migrationBuilder.DropColumn(
                name: "FristShift",
                table: "Engineers");

            migrationBuilder.DropColumn(
                name: "SecondShift",
                table: "Engineers");

            migrationBuilder.DropColumn(
                name: "SecondShiftDate",
                table: "Engineers");

            migrationBuilder.DropColumn(
                name: "SecondShiftTime",
                table: "Engineers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FirstShiftDate",
                table: "Engineers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstShiftTime",
                table: "Engineers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "FristShift",
                table: "Engineers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SecondShift",
                table: "Engineers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "SecondShiftDate",
                table: "Engineers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecondShiftTime",
                table: "Engineers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
