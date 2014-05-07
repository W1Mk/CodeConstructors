using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
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
            //Property(t => t.Bedrijf_idBedrijf).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Email).IsRequired().HasMaxLength(50);
            Property(t => t.adres).IsRequired().HasMaxLength(50);
            Property(t => t.wachtwoord).IsRequired().HasMaxLength(50);
            Property(t => t.gsm).IsOptional().HasMaxLength(50);
            Property(t => t.naam).IsOptional().HasMaxLength(50);
            Property(t => t.EersteAanmelding).IsRequired();
            Property(t => t.foto).IsOptional().HasColumnType("LONGBLOB");

            //Relationships

            this.HasMany(t => t.Stageopdrachten)
                .WithMany(t => t.studenten)
                .Map(m => { m.MapLeftKey("studentid") ;
            m.MapRightKey("stageopdrachtid");
        }

    );
            

            /* this.HasOptional(t => t.tweedeEmail)
                .WithMany()
                .Map(m => m.MapKey("Studentid"))
                .WillCascadeOnDelete(true);*/
        }
    }
}