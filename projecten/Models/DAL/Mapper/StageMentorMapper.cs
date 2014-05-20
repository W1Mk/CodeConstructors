using System.Data.Entity.ModelConfiguration;
using projecten.Models.Domain;

namespace projecten.Models.DAL.Mapper
{
    public class StageMentorMapper : EntityTypeConfiguration<StageMentor>
    {
        public StageMentorMapper()
        {
            ToTable("StageMentor");

            Property(t => t.Naam).IsRequired().HasMaxLength(100);
            Property(t => t.Voornaam).IsRequired().HasMaxLength(50);
            Property(t => t.Email).IsRequired();
            Property(t => t.Functie).IsRequired();
            Property(t => t.Gsm).IsRequired();
            Property(t => t.Aanspreektitel).IsRequired();


        }
    }
}