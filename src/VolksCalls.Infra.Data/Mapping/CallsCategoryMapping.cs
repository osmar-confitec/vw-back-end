using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VolksCalls.Domain.Models;

namespace VolksCalls.Infra.Data.Mapping
{
   public class CallsCategoryMapping : BaseMapping<CallsCategoryDomain>
    {

        public override void Configure(EntityTypeBuilder<CallsCategoryDomain> builder)
        {
            base.Configure(builder);

            builder.Property(c => c.Description)
             .HasColumnType("varchar(400)")
             .HasColumnName("Description")
            ;

            builder.Property(c => c.QtdChildren)
             .HasColumnName("QtdChildren")
            ;

            builder.Property(c => c.Level)
                   .HasColumnName("Level")
                 ;

            builder.Property(c => c.CallFormId)
               .HasColumnName("CallsFormsId")
             ;

            builder.Property(c => c.CallsCategoryParentId)
             .HasColumnName("CallsCategoryParentId")
            ;
            builder
              .HasMany(answer => answer.CallsCategoriesChildren)
              .WithOne(answer => answer.CallsCategoryParent)
              .HasForeignKey(x => x.CallsCategoryParentId)
              .IsRequired(false);
            ;

            builder.HasOne(x => x.CI)
            .WithMany(x => x.CallsCategories)
            .HasForeignKey(x => x.CIId)
            .IsRequired(false);

            builder.HasOne(x => x.CallForm)
               .WithMany(x => x.CallsCategories)
               .HasForeignKey(x => x.CallFormId)
               .IsRequired(false);

            builder.ToTable("TblCallsCategory");
        }

    }
}
