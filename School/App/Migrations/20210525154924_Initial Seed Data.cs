using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class InitialSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    ClassYear = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Grade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false),
                    CourseName = table.Column<string>(type: "TEXT", nullable: true),
                    GradeNum = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grade_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "Age", "ClassYear", "FirstName", "LastName" },
                values: new object[] { 1, 15, 0, "Mark", "Flores" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "Age", "ClassYear", "FirstName", "LastName" },
                values: new object[] { 2, 16, 1, "John", "Doe" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "Age", "ClassYear", "FirstName", "LastName" },
                values: new object[] { 3, 17, 2, "Jessica", "Robinson" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "Age", "ClassYear", "FirstName", "LastName" },
                values: new object[] { 4, 18, 3, "Rex", "Brown" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "Age", "ClassYear", "FirstName", "LastName" },
                values: new object[] { 5, 18, 3, "Amanda", "Johnson" });

            migrationBuilder.InsertData(
                table: "Grade",
                columns: new[] { "Id", "CourseName", "GradeNum", "StudentId" },
                values: new object[] { 1, "English", 80m, 1 });

            migrationBuilder.InsertData(
                table: "Grade",
                columns: new[] { "Id", "CourseName", "GradeNum", "StudentId" },
                values: new object[] { 2, "Math", 60m, 2 });

            migrationBuilder.InsertData(
                table: "Grade",
                columns: new[] { "Id", "CourseName", "GradeNum", "StudentId" },
                values: new object[] { 5, "English", 100m, 2 });

            migrationBuilder.InsertData(
                table: "Grade",
                columns: new[] { "Id", "CourseName", "GradeNum", "StudentId" },
                values: new object[] { 3, "Science", 75m, 3 });

            migrationBuilder.InsertData(
                table: "Grade",
                columns: new[] { "Id", "CourseName", "GradeNum", "StudentId" },
                values: new object[] { 4, "Government", 90m, 4 });

            migrationBuilder.CreateIndex(
                name: "IX_Grade_StudentId",
                table: "Grade",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Grade");

            migrationBuilder.DropTable(
                name: "Student");
        }
    }
}
