using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace VolksCalls.Infra.Data.Migrations
{
    public partial class PopulateFirstUsersCallingCategories : Migration
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
                             "08de6c90-e65e-11eb-9014-0c29effdff40",
                            true,
                            DateTime.Now,
                            null, 
                            "04521540-E429-4685-133A-08D909A63807",
                            null,
                            null,
                            null,
                            "AB0IE3Z",
                            "3e08bd65-e658-11eb-9014-0c29effdff40"
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
                             "745b7b00-e65e-11eb-9014-0c29effdff40",
                            true,
                            DateTime.Now,
                            null,
                            "04521540-E429-4685-133A-08D909A63807",
                            null,
                            null,
                            null,
                            "TB0IE3Z",
                            "3e08bd65-e658-11eb-9014-0c29effdff40"
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
                             "a3c92aa7-e65e-11eb-9014-0c29effdff40",
                            true,
                            DateTime.Now,
                            null,
                            "04521540-E429-4685-133A-08D909A63807",
                            null,
                            null,
                            null,
                            "TLXXB28",
                            "3e08bd65-e658-11eb-9014-0c29effdff40"
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
                             "afa53a95-e65e-11eb-9014-0c29effdff40",
                            true,
                            DateTime.Now,
                            null,
                            "04521540-E429-4685-133A-08D909A63807",
                            null,
                            null,
                            null,
                            "EULHEWF",
                            "3e08bd65-e658-11eb-9014-0c29effdff40"
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
                             "be0bcec6-e65e-11eb-9014-0c29effdff40",
                            true,
                            DateTime.Now,
                            null,
                            "04521540-E429-4685-133A-08D909A63807",
                            null,
                            null,
                            null,
                            "F2ERNUF",
                            "3e08bd65-e658-11eb-9014-0c29effdff40"
                         });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DeleteData(table: "UsersModulesActions", "Id", "08de6c90-e65e-11eb-9014-0c29effdff40");
            migrationBuilder.DeleteData(table: "UsersModulesActions", "Id", "745b7b00-e65e-11eb-9014-0c29effdff40");
            migrationBuilder.DeleteData(table: "UsersModulesActions", "Id", "a3c92aa7-e65e-11eb-9014-0c29effdff40");
            migrationBuilder.DeleteData(table: "UsersModulesActions", "Id", "afa53a95-e65e-11eb-9014-0c29effdff40");
            migrationBuilder.DeleteData(table: "UsersModulesActions", "Id", "be0bcec6-e65e-11eb-9014-0c29effdff40");



        }
    }
}
