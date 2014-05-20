using System.Data.Entity.ModelConfiguration;
using projecten.Models.Domain;

namespace projecten.Models.DAL.Mapper
{
    public class StudentMapper : EntityTypeConfiguration<Student>
    {
        public StudentMapper()
        {

            //Table
            ToTable("student");
            HasKey(t => t.Studentid);
            //properties
            Property(t => t.Email).IsRequired().HasMaxLength(50);
            Property(t => t.Adres).IsRequired().HasMaxLength(50);
            Property(t => t.Wachtwoord).IsRequired().HasMaxLength(100);
            Property(t => t.Gsm).IsOptional().HasMaxLength(50);
            Property(t => t.Naam).IsOptional().HasMaxLength(50);
            Property(t => t.Foto).IsOptional().HasColumnType("LONGBLOB");
            Property(t => t.BeginDatum).IsOptional();
            Property(t => t.EindeDatum).IsOptional();
            Property(t => t.StageContract).IsOptional();

            //Relationships

            this.HasMany(t => t.Stageopdrachten)
                .WithMany(t => t.Studenten)
                .Map(m => { m.MapLeftKey("studentid") ;
            m.MapRightKey("stageopdrachtid");
        }

    );
            this.HasMany(t => t.Solicitaties)
                .WithMany(t => t.StudentSolicitaties)
                .Map(m =>
                {
                    m.MapLeftKey("studentidsol");
                    m.MapRightKey("stageopdrachtidsol");
                }

    );

        }
    }
}