using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VolksCalls.Domain.Models.Users;

namespace VolksCalls.Infra.Data.Mapping
{
   public class UsersModulesActionsMapping:BaseMapping<UsersModulesActionsDomain>
    {

        public override void Configure(EntityTypeBuilder<UsersModulesActionsDomain> builder)
        {
            base.Configure(builder);

            builder.Property(c => c.UserId)
               .HasColumnType("varchar(20)")
               .HasColumnName("UserId")
               ;



            builder.HasOne(x => x.ModulesActions)
                .WithMany(x => x.UsersModulesActions)
                .HasForeignKey(x => x.ModulesActionsId);


            builder.ToTable("UsersModulesActions");
        }

    }
}
