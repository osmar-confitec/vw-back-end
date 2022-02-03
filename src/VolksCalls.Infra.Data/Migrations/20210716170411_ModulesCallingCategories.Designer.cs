﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VolksCalls.Infra.Data.Context;

namespace VolksCalls.Infra.Data.Migrations
{
    [DbContext(typeof(AplicationContext))]
    [Migration("20210716170411_ModulesCallingCategories")]
    partial class ModulesCallingCategories
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("VolksCalls.Domain.Models.CI.CIDomain", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("Active")
                        .HasColumnName("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("CIId")
                        .HasColumnName("CIId")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("CIName")
                        .HasColumnName("CIName")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("CallGroup")
                        .HasColumnName("CallGroup")
                        .HasColumnType("varchar(200)");

                    b.Property<DateTime>("DateRegister")
                        .HasColumnName("DateRegister")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DateUpdate")
                        .HasColumnName("DateUpdate")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("DefaultCI")
                        .HasColumnName("DefaultCI")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnName("DeleteDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("UserDeletedId")
                        .HasColumnName("UserDeletedId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("UserInsertedId")
                        .HasColumnName("UserInsertedId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("UserUpdatedId")
                        .HasColumnName("UserUpdatedId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("CI");
                });

            modelBuilder.Entity("VolksCalls.Domain.Models.CallCategoriesList.CallCategoriesListDomain", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("Active")
                        .HasColumnName("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid?>("CICode")
                        .HasColumnName("CICode")
                        .HasColumnType("char(36)");

                    b.Property<string>("CIId")
                        .HasColumnName("CIId")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("CIName")
                        .HasColumnName("CIName")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("CallGroup")
                        .HasColumnName("CallGroup")
                        .HasColumnType("varchar(200)");

                    b.Property<DateTime>("DateRegister")
                        .HasColumnName("DateRegister")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DateUpdate")
                        .HasColumnName("DateUpdate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnName("DeleteDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("DescriptionFirst")
                        .HasColumnName("DescriptionFirst")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("DescriptionFour")
                        .HasColumnName("DescriptionFour")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("DescriptionSecond")
                        .HasColumnName("DescriptionSecond")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("DescriptionThird")
                        .HasColumnName("DescriptionThird")
                        .HasColumnType("varchar(200)");

                    b.Property<Guid>("IdFirst")
                        .HasColumnName("IdFirst")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("IdFour")
                        .HasColumnName("IdFour")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("IdSecond")
                        .HasColumnName("IdSecond")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("IdThird")
                        .HasColumnName("IdThird")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("UserDeletedId")
                        .HasColumnName("UserDeletedId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("UserInsertedId")
                        .HasColumnName("UserInsertedId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("UserUpdatedId")
                        .HasColumnName("UserUpdatedId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("CallCategoriesList");
                });

            modelBuilder.Entity("VolksCalls.Domain.Models.CallsCategoryDomain", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("Active")
                        .HasColumnName("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid?>("CIId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("CallsCategoryParentId")
                        .HasColumnName("CallsCategoryParentId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("DateRegister")
                        .HasColumnName("DateRegister")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DateUpdate")
                        .HasColumnName("DateUpdate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnName("DeleteDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnName("Description")
                        .HasColumnType("varchar(400)");

                    b.Property<int>("Level")
                        .HasColumnName("Level")
                        .HasColumnType("int");

                    b.Property<string>("Patch")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("QtdChildren")
                        .HasColumnName("QtdChildren")
                        .HasColumnType("int");

                    b.Property<Guid?>("UserDeletedId")
                        .HasColumnName("UserDeletedId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("UserInsertedId")
                        .HasColumnName("UserInsertedId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("UserUpdatedId")
                        .HasColumnName("UserUpdatedId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("CIId");

                    b.HasIndex("CallsCategoryParentId");

                    b.ToTable("TblCallsCategory");
                });

            modelBuilder.Entity("VolksCalls.Domain.Models.CallsPreferences.CallCategoryDomain", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("Active")
                        .HasColumnName("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Ala")
                        .HasColumnName("Ala")
                        .HasColumnType("int");

                    b.Property<string>("CellPhone")
                        .HasColumnName("CellPhone")
                        .HasColumnType("varchar(20)");

                    b.Property<int>("Collaborator")
                        .HasColumnName("Collaborator")
                        .HasColumnType("int");

                    b.Property<string>("Column")
                        .HasColumnName("Column")
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("DateRegister")
                        .HasColumnName("DateRegister")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DateUpdate")
                        .HasColumnName("DateUpdate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnName("DeleteDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("EmailContact")
                        .HasColumnName("EmailContact")
                        .HasColumnType("varchar(50)");

                    b.Property<int>("Floor")
                        .HasColumnName("Floor")
                        .HasColumnType("int");

                    b.Property<int>("Locality")
                        .HasColumnName("Locality")
                        .HasColumnType("int");

                    b.Property<string>("NameContact")
                        .HasColumnName("NameContact")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("PhoneContact")
                        .HasColumnName("PhoneContact")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Reference")
                        .HasColumnName("Reference")
                        .HasColumnType("varchar(50)");

                    b.Property<int>("Side")
                        .HasColumnName("Side")
                        .HasColumnType("int");

                    b.Property<string>("Telephone")
                        .HasColumnName("Telephone")
                        .HasColumnType("varchar(20)");

                    b.Property<Guid?>("UserDeletedId")
                        .HasColumnName("UserDeletedId")
                        .HasColumnType("char(36)");

                    b.Property<string>("UserId")
                        .HasColumnName("UserId")
                        .HasColumnType("varchar(20)");

                    b.Property<Guid>("UserInsertedId")
                        .HasColumnName("UserInsertedId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("UserUpdatedId")
                        .HasColumnName("UserUpdatedId")
                        .HasColumnType("char(36)");

                    b.Property<int>("WorkSchedule")
                        .HasColumnName("WorkSchedule")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CallsPreferences");
                });

            modelBuilder.Entity("VolksCalls.Domain.Models.LogEvent.LogEventDomain", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("Active")
                        .HasColumnName("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("CreatedTime")
                        .HasColumnName("CreatedTime")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateRegister")
                        .HasColumnName("DateRegister")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DateUpdate")
                        .HasColumnName("DateUpdate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnName("DeleteDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("EventId")
                        .HasColumnName("EventId")
                        .HasColumnType("int");

                    b.Property<string>("LogLevel")
                        .HasColumnName("LogLevel")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Message")
                        .HasColumnName("Message")
                        .HasColumnType("text");

                    b.Property<Guid?>("UserDeletedId")
                        .HasColumnName("UserDeletedId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("UserInsertedId")
                        .HasColumnName("UserInsertedId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("UserUpdatedId")
                        .HasColumnName("UserUpdatedId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("LogEvent");
                });

            modelBuilder.Entity("VolksCalls.Domain.Models.ManagedBy.ManagedByDomain", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("Active")
                        .HasColumnName("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Collective")
                        .HasColumnName("Collective")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Column")
                        .HasColumnName("Column")
                        .HasColumnType("varchar(200)");

                    b.Property<DateTime>("DateRegister")
                        .HasColumnName("DateRegister")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DateUpdate")
                        .HasColumnName("DateUpdate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnName("DeleteDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Extension")
                        .HasColumnName("Extension")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Floor")
                        .HasColumnName("Floor")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("MachineName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("MachineType")
                        .HasColumnName("MachineType")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Monitor1")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Monitor1Brand")
                        .HasColumnName("Monitor1Brand")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Monitor1Model")
                        .HasColumnName("Monitor1Model")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Monitor1SerialNumber")
                        .HasColumnName("Monitor1SerialNumber")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Monitor2Brand")
                        .HasColumnName("Monitor2Brand")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Monitor2Model")
                        .HasColumnName("Monitor2Model")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Monitor2SerialNumber")
                        .HasColumnName("Monitor2SerialNumber")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Monitor3Brand")
                        .HasColumnName("Monitor3Brand")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Monitor3Model")
                        .HasColumnName("Monitor3Model")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Monitor3SerialNumber")
                        .HasColumnName("Monitor3SerialNumber")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Plant")
                        .HasColumnName("Plant")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("SerialNumber")
                        .HasColumnName("SerialNumber")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Side")
                        .HasColumnName("Side")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("UO")
                        .HasColumnName("UO")
                        .HasColumnType("varchar(200)");

                    b.Property<Guid?>("UserDeletedId")
                        .HasColumnName("UserDeletedId")
                        .HasColumnType("char(36)");

                    b.Property<string>("UserId")
                        .HasColumnName("UserId")
                        .HasColumnType("varchar(20)");

                    b.Property<Guid>("UserInsertedId")
                        .HasColumnName("UserInsertedId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("UserUpdatedId")
                        .HasColumnName("UserUpdatedId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Wing")
                        .HasColumnName("Wing")
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("ManagedBy");
                });

            modelBuilder.Entity("VolksCalls.Domain.Models.Modules.ModulesActionsDomain", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("Active")
                        .HasColumnName("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("DateRegister")
                        .HasColumnName("DateRegister")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DateUpdate")
                        .HasColumnName("DateUpdate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnName("DeleteDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ModulesActionsName")
                        .HasColumnName("ActionName")
                        .HasColumnType("varchar(200)");

                    b.Property<Guid>("ModulesId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("UserDeletedId")
                        .HasColumnName("UserDeletedId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("UserInsertedId")
                        .HasColumnName("UserInsertedId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("UserUpdatedId")
                        .HasColumnName("UserUpdatedId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("ModulesId");

                    b.ToTable("ModulesActions");
                });

            modelBuilder.Entity("VolksCalls.Domain.Models.Modules.ModulesDomain", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("Active")
                        .HasColumnName("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("DateRegister")
                        .HasColumnName("DateRegister")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DateUpdate")
                        .HasColumnName("DateUpdate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnName("DeleteDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnName("Name")
                        .HasColumnType("varchar(200)");

                    b.Property<Guid?>("UserDeletedId")
                        .HasColumnName("UserDeletedId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("UserInsertedId")
                        .HasColumnName("UserInsertedId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("UserUpdatedId")
                        .HasColumnName("UserUpdatedId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("Modules");
                });

            modelBuilder.Entity("VolksCalls.Domain.Models.Users.UsersModulesActionsDomain", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("Active")
                        .HasColumnName("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("DateRegister")
                        .HasColumnName("DateRegister")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DateUpdate")
                        .HasColumnName("DateUpdate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnName("DeleteDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("ModulesActionsId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("UserDeletedId")
                        .HasColumnName("UserDeletedId")
                        .HasColumnType("char(36)");

                    b.Property<string>("UserId")
                        .HasColumnName("UserId")
                        .HasColumnType("varchar(20)");

                    b.Property<Guid>("UserInsertedId")
                        .HasColumnName("UserInsertedId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("UserUpdatedId")
                        .HasColumnName("UserUpdatedId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("ModulesActionsId");

                    b.ToTable("UsersModulesActions");
                });

            modelBuilder.Entity("VolksCalls.Domain.Models.CallsCategoryDomain", b =>
                {
                    b.HasOne("VolksCalls.Domain.Models.CI.CIDomain", "CI")
                        .WithMany("CallsCategories")
                        .HasForeignKey("CIId");

                    b.HasOne("VolksCalls.Domain.Models.CallsCategoryDomain", "CallsCategoryParent")
                        .WithMany("CallsCategoriesChildren")
                        .HasForeignKey("CallsCategoryParentId");
                });

            modelBuilder.Entity("VolksCalls.Domain.Models.Modules.ModulesActionsDomain", b =>
                {
                    b.HasOne("VolksCalls.Domain.Models.Modules.ModulesDomain", "Modules")
                        .WithMany("ModulesActions")
                        .HasForeignKey("ModulesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VolksCalls.Domain.Models.Users.UsersModulesActionsDomain", b =>
                {
                    b.HasOne("VolksCalls.Domain.Models.Modules.ModulesActionsDomain", "ModulesActions")
                        .WithMany("UsersModulesActions")
                        .HasForeignKey("ModulesActionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
