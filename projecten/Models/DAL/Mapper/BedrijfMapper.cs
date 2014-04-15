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
           
            //Table
            ToTable("Bedrijf");
            //HasKey(t => t.BedrijfId);
            //properties
            //Property(t => t.Bedrijf_idBedrijf).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Bedrijfsnaam).IsRequired().HasMaxLength(50);
            Property(t => t.Email).IsRequired().HasMaxLength(50);
            Property(t => t.Wachtwoord).IsRequired().HasMaxLength(50);
            Property(t => t.telefoon).IsOptional().HasMaxLength(50);
            Property(t => t.adres).IsOptional().HasMaxLength(50);
            Property(t => t.bedrijfsactiviteit).IsOptional().HasMaxLength(50);
            Property(t => t.bereikbaarheid).IsOptional().HasMaxLength(50);
            Property(t => t.url).IsOptional().HasMaxLength(50);
            //Relationships
            
            /*HasMany(t => t.stages)
                .WithOptional()
                .Map(m => m.MapKey("BedrijfId"))
                .WillCascadeOnDelete(false);*/
             
        }
    }
}