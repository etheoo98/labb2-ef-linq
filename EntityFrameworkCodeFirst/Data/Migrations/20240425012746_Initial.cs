using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EntityFrameworkCodeFirst.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FkPersonId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teachers_People_FkPersonId",
                        column: x => x.FkPersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    FkTeacherId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Teachers_FkTeacherId",
                        column: x => x.FkTeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    FkTeacherId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grades_Teachers_FkTeacherId",
                        column: x => x.FkTeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FkPersonId = table.Column<int>(type: "INTEGER", nullable: false),
                    FkGradeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Grades_FkGradeId",
                        column: x => x.FkGradeId,
                        principalTable: "Grades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_People_FkPersonId",
                        column: x => x.FkPersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FkStudentId = table.Column<int>(type: "INTEGER", nullable: false),
                    FkCourseId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enrollments_Courses_FkCourseId",
                        column: x => x.FkCourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollments_Students_FkStudentId",
                        column: x => x.FkStudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Johan", "Edlund" },
                    { 2, "Heikki", "Wallenberg" },
                    { 3, "Leo", "Andersson" },
                    { 4, "Ellen", "Blixt" },
                    { 5, "Bengt", "Östrand" },
                    { 6, "Klara", "Vi" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "FkPersonId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "FkTeacherId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Web applications in C# ASP.NET" },
                    { 2, 2, "Project management and agile methods" }
                });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "FkTeacherId", "Name" },
                values: new object[] { 1, 1, ".NET23" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FkGradeId", "FkPersonId" },
                values: new object[,]
                {
                    { 1, 1, 3 },
                    { 2, 1, 4 },
                    { 3, 1, 5 },
                    { 4, 1, 6 }
                });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "Id", "FkCourseId", "FkStudentId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 1, 3 },
                    { 4, 2, 3 },
                    { 5, 1, 4 },
                    { 6, 2, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_FkTeacherId",
                table: "Courses",
                column: "FkTeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_FkCourseId",
                table: "Enrollments",
                column: "FkCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_FkStudentId",
                table: "Enrollments",
                column: "FkStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_FkTeacherId",
                table: "Grades",
                column: "FkTeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_FkGradeId",
                table: "Students",
                column: "FkGradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_FkPersonId",
                table: "Students",
                column: "FkPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_FkPersonId",
                table: "Teachers",
                column: "FkPersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
