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
            //HasKey(t => t.StageOpdrachtId);

            //properties                      
            Property(t => t.Naam).IsRequired().HasMaxLength(100);
            Property(t => t.Omschrijving).IsRequired().HasMaxLength(500);
            Property(t => t.Semester).IsRequired();
            Property(t => t.Specialisatie).IsRequired();
            Property(t => t.AantalStudenten).IsRequired();
            Property(t => t.StageMentor).IsRequired();
            Property(t => t.Status).IsRequired();
            //Property(t => t.Email).IsRequired();
            //Property(t => t.Bedrijf.BedrijfId).IsRequired();

            //Relationships
           /* HasRequired(t => t.Bedrijf)
                .WithRequiredDependent()
                .WillCascadeOnDelete(false);*/
           /* HasRequired(t => t.bedrijf)
                .WithMany()
                .HasForeignKey(t => t.
                .WillCascadeOnDelete(true);*/
            /* HasOptional(t => t.Gemeente)
                .WithMany()
                .Map(m => m.MapKey("Postcode"))
                .WillCascadeOnDelete(false);*/
        }
    }
}