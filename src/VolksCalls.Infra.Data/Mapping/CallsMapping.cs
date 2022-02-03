using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VolksCalls.Domain.Models.Calls;

namespace VolksCalls.Infra.Data.Mapping
{
    public class CallsMapping : BaseMapping<CallsDomain>
    {
        public override void Configure(EntityTypeBuilder<CallsDomain> builder)
        {
            base.Configure(builder);


            builder.Property(p => p.UserId)
                    .HasColumnType("varchar(20)")
                    .HasColumnName("UserId")
                        ;

            builder.Property(c => c.Telephone)
                  .HasColumnType("varchar(20)")
                  .HasColumnName("Telephone")
                   ;

            builder.Property(c => c.Plate)
                  .HasColumnType("varchar(50)")
                  .HasColumnName("Plate")
                   ;


            builder.Property(c => c.Vip)
                .HasColumnName("Vip")
                ;

            builder.Property(c => c.StatusCalls)
                .HasColumnName("StatusCalls")
                ;

            builder.Property(c => c.CellPhone)
                .HasColumnType("varchar(20)")
                .HasColumnName("CellPhone")
                 ;

            builder.Property(c => c.WorkSchedule)
                .HasColumnName("WorkSchedule")
                 ;
            builder.Property(c => c.Collaborator)
              .HasColumnName("Collaborator")
               ;

            builder.Property(c => c.Locality)
             .HasColumnName("Locality")
              ;

            builder.Property(c => c.Reference)
              .HasColumnType("varchar(200)")
              .HasColumnName("Reference")
               ;

            builder.Property(c => c.Ala)
                    .HasColumnName("Ala")
                     ;

            builder.Property(c => c.Floor)
                    .HasColumnName("Floor")
                     ;

            builder.Property(c => c.Side)
               .HasColumnName("Side")
                ;

            builder.Property(c => c.Column)
                .HasColumnType("varchar(50)")
                .HasColumnName("Column")
                 ;

            builder.Property(c => c.NameContact)
                .HasColumnType("varchar(200)")
                .HasColumnName("NameContact")
                 ;

            builder.Property(c => c.PhoneContact)
                .HasColumnType("varchar(20)")
                .HasColumnName("PhoneContact")
                 ;

            builder.Property(c => c.Title)
              .HasColumnType("varchar(200)")
              .HasColumnName("Title")
               ;
            builder.Property(c => c.Description)
                .HasColumnType("Text")
                .HasColumnName("Description")
                 ;


            builder.Property(c => c.Email)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("Email")
                     ;

            builder.Property(c => c.EmailContact)
            .HasColumnType("varchar(50)")
            .HasColumnName("EmailContact")
             ;

            builder.Property(c => c.HostName)
                 .HasColumnType("varchar(200)")
                 .HasColumnName("HostName")
                  ;
            builder.Property(c => c.Name)
                  .HasColumnType("varchar(200)")
                  .HasColumnName("Name")
                   ;


            builder.Property(c => c.CIName)
             .HasColumnType("varchar(200)")
             .HasColumnName("CIName")
              ;



            builder.Property(c => c.CIQuee)
                .HasColumnType("varchar(200)")
                .HasColumnName("CIQuee")
                 ;

            builder.Property(c => c.CIId)
              .HasColumnType("varchar(200)")
              .HasColumnName("CIId")
               ;

            builder.HasOne(x => x.CallsCategory)
                .WithMany(x => x.Calls)
                .HasForeignKey(x => x.CallsCategoryId);

            builder.HasOne(x => x.CallForm)
                .WithMany(x => x.Calls)
                .HasForeignKey(x => x.CallFormId)
                .IsRequired(false);


            builder.ToTable("Calls");
        }
    }
}
