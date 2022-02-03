﻿using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace VolksCalls.Infra.Data.Migrations
{
    public partial class ModulesCallingCategories : Migration
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
                             "31f4b07c-e658-11eb-9014-0c29effdff40",
                            true,
                            DateTime.Now,
                            "04521540-E429-4685-133A-08D909A63807",
                            "CallingCategories"
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
                             "3e08bd65-e658-11eb-9014-0c29effdff40",
                            true,
                            DateTime.Now,
                            "04521540-E429-4685-133A-08D909A63807",
                            "View",
                            "31f4b07c-e658-11eb-9014-0c29effdff40"
                               });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DeleteData(table: "ModulesActions", "Id", "3e08bd65-e658-11eb-9014-0c29effdff40");
            migrationBuilder.DeleteData(table: "Modules", "Id", "31f4b07c-e658-11eb-9014-0c29effdff40");

        }
    }
}
