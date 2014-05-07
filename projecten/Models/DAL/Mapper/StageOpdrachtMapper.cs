using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using projecten.Models.Domain;

namespace projecten.Models.DAL.Mapper
{
    public class StageOpdrachtMapper : EntityTypeConfiguration<StageOpdracht>
    {
        public StageOpdrachtMapper()
        {

            //Table
            ToTable("StageOpdracht");
            //properties

            HasKey(t => new { t.StageOpdrachtid });
            Property(t => t.Naam).IsRequired().HasMaxLength(100);
            Property(t => t.Semester).IsRequired();
           // Property(t => t.Bedrijfid).IsRequired();
            

            //Relationships
           /* this.HasMany(t => t.StudentStages)
           .WithRequired()
           .HasForeignKey(t => t.StageOpdrachtid)
           .WillCascadeOnDelete(true);*/

            /*HasRequired(t => t.Bedrijf)
                .WithMany(t => t.stages)
                .HasForeignKey(t => t.StageOpdrachtid)
                .WillCascadeOnDelete(true);*/

        }
    }
}