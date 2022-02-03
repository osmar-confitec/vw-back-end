using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VolksCalls.Domain.Models.CI;

namespace VolksCalls.Infra.Data.Mapping
{
    public class CIMapping : BaseMapping<CIDomain>
    {

        public override void Configure(EntityTypeBuilder<CIDomain> builder)
        {
            base.Configure(builder);

            builder.Property(c => c.CIName)
               .HasColumnType("varchar(200)")
               .HasColumnName("CIName")
                ;

            builder.Property(c => c.DefaultCI)
                .HasColumnName("DefaultCI")
                ;

            builder.Property(c => c.CallGroup)
                .HasColumnType("varchar(200)")
                .HasColumnName("CallGroup")
                 ;

            builder.Property(c => c.CIId)
              .HasColumnType("varchar(200)")
              .HasColumnName("CIId")
               ;

            builder.ToTable("CI");
        }

    }
}
