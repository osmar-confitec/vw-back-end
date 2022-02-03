using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace VolksCalls.Infra.Data.Migrations
{
    public partial class UnlockingNetworkUsers : Migration
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
                             "ae0ce015-e658-11eb-9014-0c29effdff40",
                            true,
                            DateTime.Now,
                            "04521540-E429-4685-133A-08D909A63807",
                            "UnlockingNetworkUsers"
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
                             "bd3c6ae3-e658-11eb-9014-0c29effdff40",
                            true,
                            DateTime.Now,
                            "04521540-E429-4685-133A-08D909A63807",
                            "View",
                            "ae0ce015-e658-11eb-9014-0c29effdff40"
                               });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DeleteData(table: "ModulesActions", "Id", "bd3c6ae3-e658-11eb-9014-0c29effdff40");
            migrationBuilder.DeleteData(table: "Modules", "Id", "ae0ce015-e658-11eb-9014-0c29effdff40");

        }
    }
}
