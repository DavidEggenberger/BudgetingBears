using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class two : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Cost2019",
                table: "Posts",
                type: "decimal(26,6)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ChangeToPrevious",
                table: "Posts",
                type: "decimal(26,6)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Budget2021",
                table: "Posts",
                type: "decimal(26,6)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Budget2020",
                table: "Posts",
                type: "decimal(26,6)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Cost2019",
                table: "Posts",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(26,6)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ChangeToPrevious",
                table: "Posts",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(26,6)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Budget2021",
                table: "Posts",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(26,6)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Budget2020",
                table: "Posts",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(26,6)");
        }
    }
}
