using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using projecten.Models.Domain;

namespace projecten.Models.DAL.Mapper
{
    public class StageOpdrachtMapper 
    {
        public StageOpdrachtMapper()
        {
            //properties
           
          /*  Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Naam).IsRequired().HasMaxLength(100);
            Property(t => t.Semester).IsRequired();

            //Table
            ToTable("StageOpdracht");*/

            //Relationships
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