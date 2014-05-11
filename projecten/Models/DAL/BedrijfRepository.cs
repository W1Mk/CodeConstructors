using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Ninject.Infrastructure.Language;
using projecten.Models.Domain;

namespace projecten.Models.DAL
{
    public class BedrijfRepository
    {
        private BedrijfContext context;
        private DbSet<Bedrijf> bedrijven;
        private DbSet<StageOpdracht> stageOpdrachten;
        private readonly List<Bedrijf> bedrijf = new List<Bedrijf>();
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
        public IEnumerable<Bedrijf> FindAllByAdres(string adres)
        {
            bedrijven.ToList<Bedrijf>();
            bedrijf.AddRange(bedrijven);
            List<Bedrijf> bedrijfFilter = bedrijf.FindAll(s => s.adres==adres);
           
            return bedrijfFilter;
        }
        public List<Bedrijf> lijst()
        {
            List<Bedrijf> bedrijfslijst = new List<Bedrijf>();
            bedrijfslijst.Add(new Bedrijf());
            return bedrijfslijst;
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

        public IQueryable<Bedrijf> FindAll()
        {
            return bedrijven.OrderBy(b => b.Bedrijfsnaam);
        }
        public IQueryable<StageOpdracht> FindAllOpdrachten(Bedrijf bedrijf)
        {
            if (bedrijf.stages != null)
                return bedrijf.stages.AsQueryable();

            return null;

        }
        public IQueryable<StageMentor> FindAllMentors(Bedrijf bedrijf)
        {
            if (bedrijf.mentors != null)
                return bedrijf.mentors.AsQueryable();

            return null;

        }
        public IQueryable<Bedrijf> FindAllFilter(string zoekopdracht)
        {
            IQueryable<Bedrijf> list = null;
            if (bedrijven.Where(b => b.Bedrijfsnaam.ToLower() == zoekopdracht.ToLower()).Any())
                list = bedrijven.Where(b => b.Bedrijfsnaam.ToLower() == zoekopdracht.ToLower());
            else if (bedrijven.Where(b => b.Email.ToLower() == zoekopdracht.ToLower()).Any())
                list = bedrijven.Where(b => b.Email.ToLower() == zoekopdracht.ToLower());
            else if (bedrijven.Where(b => b.adres.ToLower() == zoekopdracht.ToLower()).Any())
                list = bedrijven.Where(b => b.adres.ToLower() == zoekopdracht.ToLower());
            else if (bedrijven.Where(b => b.bedrijfsactiviteit.ToLower() == zoekopdracht.ToLower()).Any())
                list = bedrijven.Where(b => b.bedrijfsactiviteit.ToLower() == zoekopdracht.ToLower());           
            else
            {
                list = new List<Bedrijf>().AsQueryable();
            }
            if (zoekopdracht == "")
                list = FindAll();
            return list;
        }
    }
}