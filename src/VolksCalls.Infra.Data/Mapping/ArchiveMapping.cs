using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VolksCalls.Domain.Models.Archive;

namespace VolksCalls.Infra.Data.Mapping
{
    public class ArchiveMapping : BaseMapping<ArchiveDomain>
    {


        public override void Configure(EntityTypeBuilder<ArchiveDomain> builder)
        {
            base.Configure(builder);


            builder.Property(c => c.FileName)
                  .HasColumnType("varchar(200)")
                  .HasColumnName("FileName")
                   ;

            builder.Property(c => c.Identity)
                    .HasColumnName("Identity")
                    ;

            builder.Property(c => c.TypeFile)
               .HasColumnName("TypeFile")
               ;

            builder.Property(c => c.Size)
               .HasColumnName("Size")
               ;

            builder.Property(c => c.FileLocation)
               .HasColumnName("FileLocation");

            builder.Property(c => c.Path)
               .HasColumnType("varchar(200)")
               .HasColumnName("Path")
                ;


            builder.Property(c => c.Extension)
               .HasColumnName("Extension")
                ;

            builder.Property(c => c.Base64)
              .HasColumnType("Text")
              .HasColumnName("Base64")
           ;


            builder.HasOne(x => x.CallsDomain)
                .WithMany(x => x.Archives)
                .HasForeignKey(x => x.CallsDomainId)
                .IsRequired(false)
                ;


            builder.ToTable("Archive");


        }

    }

}




