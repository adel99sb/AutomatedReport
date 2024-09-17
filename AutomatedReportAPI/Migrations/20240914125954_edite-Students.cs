using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutomatedReportAPI.Migrations
{
    public partial class editeStudents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.RenameColumn(
                name: "Parent_Phone",
                table: "Students",
                newName: "Mother_Phone");

            migrationBuilder.RenameColumn(
                name: "Parent_Name",
                table: "Students",
                newName: "Mother_Name");

            migrationBuilder.AddColumn<bool>(
                name: "DefaultParentPhonIsFather",
                table: "Students",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Father_Name",
                table: "Students",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Father_Phone",
                table: "Students",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "agreedMonthlyPayment",
                table: "Students",
                type: "float",
                nullable: false,
                defaultValue: 0.0);            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {          
            migrationBuilder.DropColumn(
                name: "DefaultParentPhonIsFather",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Father_Name",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Father_Phone",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "agreedMonthlyPayment",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "Mother_Phone",
                table: "Students",
                newName: "Parent_Phone");

            migrationBuilder.RenameColumn(
                name: "Mother_Name",
                table: "Students",
                newName: "Parent_Name");            
        }
    }
}
