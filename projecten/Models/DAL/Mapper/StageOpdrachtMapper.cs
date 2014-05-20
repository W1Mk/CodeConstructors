using System.Data.Entity.ModelConfiguration;
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
        }
    }
}