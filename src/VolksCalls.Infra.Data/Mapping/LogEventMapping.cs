using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VolksCalls.Domain.Models.LogEvent;

namespace VolksCalls.Infra.Data.Mapping
{
   public class LogEventMapping : BaseMapping<LogEventDomain>
    {
        public override void Configure(EntityTypeBuilder<LogEventDomain> builder)
        {

           base.Configure(builder);

            builder.Property(c => c.EventId)
             .HasColumnName("EventId")
             .IsRequired(false)
           ;

            builder.Property(c => c.LogLevel)
                .HasColumnType("varchar(200)")
                .HasColumnName("LogLevel")
                 ;

            builder.Property(c => c.Message)
              .HasColumnType("text")
              .HasColumnName("Message")
               ;

            builder.Property(c => c.CreatedTime)
                .HasColumnName("CreatedTime")
          ;

            builder.ToTable("LogEvent");
        }
    }
}
