using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VolksCalls.Domain.Models.CallForm;

namespace VolksCalls.Infra.Data.Mapping
{
    public class CallFormQuestionsMapping : BaseMapping<CallFormQuestionsDomain>
    {
        public override void Configure(EntityTypeBuilder<CallFormQuestionsDomain> builder)
        {
            base.Configure(builder);

            builder.Property(c => c.QuestionType)
                   .HasColumnName("QuestionType");


            builder.Property(c => c.Order)
                   .HasColumnName("Order");

            builder.Property(c => c.DropdownItens)
                .HasColumnType("text")
                .HasColumnName("DropdownItens")
                    ;

            builder.Property(c => c.Required)
                 .HasColumnName("Required");


            builder.Property(c => c.CallFormQuestionType)
                   .HasColumnName("CallFormQuestionType");

            builder.Property(c => c.Key)
                .HasColumnType("varchar(50)")
                .HasColumnName("Key")
                 ;

            builder.Property(c => c.Label)
                   .HasColumnType("text")
                   .HasColumnName("Label")
                    ;

            builder.HasOne(x => x.CallForm)
                .WithMany(x => x.CallFormsQuestions)
                .HasForeignKey(x => x.CallFormId);

            builder.ToTable("CallFormQuestions");

        }
    }
}
