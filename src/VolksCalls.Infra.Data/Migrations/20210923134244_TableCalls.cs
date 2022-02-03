using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VolksCalls.Infra.Data.Migrations
{
    public partial class TableCalls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Calls",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    DateRegister = table.Column<DateTime>(nullable: false),
                    DateUpdate = table.Column<DateTime>(nullable: true),
                    UserInsertedId = table.Column<Guid>(nullable: false),
                    UserAdInsertedId = table.Column<string>(type: "varchar(200)", nullable: true),
                    UserUpdatedId = table.Column<Guid>(nullable: true),
                    UserAdUpdatedId = table.Column<string>(type: "varchar(200)", nullable: true),
                    DeleteDate = table.Column<DateTime>(nullable: true),
                    UserDeletedId = table.Column<Guid>(nullable: true),
                    UserAdDeletedId = table.Column<string>(type: "varchar(200)", nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", nullable: true),
                    Vip = table.Column<bool>(nullable: false),
                    StatusCalls = table.Column<int>(nullable: false),
                    HostName = table.Column<string>(type: "varchar(200)", nullable: true),
                    Name = table.Column<string>(type: "varchar(200)", nullable: true),
                    Telephone = table.Column<string>(type: "varchar(20)", nullable: true),
                    UserId = table.Column<string>(type: "varchar(20)", nullable: true),
                    Plate = table.Column<string>(type: "varchar(50)", nullable: true),
                    CellPhone = table.Column<string>(type: "varchar(20)", nullable: true),
                    WorkSchedule = table.Column<int>(nullable: false),
                    Collaborator = table.Column<int>(nullable: false),
                    Locality = table.Column<int>(nullable: false),
                    Reference = table.Column<string>(type: "varchar(50)", nullable: true),
                    Ala = table.Column<int>(nullable: false),
                    Floor = table.Column<int>(nullable: false),
                    Side = table.Column<int>(nullable: false),
                    Column = table.Column<string>(type: "varchar(50)", nullable: true),
                    NameContact = table.Column<string>(type: "varchar(200)", nullable: true),
                    PhoneContact = table.Column<string>(type: "varchar(20)", nullable: true),
                    EmailContact = table.Column<string>(type: "varchar(50)", nullable: true),
                    Title = table.Column<string>(type: "varchar(200)", nullable: true),
                    Description = table.Column<string>(type: "Text", nullable: true),
                    CallsCategoryId = table.Column<Guid>(nullable: false),
                    CallFormId = table.Column<Guid>(nullable: true),
                    CIName = table.Column<string>(type: "varchar(200)", nullable: true),
                    CIId = table.Column<string>(type: "varchar(200)", nullable: true),
                    CIQuee = table.Column<string>(type: "varchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Calls_CallForm_CallFormId",
                        column: x => x.CallFormId,
                        principalTable: "CallForm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Calls_TblCallsCategory_CallsCategoryId",
                        column: x => x.CallsCategoryId,
                        principalTable: "TblCallsCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Archive",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    DateRegister = table.Column<DateTime>(nullable: false),
                    DateUpdate = table.Column<DateTime>(nullable: true),
                    UserInsertedId = table.Column<Guid>(nullable: false),
                    UserAdInsertedId = table.Column<string>(type: "varchar(200)", nullable: true),
                    UserUpdatedId = table.Column<Guid>(nullable: true),
                    UserAdUpdatedId = table.Column<string>(type: "varchar(200)", nullable: true),
                    DeleteDate = table.Column<DateTime>(nullable: true),
                    UserDeletedId = table.Column<Guid>(nullable: true),
                    UserAdDeletedId = table.Column<string>(type: "varchar(200)", nullable: true),
                    FileName = table.Column<string>(type: "varchar(200)", nullable: true),
                    Identity = table.Column<Guid>(nullable: false),
                    TypeFile = table.Column<int>(nullable: false),
                    Size = table.Column<long>(nullable: false),
                    CallsDomainId = table.Column<Guid>(nullable: true),
                    FileLocation = table.Column<int>(nullable: false),
                    Path = table.Column<string>(type: "varchar(200)", nullable: true),
                    Base64 = table.Column<string>(type: "Text", nullable: true),
                    Extension = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Archive", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Archive_Calls_CallsDomainId",
                        column: x => x.CallsDomainId,
                        principalTable: "Calls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Archive_CallsDomainId",
                table: "Archive",
                column: "CallsDomainId");

            migrationBuilder.CreateIndex(
                name: "IX_Calls_CallFormId",
                table: "Calls",
                column: "CallFormId");

            migrationBuilder.CreateIndex(
                name: "IX_Calls_CallsCategoryId",
                table: "Calls",
                column: "CallsCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Archive");

            migrationBuilder.DropTable(
                name: "Calls");
        }
    }
}
