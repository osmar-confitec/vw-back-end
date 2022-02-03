using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VolksCalls.Infra.Data.Migrations
{
    public partial class ManagentBy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ManagedBy",
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
                    MachineName = table.Column<string>(nullable: true),
                    MachineType = table.Column<string>(type: "varchar(200)", nullable: true),
                    SerialNumber = table.Column<string>(type: "varchar(200)", nullable: true),
                    UserId = table.Column<string>(type: "varchar(20)", nullable: true),
                    Monitor1 = table.Column<string>(nullable: true),
                    Monitor1Model = table.Column<string>(type: "varchar(200)", nullable: true),
                    Monitor1Brand = table.Column<string>(type: "varchar(200)", nullable: true),
                    Monitor1SerialNumber = table.Column<string>(type: "varchar(200)", nullable: true),
                    Monitor2Brand = table.Column<string>(type: "varchar(200)", nullable: true),
                    Monitor2Model = table.Column<string>(type: "varchar(200)", nullable: true),
                    Monitor2SerialNumber = table.Column<string>(type: "varchar(200)", nullable: true),
                    Monitor3SerialNumber = table.Column<string>(type: "varchar(200)", nullable: true),
                    Monitor3Brand = table.Column<string>(type: "varchar(200)", nullable: true),
                    Monitor3Model = table.Column<string>(type: "varchar(200)", nullable: true),
                    Plant = table.Column<string>(type: "varchar(200)", nullable: true),
                    Wing = table.Column<string>(type: "varchar(200)", nullable: true),
                    Floor = table.Column<string>(type: "varchar(200)", nullable: true),
                    Column = table.Column<string>(type: "varchar(200)", nullable: true),
                    Extension = table.Column<string>(type: "varchar(200)", nullable: true),
                    Side = table.Column<string>(type: "varchar(200)", nullable: true),
                    Collective = table.Column<string>(type: "varchar(200)", nullable: true),
                    Departament = table.Column<string>(type: "varchar(200)", nullable: true),
                    UO = table.Column<string>(type: "varchar(200)", nullable: true),
                    Management = table.Column<string>(type: "varchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagedBy", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ManagedBy");
        }
    }
}
