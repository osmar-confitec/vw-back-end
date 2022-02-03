using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VolksCalls.Infra.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CI",
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
                    CIName = table.Column<string>(type: "varchar(200)", nullable: true),
                    CIId = table.Column<string>(type: "varchar(200)", nullable: true),
                    CallGroup = table.Column<string>(type: "varchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CI", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblCallsCategory",
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
                    Description = table.Column<string>(type: "varchar(200)", nullable: true),
                    CallsCategoryParentId = table.Column<Guid>(nullable: true),
                    QtdChildren = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    CIId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCallsCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblCallsCategory_CI_CIId",
                        column: x => x.CIId,
                        principalTable: "CI",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblCallsCategory_TblCallsCategory_CallsCategoryParentId",
                        column: x => x.CallsCategoryParentId,
                        principalTable: "TblCallsCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblCallsCategory_CIId",
                table: "TblCallsCategory",
                column: "CIId");

            migrationBuilder.CreateIndex(
                name: "IX_TblCallsCategory_CallsCategoryParentId",
                table: "TblCallsCategory",
                column: "CallsCategoryParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblCallsCategory");

            migrationBuilder.DropTable(
                name: "CI");
        }
    }
}
