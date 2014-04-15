using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using projecten.Models.Domain;

namespace projecten.Models.DAL
{
    public class StageOpdrachtRepository
    {
        private BedrijfContext context;
        private BedrijfRepository rep;
        private DbSet<StageOpdracht> stageOpdrachten;
        

        public StageOpdrachtRepository(BedrijfContext context)
        {
            this.context = context;
            stageOpdrachten = context.StageOpdrachten;
            
        }

        public void Add(StageOpdracht stage)
        {
            stageOpdrachten.Add(stage);
        }
        public void Delete(StageOpdracht stage)
        {
            stageOpdrachten.Remove(stage);
        }
        public StageOpdracht FindBy(int bedrijfId)
        {
            return stageOpdrachten.Find(bedrijfId);
            
        }
        public StageOpdracht FindBy(String naam)
        {
            //System.Diagnostics.Debug.WriteLine(FindBy(naam).Naam);
            return stageOpdrachten.FirstOrDefault(b => b.Email == naam);
        }
                    
        public IQueryable<StageOpdracht> FindAll(int id)
        {
            return stageOpdrachten.OrderBy(b => b.Naam).Where(b => b.Bedrijf.BedrijfId == id);
        }
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