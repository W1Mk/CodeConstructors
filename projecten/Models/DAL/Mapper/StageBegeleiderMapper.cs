using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using projecten.Models.Domain;

namespace projecten.Models.DAL.Mapper
{
    public class StageBegeleiderMapper : EntityTypeConfiguration<StageBegeleider>
    {
        public StageBegeleiderMapper()
        {
           
            //Table
            ToTable("StageBegeleider");
            HasKey(t => t.Id);
            //properties
            //Property(t => t.Bedrijf_idBedrijf).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Naam).IsOptional().HasMaxLength(50);
            Property(t => t.VoorNaam).IsRequired().HasMaxLength(50);
            Property(t => t.Email).IsRequired().HasMaxLength(50);
            Property(t => t.Adres).IsRequired().HasMaxLength(50);
            Property(t => t.Wachtwoord).IsRequired().HasMaxLength(100);
            Property(t => t.Telefoon).IsOptional().HasMaxLength(12);
            Property(t => t.Gsm).IsOptional().HasMaxLength(50);
            Property(t => t.EersteAanmelding).IsRequired();
            Property(t => t.Foto).IsOptional().HasColumnType("LONGBLOB");
          
            //Relationships

           HasMany(t => t.VoorkeurDefinitief)
              .WithOptional()
              .Map(t => t.MapKey("BegeleiderFK"))
              .WillCascadeOnDelete(true);

            this.HasMany(t => t.Stages)
                .WithMany(t => t.begeleiders)
                .Map(m =>
                {
                    m.MapLeftKey("begeleidersid");
                    m.MapRightKey("stageopdrachtid");
                });

            this.HasMany(t => t.Voorkeurstages)
               .WithMany(t => t.voorkeurbegeleiders)
               .Map(m =>
               {
                   m.MapLeftKey("begeleidersid");
                   m.MapRightKey("stageopdrachtid");
               });

            /* this.HasOptional(t => t.tweedeEmail)
                .WithMany()
                .Map(m => m.MapKey("Studentid"))
                .WillCascadeOnDelete(true);*/
        }
    }
}