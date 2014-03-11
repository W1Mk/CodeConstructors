using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using projecten.Models.Domain;

namespace projecten.Models.DAL
{
    public class BedrijfRepository
    {
        private BedrijfContext context;
        private DbSet<Bedrijf> bedrijven;

        public BedrijfRepository(BedrijfContext context)
        {
            this.context = context;
            bedrijven = context.Bedrijven;
        }

        public void Add(Bedrijf bedrijf)
        {
            bedrijven.Add(bedrijf);
        }
        public void Delete(Bedrijf bedrijf)
        {
            bedrijven.Remove(bedrijf);
        }
        public Bedrijf FindBy(int bedrijfId)
        {
            return bedrijven.Find(bedrijfId);
        }
        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}