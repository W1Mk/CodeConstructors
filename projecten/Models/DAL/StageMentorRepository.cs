using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using projecten.Models.Domain;

namespace projecten.Models.DAL
{
    public class StageMentorRepository
    {
        private BedrijfContext context;
        private BedrijfRepository rep;
        private DbSet<StageMentor> StageMentoren;


        public StageMentorRepository(BedrijfContext context)
        {
            this.context = context;
            StageMentoren = context.stagementors;

        }

        public void Add(StageMentor mentor)
        {
            if (mentor != null)
            StageMentoren.Add(mentor);
        }
        public void Delete(StageMentor mentor)
        {
            if(mentor != null)
            StageMentoren.Remove(mentor);
        }
        public StageMentor FindBy(int bedrijfId)
        {
            return StageMentoren.Find(bedrijfId);

        }
        public StageMentor FindBy(String naam)
        {
            //System.Diagnostics.Debug.WriteLine(FindBy(naam).Naam);
            return StageMentoren.FirstOrDefault(b => b.Naam == naam);
        }

       /* public IQueryable<StageMentor> FindAll(int id)
        {
            IQueryable test = StageMentoren.OrderBy(b => b.Naam).Where(b => b.Bedrijf.BedrijfId == id);

            return StageMentoren.OrderBy(b => b.Naam).Where(b => b.Bedrijf.BedrijfId == id);
        }*/
        /*public List<StageOpdracht> FindList()
        {
            FindBy(rep.GetBedrijven())
            return stageOpdrachten.ToList();
        }*/
        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}