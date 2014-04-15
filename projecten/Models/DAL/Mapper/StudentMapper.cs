using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using projecten.Models.Domain;
using Newtonsoft.Json;

namespace projecten.Models.DAL.Mapper
{
    public class StudentMapper : EntityTypeConfiguration<Student>
    {
        public StudentMapper()
        {
            //Table
            ToTable("student");
            //properties
            
            Property(s => s.id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(s => s.naam).IsRequired().HasMaxLength(100);
            Property(s => s.email).IsRequired();
            Property(s => s.wachtwoord).IsRequired();
        }
	}
}