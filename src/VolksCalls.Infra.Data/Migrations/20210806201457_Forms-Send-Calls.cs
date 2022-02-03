using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VolksCalls.Infra.Data.Migrations
{
    public partial class FormsSendCalls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CallForm",
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
                    Name = table.Column<string>(type: "varchar(200)", nullable: true),
                    CallFormType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CallForm", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CallFormQuestions",
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
                    QuestionType = table.Column<int>(nullable: false),
                    CallFormQuestionType = table.Column<int>(nullable: false),
                    Key = table.Column<string>(type: "varchar(50)", nullable: true),
                    Label = table.Column<string>(type: "text", nullable: true),
                    Required = table.Column<bool>(nullable: false),
                    Order = table.Column<int>(nullable: false),
                    CallFormId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CallFormQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CallFormQuestions_CallForm_CallFormId",
                        column: x => x.CallFormId,
                        principalTable: "CallForm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CallFormQuestions_CallFormId",
                table: "CallFormQuestions",
                column: "CallFormId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CallFormQuestions");

            migrationBuilder.DropTable(
                name: "CallForm");
        }
    }
}
