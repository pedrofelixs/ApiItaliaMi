using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiItaliaMi.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompleteName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PersonalEmail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PrenotamiEmail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PrenotamiPassword = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FastitEmail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FastitPassword = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Process = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cittizenships",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCustomer = table.Column<int>(type: "int", nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    CustomerCompleteName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ContractorEmail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ContractorPhone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cittizenships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cittizenships_Customers_IdCustomer",
                        column: x => x.IdCustomer,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cittizenships_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Passports",
                columns: table => new
                {
                    IdSchedulePassport = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCustomer = table.Column<int>(type: "int", nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    ContractorCompleteName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ContractorEmail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ContractorCPF = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    ContractorPhone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    PrenotamiEmail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PrenotamiPassword = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FastitEmail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FastitPassword = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DateUnavailability = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HaveExpiredItalianPassport = table.Column<bool>(type: "bit", nullable: false),
                    HaveMinorChildren = table.Column<bool>(type: "bit", nullable: false),
                    NumberOfMinorChildren = table.Column<int>(type: "int", nullable: false),
                    CompleteResidentialAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CivilState = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DateOfExpiredItalianPassport = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MinorsCompleteNames = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passports", x => x.IdSchedulePassport);
                    table.ForeignKey(
                        name: "FK_Passports_Customers_IdCustomer",
                        column: x => x.IdCustomer,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Passports_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cittizenships_IdCustomer",
                table: "Cittizenships",
                column: "IdCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_Cittizenships_IdUser",
                table: "Cittizenships",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Passports_IdCustomer",
                table: "Passports",
                column: "IdCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_Passports_IdUser",
                table: "Passports",
                column: "IdUser");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cittizenships");

            migrationBuilder.DropTable(
                name: "Passports");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
