using Microsoft.EntityFrameworkCore.Migrations;

namespace VolksCalls.Infra.Data.Migrations
{
    public partial class DropDownItens : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DropdownItens",
                table: "CallForm");

            migrationBuilder.AddColumn<string>(
                name: "DropdownItens",
                table: "CallFormQuestions",
                type: "varchar(200)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DropdownItens",
                table: "CallFormQuestions");

            migrationBuilder.AddColumn<string>(
                name: "DropdownItens",
                table: "CallForm",
                type: "varchar(200)",
                nullable: true);
        }
    }
}
