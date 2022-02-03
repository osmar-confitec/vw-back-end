using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VolksCalls.Infra.Data.Migrations
{
    public partial class CallformCategoryForm2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CallsFormsId",
                table: "TblCallsCategory",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TblCallsCategory_CallsFormsId",
                table: "TblCallsCategory",
                column: "CallsFormsId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblCallsCategory_CallForm_CallsFormsId",
                table: "TblCallsCategory",
                column: "CallsFormsId",
                principalTable: "CallForm",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblCallsCategory_CallForm_CallsFormsId",
                table: "TblCallsCategory");

            migrationBuilder.DropIndex(
                name: "IX_TblCallsCategory_CallsFormsId",
                table: "TblCallsCategory");

            migrationBuilder.DropColumn(
                name: "CallsFormsId",
                table: "TblCallsCategory");
        }
    }
}
