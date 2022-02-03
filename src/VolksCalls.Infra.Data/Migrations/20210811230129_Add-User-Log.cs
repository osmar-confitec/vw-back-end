using Microsoft.EntityFrameworkCore.Migrations;

namespace VolksCalls.Infra.Data.Migrations
{
    public partial class AddUserLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserAdDeletedId",
                table: "UsersModulesActions",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserAdInsertedId",
                table: "UsersModulesActions",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserAdUpdatedId",
                table: "UsersModulesActions",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserAdDeletedId",
                table: "TblCallsCategory",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserAdInsertedId",
                table: "TblCallsCategory",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserAdUpdatedId",
                table: "TblCallsCategory",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserAdDeletedId",
                table: "ModulesActions",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserAdInsertedId",
                table: "ModulesActions",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserAdUpdatedId",
                table: "ModulesActions",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserAdDeletedId",
                table: "Modules",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserAdInsertedId",
                table: "Modules",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserAdUpdatedId",
                table: "Modules",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserAdDeletedId",
                table: "ManagedBy",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserAdInsertedId",
                table: "ManagedBy",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserAdUpdatedId",
                table: "ManagedBy",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserAdDeletedId",
                table: "LogEvent",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserAdInsertedId",
                table: "LogEvent",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserAdUpdatedId",
                table: "LogEvent",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserAdDeletedId",
                table: "CI",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserAdInsertedId",
                table: "CI",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserAdUpdatedId",
                table: "CI",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserAdDeletedId",
                table: "CallsPreferences",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserAdInsertedId",
                table: "CallsPreferences",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserAdUpdatedId",
                table: "CallsPreferences",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserAdDeletedId",
                table: "CallFormQuestions",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserAdInsertedId",
                table: "CallFormQuestions",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserAdUpdatedId",
                table: "CallFormQuestions",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserAdDeletedId",
                table: "CallForm",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserAdInsertedId",
                table: "CallForm",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserAdUpdatedId",
                table: "CallForm",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserAdDeletedId",
                table: "CallCategoriesList",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserAdInsertedId",
                table: "CallCategoriesList",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserAdUpdatedId",
                table: "CallCategoriesList",
                type: "varchar(200)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserAdDeletedId",
                table: "UsersModulesActions");

            migrationBuilder.DropColumn(
                name: "UserAdInsertedId",
                table: "UsersModulesActions");

            migrationBuilder.DropColumn(
                name: "UserAdUpdatedId",
                table: "UsersModulesActions");

            migrationBuilder.DropColumn(
                name: "UserAdDeletedId",
                table: "TblCallsCategory");

            migrationBuilder.DropColumn(
                name: "UserAdInsertedId",
                table: "TblCallsCategory");

            migrationBuilder.DropColumn(
                name: "UserAdUpdatedId",
                table: "TblCallsCategory");

            migrationBuilder.DropColumn(
                name: "UserAdDeletedId",
                table: "ModulesActions");

            migrationBuilder.DropColumn(
                name: "UserAdInsertedId",
                table: "ModulesActions");

            migrationBuilder.DropColumn(
                name: "UserAdUpdatedId",
                table: "ModulesActions");

            migrationBuilder.DropColumn(
                name: "UserAdDeletedId",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "UserAdInsertedId",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "UserAdUpdatedId",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "UserAdDeletedId",
                table: "ManagedBy");

            migrationBuilder.DropColumn(
                name: "UserAdInsertedId",
                table: "ManagedBy");

            migrationBuilder.DropColumn(
                name: "UserAdUpdatedId",
                table: "ManagedBy");

            migrationBuilder.DropColumn(
                name: "UserAdDeletedId",
                table: "LogEvent");

            migrationBuilder.DropColumn(
                name: "UserAdInsertedId",
                table: "LogEvent");

            migrationBuilder.DropColumn(
                name: "UserAdUpdatedId",
                table: "LogEvent");

            migrationBuilder.DropColumn(
                name: "UserAdDeletedId",
                table: "CI");

            migrationBuilder.DropColumn(
                name: "UserAdInsertedId",
                table: "CI");

            migrationBuilder.DropColumn(
                name: "UserAdUpdatedId",
                table: "CI");

            migrationBuilder.DropColumn(
                name: "UserAdDeletedId",
                table: "CallsPreferences");

            migrationBuilder.DropColumn(
                name: "UserAdInsertedId",
                table: "CallsPreferences");

            migrationBuilder.DropColumn(
                name: "UserAdUpdatedId",
                table: "CallsPreferences");

            migrationBuilder.DropColumn(
                name: "UserAdDeletedId",
                table: "CallFormQuestions");

            migrationBuilder.DropColumn(
                name: "UserAdInsertedId",
                table: "CallFormQuestions");

            migrationBuilder.DropColumn(
                name: "UserAdUpdatedId",
                table: "CallFormQuestions");

            migrationBuilder.DropColumn(
                name: "UserAdDeletedId",
                table: "CallForm");

            migrationBuilder.DropColumn(
                name: "UserAdInsertedId",
                table: "CallForm");

            migrationBuilder.DropColumn(
                name: "UserAdUpdatedId",
                table: "CallForm");

            migrationBuilder.DropColumn(
                name: "UserAdDeletedId",
                table: "CallCategoriesList");

            migrationBuilder.DropColumn(
                name: "UserAdInsertedId",
                table: "CallCategoriesList");

            migrationBuilder.DropColumn(
                name: "UserAdUpdatedId",
                table: "CallCategoriesList");
        }
    }
}
