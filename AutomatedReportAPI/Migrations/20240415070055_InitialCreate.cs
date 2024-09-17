using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutomatedReportAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Advertisements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advertisements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Certificates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    From_Time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    To_Time = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hall",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hall", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Full_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Divisions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CertificateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Divisions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Divisions_Certificates_CertificateId",
                        column: x => x.CertificateId,
                        principalTable: "Certificates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CertificateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subjects_Certificates_CertificateId",
                        column: x => x.CertificateId,
                        principalTable: "Certificates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    First_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Last_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BirthDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Parent_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Parent_Phone = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Total_Payments = table.Column<double>(type: "float", nullable: false),
                    DivisionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Divisions_DivisionId",
                        column: x => x.DivisionId,
                        principalTable: "Divisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sessions_Records",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DivisionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClassId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HallId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    day = table.Column<int>(type: "int", nullable: false),
                    _ClassId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions_Records", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sessions_Records_Classes__ClassId",
                        column: x => x._ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sessions_Records_Divisions_DivisionId",
                        column: x => x.DivisionId,
                        principalTable: "Divisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sessions_Records_Hall_HallId",
                        column: x => x.HallId,
                        principalTable: "Hall",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sessions_Records_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalMark = table.Column<double>(type: "float", nullable: false),
                    IsDone = table.Column<bool>(type: "bit", nullable: false),
                    SubjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DivisionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tests_Divisions_DivisionId",
                        column: x => x.DivisionId,
                        principalTable: "Divisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tests_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Scores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Scores_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DailySessions_Records",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sessions_RecordId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Subject_Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailySessions_Records", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailySessions_Records_Sessions_Records_Sessions_RecordId",
                        column: x => x.Sessions_RecordId,
                        principalTable: "Sessions_Records",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Test_Marks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Mark = table.Column<double>(type: "float", nullable: false),
                    TestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test_Marks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Test_Marks_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Test_Marks_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Attendances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Enter_Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Outer_Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DailySessions_RecordId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attendances_DailySessions_Records_DailySessions_RecordId",
                        column: x => x.DailySessions_RecordId,
                        principalTable: "DailySessions_Records",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Attendances_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Certificates",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("255383c1-e9ba-4059-9b34-548ac276f7ae"), "الشهادة الثانوية - علمي" },
                    { new Guid("50edb2ed-8a96-45b4-9420-528b5365c25a"), "الشهادة الثانوية - أدبي" },
                    { new Guid("d0d0ce2a-5dad-4719-a988-7cfc8872f3db"), "الشهادة الإعدادية" }
                });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "Id", "From_Time", "Name", "To_Time" },
                values: new object[,]
                {
                    { new Guid("396f0f8f-8833-4619-81cf-8e1b313f9cae"), "08:30", "الحصة الأولى", "10:00" },
                    { new Guid("42838ba5-85d3-467a-b341-d88b91dd6cdd"), "03:00", "الحصة السادسة", "04:30" },
                    { new Guid("45306ef9-6f69-473b-ba08-512ccfac08f0"), "01:00", "الحصة الرابعة", "02:30" },
                    { new Guid("c5a9dc2b-9d1f-408a-8072-174a75669a08"), "11:30", "الحصة الثالثة", "01:00" },
                    { new Guid("e1871fb7-35d9-481c-aa77-b923f35c2f73"), "02:30", "الحصة الخامسة", "03:00" },
                    { new Guid("ea29711f-c113-48d3-8bbc-489043b171b0"), "10:00", "الحصة الثانية", "11:30" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "Type" },
                values: new object[,]
                {
                    { new Guid("8bc9d900-e353-4cc1-ae90-37d31a0688ee"), "AaBbCc@112233", "مدير" },
                    { new Guid("cd50e174-45dc-4634-a383-b63545bf5dd6"), "Aa@112233", "مشرف" }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "CertificateId", "Name" },
                values: new object[,]
                {
                    { new Guid("06b2e20b-486c-4278-9365-7e3dec010df8"), new Guid("d0d0ce2a-5dad-4719-a988-7cfc8872f3db"), "علوم" },
                    { new Guid("37212af0-701f-49e6-b717-794715fe775d"), new Guid("255383c1-e9ba-4059-9b34-548ac276f7ae"), "لغة فرنسية" },
                    { new Guid("3acfefd5-922c-4c95-af9a-0842879694d4"), new Guid("255383c1-e9ba-4059-9b34-548ac276f7ae"), "كيمياء" },
                    { new Guid("3c5f6ace-aeb5-4c9b-895e-f2888f4be476"), new Guid("255383c1-e9ba-4059-9b34-548ac276f7ae"), "رياضيات" },
                    { new Guid("4c3a90a1-e23d-483f-809d-ba51c7cde304"), new Guid("d0d0ce2a-5dad-4719-a988-7cfc8872f3db"), "لغة فرنسية" },
                    { new Guid("62603e78-650e-409a-975f-7c15a754e7c8"), new Guid("50edb2ed-8a96-45b4-9420-528b5365c25a"), "وطنية" },
                    { new Guid("6b2c354f-feda-4d95-a9d6-d6d0e03c0ac8"), new Guid("d0d0ce2a-5dad-4719-a988-7cfc8872f3db"), "ديانة" },
                    { new Guid("71695aac-2012-45cf-b6e7-ff8d74704174"), new Guid("255383c1-e9ba-4059-9b34-548ac276f7ae"), "وطنية" },
                    { new Guid("80e5e0b3-0e9f-490c-b5ea-5ce7fde1dcd5"), new Guid("50edb2ed-8a96-45b4-9420-528b5365c25a"), "جغرافيا" },
                    { new Guid("8a3f51c2-873c-46e9-ba85-e2da81cbd4ac"), new Guid("50edb2ed-8a96-45b4-9420-528b5365c25a"), "لغة فرنسية" },
                    { new Guid("8f5f32a8-65b0-46ae-86dd-8ba78cda2d46"), new Guid("d0d0ce2a-5dad-4719-a988-7cfc8872f3db"), "رياضيات" },
                    { new Guid("8f849ef6-eb1a-4865-b254-7326f55eb636"), new Guid("50edb2ed-8a96-45b4-9420-528b5365c25a"), "لغة عربية" },
                    { new Guid("941cd29d-2cab-46c6-8133-974108e650e1"), new Guid("d0d0ce2a-5dad-4719-a988-7cfc8872f3db"), "فيزياء و كيمياء" },
                    { new Guid("a7723624-8f48-4122-8f34-5912c7b10fd3"), new Guid("255383c1-e9ba-4059-9b34-548ac276f7ae"), "ديانة" },
                    { new Guid("b116b8bc-8ffa-48a1-96e1-8d95da20128a"), new Guid("255383c1-e9ba-4059-9b34-548ac276f7ae"), "لغة عربية" },
                    { new Guid("b70f9ae3-bc20-494a-965b-3c49919ee4c0"), new Guid("d0d0ce2a-5dad-4719-a988-7cfc8872f3db"), "لغة عربية" },
                    { new Guid("bf5ad4ef-7ac1-42c6-9a06-0885e7cafcc3"), new Guid("d0d0ce2a-5dad-4719-a988-7cfc8872f3db"), "اجتماعيات" },
                    { new Guid("d20e4af3-1310-4040-b850-28022c18c686"), new Guid("255383c1-e9ba-4059-9b34-548ac276f7ae"), "علم أحياء" },
                    { new Guid("d3459237-c8b4-4412-a9cd-c7fbffe52753"), new Guid("d0d0ce2a-5dad-4719-a988-7cfc8872f3db"), "لغة انكليزية" },
                    { new Guid("d4097c2f-337e-44ca-bf40-df55499213e2"), new Guid("50edb2ed-8a96-45b4-9420-528b5365c25a"), "ديانة" },
                    { new Guid("dc5f6fd9-177e-4385-b824-61f34fec8e6a"), new Guid("50edb2ed-8a96-45b4-9420-528b5365c25a"), "تاريخ" },
                    { new Guid("e53b5d58-8d62-4dd8-8561-28722099e7e6"), new Guid("255383c1-e9ba-4059-9b34-548ac276f7ae"), "لغة انكليزية" },
                    { new Guid("efe0f785-45f2-4bbc-870a-4a236f2e9c04"), new Guid("255383c1-e9ba-4059-9b34-548ac276f7ae"), "فيزياء" },
                    { new Guid("f12238f3-0955-40ad-af2c-82427aeef792"), new Guid("50edb2ed-8a96-45b4-9420-528b5365c25a"), "لغة انكليزية" },
                    { new Guid("f993a8be-ba0e-48fb-b77b-481bb598f4b8"), new Guid("50edb2ed-8a96-45b4-9420-528b5365c25a"), "فلسفة" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_DailySessions_RecordId",
                table: "Attendances",
                column: "DailySessions_RecordId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_StudentId",
                table: "Attendances",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_DailySessions_Records_Sessions_RecordId",
                table: "DailySessions_Records",
                column: "Sessions_RecordId");

            migrationBuilder.CreateIndex(
                name: "IX_Divisions_CertificateId",
                table: "Divisions",
                column: "CertificateId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_StudentId",
                table: "Payments",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Scores_StudentId",
                table: "Scores",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_Records__ClassId",
                table: "Sessions_Records",
                column: "_ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_Records_DivisionId",
                table: "Sessions_Records",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_Records_HallId",
                table: "Sessions_Records",
                column: "HallId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_Records_SubjectId",
                table: "Sessions_Records",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_DivisionId",
                table: "Students",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_CertificateId",
                table: "Subjects",
                column: "CertificateId");

            migrationBuilder.CreateIndex(
                name: "IX_Test_Marks_StudentId",
                table: "Test_Marks",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Test_Marks_TestId",
                table: "Test_Marks",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_Tests_DivisionId",
                table: "Tests",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Tests_SubjectId",
                table: "Tests",
                column: "SubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Advertisements");

            migrationBuilder.DropTable(
                name: "Attendances");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Scores");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Test_Marks");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "DailySessions_Records");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Tests");

            migrationBuilder.DropTable(
                name: "Sessions_Records");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Divisions");

            migrationBuilder.DropTable(
                name: "Hall");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Certificates");
        }
    }
}
