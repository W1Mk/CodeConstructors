using System;
using System.Data.Entity;
using System.Linq;
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
            return StageMentoren.FirstOrDefault(b => b.Naam == naam);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}