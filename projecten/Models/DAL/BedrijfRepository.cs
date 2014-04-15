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
        public Bedrijf FindBy(String email)
        {
            return bedrijven.FirstOrDefault(b => b.Email == email);
        }
        public int FindId(string email)
        {
            Bedrijf tijdelijk = FindBy(email);
            
            return tijdelijk.BedrijfId;
        }
        public Boolean FindEqual(string email)
        {
            Boolean value = true; ;
            Bedrijf tijdelijk;
            tijdelijk = FindBy(email);
            if (tijdelijk != null)
                value = true;
            else
                value = false;
            return value;
        }
        public IEnumerable<Bedrijf> GetBedrijven()
        {
            return context.Bedrijven.ToList();
        }
        public void SaveChanges()
        {
            context.SaveChanges();
        }
        public void Update(Bedrijf bedrijf)
        {
            context.Entry(bedrijf).State = EntityState.Modified;
        }

        public List<Bedrijf> lijst()
        {
            List<Bedrijf> bedrijfslijst = new List<Bedrijf>();
            bedrijfslijst.Add(new Bedrijf());
            return bedrijfslijst;
        }
    }
}