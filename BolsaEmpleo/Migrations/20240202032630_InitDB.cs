using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BolsaEmpleo.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    typeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    typeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.typeId);
                });

            migrationBuilder.CreateTable(
                name: "Vacancies",
                columns: table => new
                {
                    vacantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vacantCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    vacantJobTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    vacantDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    vacantCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    vacantSalary = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacancies", x => x.vacantId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    userId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    typeId = table.Column<int>(type: "int", nullable: false),
                    userIdentification = table.Column<int>(type: "int", nullable: false),
                    userName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userBirthday = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userProfession = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userSalary = table.Column<int>(type: "int", nullable: false),
                    userEmail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userId);
                    table.ForeignKey(
                        name: "FK_Users_Types_typeId",
                        column: x => x.typeId,
                        principalTable: "Types",
                        principalColumn: "typeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VacantApplications",
                columns: table => new
                {
                    vacantApplicationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vacantId = table.Column<int>(type: "int", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacantApplications", x => x.vacantApplicationID);
                    table.ForeignKey(
                        name: "FK_VacantApplications_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VacantApplications_Vacancies_vacantId",
                        column: x => x.vacantId,
                        principalTable: "Vacancies",
                        principalColumn: "vacantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_typeId",
                table: "Users",
                column: "typeId");

            migrationBuilder.CreateIndex(
                name: "IX_VacantApplications_userId",
                table: "VacantApplications",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_VacantApplications_vacantId",
                table: "VacantApplications",
                column: "vacantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VacantApplications");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Vacancies");

            migrationBuilder.DropTable(
                name: "Types");
        }
    }
}
