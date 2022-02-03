using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VolksCalls.Infra.Data.Migrations
{
    public partial class CallCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CallCategoriesList",
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
                    DescriptionFirst = table.Column<string>(type: "varchar(200)", nullable: true),
                    IdFirst = table.Column<Guid>(nullable: false),
                    DescriptionSecond = table.Column<string>(type: "varchar(200)", nullable: true),
                    IdSecond = table.Column<Guid>(nullable: false),
                    DescriptionThird = table.Column<string>(type: "varchar(200)", nullable: true),
                    IdThird = table.Column<Guid>(nullable: false),
                    DescriptionFour = table.Column<string>(type: "varchar(200)", nullable: true),
                    IdFour = table.Column<Guid>(nullable: false),
                    CICode = table.Column<Guid>(nullable: false),
                    CIId = table.Column<string>(type: "varchar(20)", nullable: true),
                    CIName = table.Column<string>(type: "varchar(200)", nullable: true),
                    CallGroup = table.Column<string>(type: "varchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CallCategoriesList", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CallCategoriesList");
        }
    }
}
