using Microsoft.EntityFrameworkCore.Migrations;

namespace VolksCalls.Infra.Data.Migrations
{
    public partial class removefieldmanagedby : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Departament",
                table: "ManagedBy");

            migrationBuilder.DropColumn(
                name: "Management",
                table: "ManagedBy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Departament",
                table: "ManagedBy",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Management",
                table: "ManagedBy",
                type: "varchar(200)",
                nullable: true);
        }
    }
}
