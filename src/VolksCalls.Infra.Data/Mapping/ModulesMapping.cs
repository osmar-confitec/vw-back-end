using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VolksCalls.Domain.Models.Modules;

namespace VolksCalls.Infra.Data.Mapping
{
   public class ModulesMapping : BaseMapping<ModulesDomain>
    {

        public override void Configure(EntityTypeBuilder<ModulesDomain> builder)
        {
            base.Configure(builder);

            builder.Property(c => c.Name)
               .HasColumnType("varchar(200)")
               .HasColumnName("Name")
                ;


            builder.ToTable("Modules");
        }

    }
}
