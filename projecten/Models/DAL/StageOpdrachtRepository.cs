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
      /*  private BedrijfContext context;
        private DbSet<StageOpdracht> stageOpdrachten;

        public StageOpdrachtRepository(BedrijfContext context)
        {
            this.context = context;
            //stageOpdrachten = context.StageOpdrachten;
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
        public IQueryable<StageOpdracht> FindAll()
        {
            return stageOpdrachten.OrderBy(b => b.Naam);
        }
        public void SaveChanges()
        {
            context.SaveChanges();
        }*/
    }
}