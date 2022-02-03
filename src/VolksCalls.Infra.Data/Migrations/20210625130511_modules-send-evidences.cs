using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace VolksCalls.Infra.Data.Migrations
{
    public partial class modulessendevidences : Migration
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
                             "2EA1F99C-CC73-450B-B8DA-E9754C737D15",
                            true,
                            DateTime.Now,
                            "04521540-E429-4685-133A-08D909A63807",
                            "SendEvidences"
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
                             "6D86EC9D-6360-4309-9CED-D5A5DF60B9C0",
                            true,
                            DateTime.Now,
                            "04521540-E429-4685-133A-08D909A63807",
                            "View",
                            "2EA1F99C-CC73-450B-B8DA-E9754C737D15"
                               });

            /*alterar*/
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
                             "0C284055-6668-4E31-B708-56AB9EACF656",
                            true,
                            DateTime.Now,
                            "04521540-E429-4685-133A-08D909A63807",
                            "Change",
                            "2EA1F99C-CC73-450B-B8DA-E9754C737D15"
                               });

            /*deletar*/
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
                             "174C91DD-7BE6-4E30-B979-AAAA05B42E00",
                            true,
                            DateTime.Now,
                            "04521540-E429-4685-133A-08D909A63807",
                            "Delete",
                            "2EA1F99C-CC73-450B-B8DA-E9754C737D15"
                               });

            /*inserir*/
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
                             "9CB13EAA-BC3D-4BB2-891B-146C63AD5657",
                            true,
                            DateTime.Now,
                            "04521540-E429-4685-133A-08D909A63807",
                            "Insert",
                            "2EA1F99C-CC73-450B-B8DA-E9754C737D15"
                               });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(table: "ModulesActions", "Id", "6D86EC9D-6360-4309-9CED-D5A5DF60B9C0");
            migrationBuilder.DeleteData(table: "ModulesActions", "Id", "0C284055-6668-4E31-B708-56AB9EACF656");
            migrationBuilder.DeleteData(table: "ModulesActions", "Id", "174C91DD-7BE6-4E30-B979-AAAA05B42E00");
            migrationBuilder.DeleteData(table: "ModulesActions", "Id", "9CB13EAA-BC3D-4BB2-891B-146C63AD5657");

            migrationBuilder.DeleteData(table: "Modules", "Id", "2EA1F99C-CC73-450B-B8DA-E9754C737D15");

        }
    }
}
