using System.Data.Entity.ModelConfiguration;
using projecten.Models.Domain;

namespace projecten.Models.DAL.Mapper
{
    public class AcademieJaarMapper : EntityTypeConfiguration<AcademieJaar>
    {
    
        public AcademieJaarMapper()
        {
            //Table
            ToTable("AcademieJaar");
            HasKey(t => t.Id);
            //properties
            //Property(t => t.Bedrijf_idBedrijf).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Academiejaar).IsRequired().HasMaxLength(50);
            Property(t => t.Actief).IsRequired();       
        }
    }
}