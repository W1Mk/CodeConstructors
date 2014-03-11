using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using projecten.Models.Domain;

namespace projecten.Models.DAL.Mapper
{
    public class BedrijfMapper : EntityTypeConfiguration<Bedrijf>
    {
        public BedrijfMapper()
        {
            //properties
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Naam).IsRequired().HasMaxLength(100);
            Property(t => t.Adres).IsRequired().HasMaxLength(100);
            Property(t => t.Email).IsRequired();
            Property(t => t.Telefoon).IsOptional().IsFixedLength().HasMaxLength(10);

            //Table
            ToTable("Bedrijf");

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