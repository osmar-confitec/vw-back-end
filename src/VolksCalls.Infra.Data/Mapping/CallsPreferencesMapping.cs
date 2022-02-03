using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VolksCalls.Domain.Models.CallsPreferences;

namespace VolksCalls.Infra.Data.Mapping
{
    public class CallsPreferencesMapping : BaseMapping<CallCategoryDomain>
    {

        public override void Configure(EntityTypeBuilder<CallCategoryDomain> builder)
        {
            base.Configure(builder);

            builder.Property(p=>p.UserId)
                .HasColumnType("varchar(20)")
                .HasColumnName("UserId")
                 ;

            builder.Property(c => c.Telephone)
              .HasColumnType("varchar(20)")
              .HasColumnName("Telephone")
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

            builder.Property(c => c.EmailContact)
            .HasColumnType("varchar(50)")
            .HasColumnName("EmailContact")
             ;

            builder.Property(c => c.HostName)
                 .HasColumnType("varchar(200)")
                 .HasColumnName("HostName")
                  ;


            builder.ToTable("CallsPreferences");
        }
    }
}
