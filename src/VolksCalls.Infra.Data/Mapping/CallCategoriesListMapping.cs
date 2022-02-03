using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VolksCalls.Domain.Models.CallCategoriesList;

namespace VolksCalls.Infra.Data.Mapping
{
    public class CallCategoriesListMapping : BaseMapping<CallCategoriesListDomain>
    {
        public override void Configure(EntityTypeBuilder<CallCategoriesListDomain> builder)
        {
            base.Configure(builder);

            /**/

            builder.Property(c => c.DescriptionFirst)
             .HasColumnName("DescriptionFirst")
             .HasColumnType("varchar(200)")
           ;

            builder.Property(c => c.IdFirst)
                .HasColumnName("IdFirst")
                 ;

            builder.Property(c => c.DescriptionSecond)
                .HasColumnType("varchar(200)")
                .HasColumnName("DescriptionSecond")
                 ;

            builder.Property(c => c.IdSecond)
                .HasColumnName("IdSecond")
                 ;

            builder.Property(c => c.DescriptionThird)
                .HasColumnType("varchar(200)")
                .HasColumnName("DescriptionThird")
                 ;

            builder.Property(c => c.IdThird)
              .HasColumnName("IdThird")
           ;
            builder.Property(c => c.DescriptionFour)
               .HasColumnType("varchar(200)")
               .HasColumnName("DescriptionFour")
                ;

            builder.Property(c => c.IdFour)
            .HasColumnName("IdFour")
                ;
            builder.Property(c => c.CICode)
          .HasColumnName("CICode")
            ;

            builder.Property(c => c.CIId)
               .HasColumnType("varchar(20)")
               .HasColumnName("CIId")
                ;

            builder.Property(c => c.CIName)
               .HasColumnType("varchar(200)")
               .HasColumnName("CIName")
                ;

            builder.Property(c => c.CallGroup)
               .HasColumnType("varchar(200)")
               .HasColumnName("CallGroup")
                ;

            builder.ToTable("CallCategoriesList");

        }
    }
}
