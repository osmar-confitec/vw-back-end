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
    [Migration("20210622205850_CallsPreferences")]
    partial class CallsPreferences
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
                        .HasColumnType("varchar(200)");

                    b.Property<int>("Level")
                        .HasColumnName("Level")
                        .HasColumnType("int");

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

            modelBuilder.Entity("VolksCalls.Domain.Models.CallsPreferences.CallsPreferencesDomain", b =>
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
                        .HasColumnName("Ala")
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
                        .HasColumnName("Ala")
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

            modelBuilder.Entity("VolksCalls.Domain.Models.CallsCategoryDomain", b =>
                {
                    b.HasOne("VolksCalls.Domain.Models.CI.CIDomain", "CI")
                        .WithMany("CallsCategories")
                        .HasForeignKey("CIId");

                    b.HasOne("VolksCalls.Domain.Models.CallsCategoryDomain", "CallsCategoryParent")
                        .WithMany("CallsCategoriesChildren")
                        .HasForeignKey("CallsCategoryParentId");
                });
#pragma warning restore 612, 618
        }
    }
}
