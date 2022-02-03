using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VolksCalls.Infra.Data.Mapping;

namespace VolksCalls.Infra.Data.Context
{
    public class AplicationContext : DbContext
    {
        public AplicationContext(DbContextOptions<AplicationContext> options)
         : base(options)
        {



        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArchiveMapping());
            modelBuilder.ApplyConfiguration(new CallFormMapping());
            modelBuilder.ApplyConfiguration(new CallsMapping());
            modelBuilder.ApplyConfiguration(new CallFormQuestionsMapping());
            modelBuilder.ApplyConfiguration(new ModulesMapping());
            modelBuilder.ApplyConfiguration(new ModulesActionsMapping());
            modelBuilder.ApplyConfiguration(new CallsCategoryMapping());
            modelBuilder.ApplyConfiguration(new CIMapping());
            modelBuilder.ApplyConfiguration(new LogEventMapping());
            modelBuilder.ApplyConfiguration(new CallsPreferencesMapping());
            modelBuilder.ApplyConfiguration(new ManagedByMapping());
            modelBuilder.ApplyConfiguration(new CallCategoriesListMapping());
            modelBuilder.ApplyConfiguration(new UsersModulesActionsMapping());
          
        }
    }
}
