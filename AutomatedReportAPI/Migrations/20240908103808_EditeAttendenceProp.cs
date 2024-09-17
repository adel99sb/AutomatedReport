using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutomatedReportAPI.Migrations
{
    public partial class EditeAttendenceProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.DropColumn(
                name: "Enter_Time",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "Outer_Time",
                table: "Attendances");

            migrationBuilder.AddColumn<bool>(
                name: "IsAttend",
                table: "Attendances",
                type: "bit",
                nullable: false,
                defaultValue: false);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.DropColumn(
                name: "IsAttend",
                table: "Attendances");

            migrationBuilder.AddColumn<string>(
                name: "Enter_Time",
                table: "Attendances",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Outer_Time",
                table: "Attendances",
                type: "nvarchar(max)",
                nullable: true);

        }
    }
}
