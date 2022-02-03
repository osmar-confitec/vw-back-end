using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VolksCalls.Domain.Models.ManagedBy;

namespace VolksCalls.Infra.Data.Mapping
{
    public class ManagedByMapping : BaseMapping<ManagedByDomain>
    {

        public override void Configure(EntityTypeBuilder<ManagedByDomain> builder)
        {
            base.Configure(builder);

            builder.Property(c => c.Collective)
              .HasColumnType("varchar(200)")
              .HasColumnName("Collective")
               ;

            builder.Property(c => c.MachineType)
               .HasColumnType("varchar(200)")
               .HasColumnName("MachineType")
                ;

            builder.Property(c => c.SerialNumber)
               .HasColumnType("varchar(200)")
               .HasColumnName("SerialNumber")
                ;

            builder.Property(c => c.UserId)
              .HasColumnType("varchar(20)")
              .HasColumnName("UserId")
               ;

            builder.Property(c => c.SerialNumber)
             .HasColumnType("varchar(200)")
             .HasColumnName("SerialNumber")
              ;

            builder.Property(c => c.Monitor1Model)
             .HasColumnType("varchar(200)")
             .HasColumnName("Monitor1Model")
              ;

            builder.Property(c => c.Monitor1Brand)
           .HasColumnType("varchar(200)")
           .HasColumnName("Monitor1Brand")
            ;

            builder.Property(c => c.Monitor1SerialNumber)
           .HasColumnType("varchar(200)")
           .HasColumnName("Monitor1SerialNumber")
            ;

            builder.Property(c => c.Monitor2Brand)
           .HasColumnType("varchar(200)")
           .HasColumnName("Monitor2Brand")
            ;

            builder.Property(c => c.Monitor2Model)
            .HasColumnType("varchar(200)")
            .HasColumnName("Monitor2Model")
             ;

            builder.Property(c => c.Monitor2SerialNumber)
              .HasColumnType("varchar(200)")
              .HasColumnName("Monitor2SerialNumber")
               ;

            builder.Property(c => c.Monitor3SerialNumber)
             .HasColumnType("varchar(200)")
             .HasColumnName("Monitor3SerialNumber")
              ;

            builder.Property(c => c.Monitor3Brand)
               .HasColumnType("varchar(200)")
               .HasColumnName("Monitor3Brand")
                ;

            builder.Property(c => c.Monitor3Model)
            .HasColumnType("varchar(200)")
            .HasColumnName("Monitor3Model")
            ;

            builder.Property(c => c.Plant)
              .HasColumnType("varchar(200)")
              .HasColumnName("Plant")
              ;

            builder.Property(c => c.Wing)
            .HasColumnType("varchar(200)")
            .HasColumnName("Wing")
            ;

            builder.Property(c => c.Floor)
            .HasColumnType("varchar(200)")
            .HasColumnName("Floor")
            ;


            builder.Property(c => c.Column)
            .HasColumnType("varchar(200)")
            .HasColumnName("Column")
            ;

            builder.Property(c => c.Extension)
            .HasColumnType("varchar(200)")
            .HasColumnName("Extension")
            ;

            builder.Property(c => c.Side)
            .HasColumnType("varchar(200)")
            .HasColumnName("Side")
            ;


            builder.Property(c => c.UO)
            .HasColumnType("varchar(200)")
            .HasColumnName("UO")
            ;

    

            builder.ToTable("ManagedBy");
        }

    }
}
