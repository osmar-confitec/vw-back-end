using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VolksCalls.Domain.Models.Modules;

namespace VolksCalls.Infra.Data.Mapping
{
   public class ModulesActionsMapping : BaseMapping<ModulesActionsDomain>
    {
        public override void Configure(EntityTypeBuilder<ModulesActionsDomain> builder)
        {
            base.Configure(builder);

            builder.Property(c => c.ModulesActionsName)
               .HasColumnType("varchar(200)")
               .HasColumnName("ActionName")
                ;

            builder.HasOne(x => x.Modules)
                .WithMany(x => x.ModulesActions)
                .HasForeignKey(x => x.ModulesId);
           
            builder.ToTable("ModulesActions");
        }
    }
}
