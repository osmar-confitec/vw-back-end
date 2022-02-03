using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace VolksCalls.Infra.Data.Migrations
{
    public partial class ModulesCallForm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            /*module*/

            migrationBuilder.InsertData(
                       table: "Modules",
                       columns: new[]
                                 {
                            "Id",
                            "Active",
                            "DateRegister",
                            "UserInsertedId",
                            "Name"
                                 },
                                 values: new object[]
                                 {
                             "17398586-fa11-11eb-a3d5-0c29effdff40",
                            true,
                            DateTime.Now,
                            "04521540-E429-4685-133A-08D909A63807",
                            "CallForm"
                                 });

            /*actions module*/
            /*exibir*/
            migrationBuilder.InsertData(
                     table: "ModulesActions",
                     columns: new[]
                               {
                            "Id",
                            "Active",
                            "DateRegister",
                            "UserInsertedId",
                            "ActionName",
                            "ModulesId"
                               },
                               values: new object[]
                               {
                             "4a46fedf-fa11-11eb-a3d5-0c29effdff40",
                            true,
                            DateTime.Now,
                            "04521540-E429-4685-133A-08D909A63807",
                            "View",
                            "17398586-fa11-11eb-a3d5-0c29effdff40"
                               });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DeleteData(table: "ModulesActions", "Id", "4a46fedf-fa11-11eb-a3d5-0c29effdff40");
            migrationBuilder.DeleteData(table: "Modules", "Id", "17398586-fa11-11eb-a3d5-0c29effdff40");

        }
    }
}
