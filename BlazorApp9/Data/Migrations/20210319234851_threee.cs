using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class threee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Solutions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solutions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    konto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titel_nr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    budget_2021 = table.Column<decimal>(type: "decimal(26,6)", nullable: false),
                    budget_2020 = table.Column<decimal>(type: "decimal(26,6)", nullable: false),
                    rechnung_2019 = table.Column<decimal>(type: "decimal(26,6)", nullable: false),
                    aufwandertrag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    abweichungvomvorjahresbudget = table.Column<int>(type: "int", nullable: false),
                    ebene2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ebene1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    zeilennummer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    kontotitel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    kontostruktur = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    typ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolutionDesiredId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_Solutions_SolutionDesiredId",
                        column: x => x.SolutionDesiredId,
                        principalTable: "Solutions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CommentToOrdering",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolutionDesiredId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentToOrdering", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentToOrdering_Solutions_SolutionDesiredId",
                        column: x => x.SolutionDesiredId,
                        principalTable: "Solutions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VoteToOrdering",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolutionDesiredId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoteToOrdering", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VoteToOrdering_Solutions_SolutionDesiredId",
                        column: x => x.SolutionDesiredId,
                        principalTable: "Solutions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_SolutionDesiredId",
                table: "Accounts",
                column: "SolutionDesiredId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentToOrdering_SolutionDesiredId",
                table: "CommentToOrdering",
                column: "SolutionDesiredId");

            migrationBuilder.CreateIndex(
                name: "IX_VoteToOrdering_SolutionDesiredId",
                table: "VoteToOrdering",
                column: "SolutionDesiredId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "CommentToOrdering");

            migrationBuilder.DropTable(
                name: "VoteToOrdering");

            migrationBuilder.DropTable(
                name: "Solutions");
        }
    }
}
