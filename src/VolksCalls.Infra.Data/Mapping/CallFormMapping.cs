using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VolksCalls.Domain.Models.CallForm;

namespace VolksCalls.Infra.Data.Mapping
{
    public class CallFormMapping : BaseMapping<CallFormDomain>
    {

        public override void Configure(EntityTypeBuilder<CallFormDomain> builder)
        {
            base.Configure(builder);

            builder.Property(c => c.Name)
             .HasColumnType("varchar(200)")
             .HasColumnName("Name")
              ;

            builder.Property(c => c.Observation)
                 .HasColumnType("text")
                 .HasColumnName("Observation")
                  ;


            builder.Property(c => c.IsDefault)
            ;

            builder.Property(c => c.CallFormType)
                .HasColumnName("CallFormType")
                ;

            builder.ToTable("CallForm");
        }

    }
}
