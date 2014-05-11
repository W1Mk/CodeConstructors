using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.WebPages;
using projecten.Models.Domain;

namespace projecten.Models.DAL
{
    public class StageOpdrachtRepository
    {
        private BedrijfContext context;
        private DbSet<StageOpdracht> stageOpdrachten;
        private readonly List<StageOpdracht> stages = new List<StageOpdracht>();
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
            return stageOpdrachten.FirstOrDefault(b => b.StageOpdrachtid == bedrijfId);
        }
        public IEnumerable<StageOpdracht> FindAll()
        {
            return stageOpdrachten.OrderBy(b => b.Naam);

        }

        public IEnumerable<StageOpdracht> FindAllByName(string naam)
        {
            stageOpdrachten.ToList<StageOpdracht>();
            stages.AddRange(stageOpdrachten);
            List<StageOpdracht> stageFilter = stages.FindAll(s => s.Naam == naam); 
            return stageFilter;
        }
        public IEnumerable<StageOpdracht> FindAllByBedrijfId(int id)
        {
            stageOpdrachten.ToList<StageOpdracht>();
            List<StageOpdracht> stageFilter = stages.FindAll(s => s.StageOpdrachtid==id);//tijdelijk
            return stageFilter;
        }
        public IEnumerable<StageOpdracht> FindAllBy(string zoekopdracht)
        {
            stageOpdrachten.ToList<StageOpdracht>();
            stages.AddRange(stageOpdrachten);
             IEnumerable<StageOpdracht> stageFilter = stages;
            if(stages.Where(b => b.Semester == zoekopdracht.AsInt()).Any())
                stageFilter = stages.Where(b => b.Semester == zoekopdracht.AsInt());
            else if (stages.Where(b => b.Naam.ToLower() == zoekopdracht.ToLower()).Any())
                stageFilter = stages.Where(b => b.Naam.ToLower() == zoekopdracht.ToLower());
            else if (stages.Where(b => b.Specialisatie.ToLower() == zoekopdracht.ToLower()).Any())
                stageFilter = stages.Where(b => b.Specialisatie.ToLower() == zoekopdracht.ToLower());
            else if (zoekopdracht == "")
                stageFilter = stages;
            else
                stageFilter = new List<StageOpdracht>();
            int i = stageFilter.Count();
            return stageFilter;
        }
        /*public IQueryable<StageOpdracht> FindAll(Bedrijf bedrijf)
        {        
            return stageOpdrachten.OrderBy(b => b.Naam).Where(b => b.Bedrijf.Email == bedrijf.Email);
        }*/

        public IEnumerable<String> FindAllNamen()
        {
            ICollection<String> lijst = new List<string>();
            IEnumerable<StageOpdracht> list = stageOpdrachten.AsEnumerable();
            for (int i = 0; i < list.Count(); i++)
                lijst.Add(list.ElementAt(i).Naam);
            return lijst ;
        }

        public IQueryable<StageOpdracht> FindAllFilter(IEnumerable<StageOpdracht> lijst,string zoekopdracht)
        {
            IQueryable<StageOpdracht> list = null;
            if (stageOpdrachten.Where(b => b.Naam == zoekopdracht).Any())
                list = lijst.AsQueryable().Where(b => b.Naam.ToLower() == zoekopdracht.ToLower());
            else if (stageOpdrachten.Where(b => b.Specialisatie == zoekopdracht).Any())
                list = lijst.AsQueryable().Where(b => b.Specialisatie.ToLower() == zoekopdracht.ToLower());
            else if (zoekopdracht == "")
                list = lijst.AsQueryable();
            else
            {
                list = new List<StageOpdracht>().AsQueryable();
            }
            return list;
        }
        public void SaveChanges()
        {
            context.SaveChanges();
        }
        public void Update(StageOpdracht stage)
        {
            context.Entry(stage).State = EntityState.Modified;
        }

    }
}