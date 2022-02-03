using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VolksCalls.Infra.Data.Migrations
{
    public partial class CallsPreferences : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CallsPreferences",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    DateRegister = table.Column<DateTime>(nullable: false),
                    DateUpdate = table.Column<DateTime>(nullable: true),
                    UserInsertedId = table.Column<Guid>(nullable: false),
                    UserUpdatedId = table.Column<Guid>(nullable: true),
                    DeleteDate = table.Column<DateTime>(nullable: true),
                    UserDeletedId = table.Column<Guid>(nullable: true),
                    UserId = table.Column<string>(type: "varchar(20)", nullable: true),
                    Telephone = table.Column<string>(type: "varchar(20)", nullable: true),
                    CellPhone = table.Column<string>(type: "varchar(20)", nullable: true),
                    WorkSchedule = table.Column<int>(nullable: false),
                    Collaborator = table.Column<int>(nullable: false),
                    Locality = table.Column<int>(nullable: false),
                    Reference = table.Column<string>(type: "varchar(50)", nullable: true),
                    Ala = table.Column<int>(nullable: false),
                    Column = table.Column<string>(type: "varchar(50)", nullable: true),
                    NameContact = table.Column<string>(type: "varchar(200)", nullable: true),
                    PhoneContact = table.Column<string>(type: "varchar(20)", nullable: true),
                    EmailContact = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CallsPreferences", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CallsPreferences");
        }
    }
}
