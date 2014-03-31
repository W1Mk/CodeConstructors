using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using projecten.Models.DAL.Mapper;
using projecten.Models.Domain;

namespace projecten.Models.DAL
{
    public class BedrijfContext : DbContext
    {
        public BedrijfContext() :base("localhost")
         
        {
            Database.SetInitializer<BedrijfContext>(new DropCreateDatabaseAlways<BedrijfContext>());
            //Database.Initialize(false);
        }

        public DbSet<Bedrijf> Bedrijven { get; set; }
       // public DbSet<StageOpdracht> StageOpdrachten { get; set; }
        public DbSet<Student> studenten { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new BedrijfMapper());
            modelBuilder.Configurations.Add(new StudentMapper());
          //  modelBuilder.Configurations.Add(new MigrationMapper());
           
        }
    }
}