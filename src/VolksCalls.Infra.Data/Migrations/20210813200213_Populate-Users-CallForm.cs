using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace VolksCalls.Infra.Data.Migrations
{
    public partial class PopulateUsersCallForm : Migration
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
                             "0407db73-fc73-11eb-8a38-0c29effdff40",
                            true,
                            DateTime.Now,
                            null,
                            "04521540-E429-4685-133A-08D909A63807",
                            null,
                            null,
                            null,
                            "AB0IE3Z",
                            "4a46fedf-fa11-11eb-a3d5-0c29effdff40"
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
                             "11152292-fc73-11eb-8a38-0c29effdff40",
                            true,
                            DateTime.Now,
                            null,
                            "04521540-E429-4685-133A-08D909A63807",
                            null,
                            null,
                            null,
                            "TB0IE3Z",
                            "4a46fedf-fa11-11eb-a3d5-0c29effdff40"
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
                             "170f8953-fc73-11eb-8a38-0c29effdff40",
                            true,
                            DateTime.Now,
                            null,
                            "04521540-E429-4685-133A-08D909A63807",
                            null,
                            null,
                            null,
                            "TLXXB28",
                            "4a46fedf-fa11-11eb-a3d5-0c29effdff40"
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
                             "1e8a2329-fc73-11eb-8a38-0c29effdff40",
                            true,
                            DateTime.Now,
                            null,
                            "04521540-E429-4685-133A-08D909A63807",
                            null,
                            null,
                            null,
                            "EULHEWF",
                            "4a46fedf-fa11-11eb-a3d5-0c29effdff40"
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
                             "233e4693-fc73-11eb-8a38-0c29effdff40",
                            true,
                            DateTime.Now,
                            null,
                            "04521540-E429-4685-133A-08D909A63807",
                            null,
                            null,
                            null,
                            "F2ERNUF",
                            "4a46fedf-fa11-11eb-a3d5-0c29effdff40"
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
                             "28717fb5-fc73-11eb-8a38-0c29effdff40",
                            true,
                            DateTime.Now,
                            null,
                            "04521540-E429-4685-133A-08D909A63807",
                            null,
                            null,
                            null,
                            "UVQXKKQ",
                            "4a46fedf-fa11-11eb-a3d5-0c29effdff40"
                       });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DeleteData(table: "UsersModulesActions", "Id", "0407db73-fc73-11eb-8a38-0c29effdff40");
            migrationBuilder.DeleteData(table: "UsersModulesActions", "Id", "11152292-fc73-11eb-8a38-0c29effdff40");
            migrationBuilder.DeleteData(table: "UsersModulesActions", "Id", "170f8953-fc73-11eb-8a38-0c29effdff40");
            migrationBuilder.DeleteData(table: "UsersModulesActions", "Id", "1e8a2329-fc73-11eb-8a38-0c29effdff40");
            migrationBuilder.DeleteData(table: "UsersModulesActions", "Id", "233e4693-fc73-11eb-8a38-0c29effdff40");
            migrationBuilder.DeleteData(table: "UsersModulesActions", "Id", "28717fb5-fc73-11eb-8a38-0c29effdff40");


        }

    }
}
