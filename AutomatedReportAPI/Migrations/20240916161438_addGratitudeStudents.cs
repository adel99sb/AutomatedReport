using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutomatedReportAPI.Migrations
{
    public partial class addGratitudeStudents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {            
            migrationBuilder.CreateTable(
                name: "GratitudeStudents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    First_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Last_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BirthDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Father_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Father_Phone = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Mother_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Mother_Phone = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    DefaultParentPhonIsFather = table.Column<bool>(type: "bit", nullable: false),
                    Total_Payments = table.Column<double>(type: "float", nullable: false),
                    agreedMonthlyPayment = table.Column<double>(type: "float", nullable: false),
                    Avg = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GratitudeStudents", x => x.Id);
                });         
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GratitudeStudents");            
        }
    }
}
