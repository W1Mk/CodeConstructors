using System.Data.Entity.ModelConfiguration;
using projecten.Models.Domain;

namespace projecten.Models.DAL.Mapper
{
    public class BedrijfMapper : EntityTypeConfiguration<Bedrijf>
    {
        public BedrijfMapper()
        {
           
            //Table
            ToTable("Bedrijf");
            HasKey(t => t.BedrijfId);
            //properties
            Property(t => t.Bedrijfsnaam).IsRequired().HasMaxLength(50);
            Property(t => t.Email).IsRequired().HasMaxLength(50);
            Property(t => t.Wachtwoord).IsRequired().HasMaxLength(100);
            Property(t => t.telefoon).IsOptional().HasMaxLength(50);
            Property(t => t.adres).IsOptional().HasMaxLength(50);
            Property(t => t.Bedrijfsactiviteit).IsOptional().HasMaxLength(50);
            Property(t => t.Bereikbaarheid).IsOptional().HasMaxLength(50);
            Property(t => t.url).IsOptional().HasMaxLength(50);
            Property(t => t.Foto).IsOptional().HasColumnType("LONGBLOB");
            //Relationships
            HasMany(t => t.stages)
                .WithOptional()
                .Map(t => t.MapKey("BedrijfFK"))
                .WillCascadeOnDelete(true);
            HasMany(t => t.mentors)
                .WithOptional()
                .Map(t => t.MapKey("MentorFK"))
                .WillCascadeOnDelete(true);
        }
    }
}