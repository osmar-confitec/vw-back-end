using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace VolksCalls.Infra.Data.Migrations
{
    public partial class PopulateUsersCI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            /*module*/

            migrationBuilder.InsertData(
                       table: "UsersModulesActions",
                       columns: new[]
                                 {
                           "Id",
                            "Active",
                            "DateRegister",
                            "DateUpdate",
                            "UserInsertedId",
                            "UserUpdatedId",
                            "DeleteDate",
                            "UserDeletedId",
                            "UserId",
                            "ModulesActionsId"
                                 },
                                 values: new object[]
                                 {
                             "47b88eaf-eb3f-11eb-9014-0c29effdff40",
                            true,
                            DateTime.Now,
                            null,
                            "04521540-E429-4685-133A-08D909A63807",
                            null,
                            null,
                            null,
                            "AB0IE3Z",
                            "3ee61b62-eaf3-11eb-9014-0c29effdff40"
                                 });

            migrationBuilder.InsertData(
                     table: "UsersModulesActions",
                     columns: new[]
                               {
                           "Id",
                            "Active",
                            "DateRegister",
                            "DateUpdate",
                            "UserInsertedId",
                            "UserUpdatedId",
                            "DeleteDate",
                            "UserDeletedId",
                            "UserId",
                            "ModulesActionsId"
                               },
                               values: new object[]
                               {
                             "4d548bb8-eb3f-11eb-9014-0c29effdff40",
                            true,
                            DateTime.Now,
                            null,
                            "04521540-E429-4685-133A-08D909A63807",
                            null,
                            null,
                            null,
                            "TB0IE3Z",
                            "3ee61b62-eaf3-11eb-9014-0c29effdff40"
                               });

            migrationBuilder.InsertData(
                     table: "UsersModulesActions",
                     columns: new[]
                               {
                           "Id",
                            "Active",
                            "DateRegister",
                            "DateUpdate",
                            "UserInsertedId",
                            "UserUpdatedId",
                            "DeleteDate",
                            "UserDeletedId",
                            "UserId",
                            "ModulesActionsId"
                               },
                               values: new object[]
                               {
                             "5320cd46-eb3f-11eb-9014-0c29effdff40",
                            true,
                            DateTime.Now,
                            null,
                            "04521540-E429-4685-133A-08D909A63807",
                            null,
                            null,
                            null,
                            "TLXXB28",
                            "3ee61b62-eaf3-11eb-9014-0c29effdff40"
                               });

            migrationBuilder.InsertData(
                 table: "UsersModulesActions",
                 columns: new[]
                           {
                           "Id",
                            "Active",
                            "DateRegister",
                            "DateUpdate",
                            "UserInsertedId",
                            "UserUpdatedId",
                            "DeleteDate",
                            "UserDeletedId",
                            "UserId",
                            "ModulesActionsId"
                           },
                           values: new object[]
                           {
                             "5cb82f45-eb3f-11eb-9014-0c29effdff40",
                            true,
                            DateTime.Now,
                            null,
                            "04521540-E429-4685-133A-08D909A63807",
                            null,
                            null,
                            null,
                            "EULHEWF",
                            "3ee61b62-eaf3-11eb-9014-0c29effdff40"
                           });

            migrationBuilder.InsertData(
               table: "UsersModulesActions",
               columns: new[]
                         {
                           "Id",
                            "Active",
                            "DateRegister",
                            "DateUpdate",
                            "UserInsertedId",
                            "UserUpdatedId",
                            "DeleteDate",
                            "UserDeletedId",
                            "UserId",
                            "ModulesActionsId"
                         },
                         values: new object[]
                         {
                             "620741fa-eb3f-11eb-9014-0c29effdff40",
                            true,
                            DateTime.Now,
                            null,
                            "04521540-E429-4685-133A-08D909A63807",
                            null,
                            null,
                            null,
                            "F2ERNUF",
                            "3ee61b62-eaf3-11eb-9014-0c29effdff40"
                         });

            migrationBuilder.InsertData(
             table: "UsersModulesActions",
             columns: new[]
                       {
                           "Id",
                            "Active",
                            "DateRegister",
                            "DateUpdate",
                            "UserInsertedId",
                            "UserUpdatedId",
                            "DeleteDate",
                            "UserDeletedId",
                            "UserId",
                            "ModulesActionsId"
                       },
                       values: new object[]
                       {
                             "67e9f9c6-eb3f-11eb-9014-0c29effdff40",
                            true,
                            DateTime.Now,
                            null,
                            "04521540-E429-4685-133A-08D909A63807",
                            null,
                            null,
                            null,
                            "UVQXKKQ",
                            "3ee61b62-eaf3-11eb-9014-0c29effdff40"
                       });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DeleteData(table: "UsersModulesActions", "Id", "47b88eaf-eb3f-11eb-9014-0c29effdff40");
            migrationBuilder.DeleteData(table: "UsersModulesActions", "Id", "4d548bb8-eb3f-11eb-9014-0c29effdff40");
            migrationBuilder.DeleteData(table: "UsersModulesActions", "Id", "5320cd46-eb3f-11eb-9014-0c29effdff40");
            migrationBuilder.DeleteData(table: "UsersModulesActions", "Id", "5cb82f45-eb3f-11eb-9014-0c29effdff40");
            migrationBuilder.DeleteData(table: "UsersModulesActions", "Id", "620741fa-eb3f-11eb-9014-0c29effdff40");
            migrationBuilder.DeleteData(table: "UsersModulesActions", "Id", "67e9f9c6-eb3f-11eb-9014-0c29effdff40");


        }

    }
}
