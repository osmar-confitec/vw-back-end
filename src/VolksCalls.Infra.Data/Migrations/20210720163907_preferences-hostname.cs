using Microsoft.EntityFrameworkCore.Migrations;

namespace VolksCalls.Infra.Data.Migrations
{
    public partial class preferenceshostname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HostName",
                table: "CallsPreferences",
                type: "varchar(200)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HostName",
                table: "CallsPreferences");
        }
    }
}
