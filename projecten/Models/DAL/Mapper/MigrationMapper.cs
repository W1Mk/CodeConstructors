using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using projecten.Models.Domain;

namespace projecten.Models.DAL.Mapper
{
    public class MigrationMapper : EntityTypeConfiguration<__migrationhistory>
    {
        public MigrationMapper()
        {
           
            //Table
            ToTable("__migrationhistory");
            //properties
            Property(t => t.MigrationId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.ContextKey).IsRequired().HasMaxLength(50);
            Property(t => t.Model).IsRequired().HasMaxLength(50);
            Property(t => t.ProductVersion).IsRequired().HasMaxLength(50);
          
            //Relationships
            this.HasMany(t => t.)
              .WithRequired()
              .HasForeignKey(t => t.Studentid)
              .WillCascadeOnDelete(true);
            /*HasMany(t => t.Bieren)
                .WithRequired()
                .Map(m => m.MapKey("BrouwerId"))
                .WillCascadeOnDelete(false);
             HasOptional(t => t.Gemeente)
                .WithMany()
                .Map(m => m.MapKey("Postcode"))
                .WillCascadeOnDelete(false);*/
        }
    }
}