using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Ninject.Infrastructure.Language;
using projecten.Models.Domain;

namespace projecten.Models.DAL
{
    public class StageBegeleiderRepository
    {
        private BedrijfContext context;
        private DbSet<StageBegeleider> begeleiders;
        private readonly List<StageBegeleider> begeleider = new List<StageBegeleider>();
        private StageOpdrachtRepository rep;
        public StageBegeleiderRepository(BedrijfContext context)
        {
            this.context = context;
            begeleiders = context.StageBegeleiders;
            rep = new StageOpdrachtRepository(context);
        }

        public void Add(StageBegeleider begeleider)
        {
            begeleiders.Add(begeleider);

        }
        public void Delete(StageBegeleider begeleider)
        {
            begeleiders.Remove(begeleider);
        }
        public StageBegeleider FindBy(int bedrijfId)
        {
            return begeleiders.Find(bedrijfId);

        }
        public StageBegeleider FindBy(String email)
        {
            return begeleiders.FirstOrDefault(b => b.Email == email);
        }
        public IEnumerable<StageBegeleider> GetBegeleiders()
        {
            return context.StageBegeleiders.ToList();
        }
        public void SaveChanges()
        {
            context.SaveChanges();
        }
        public void Update(StageBegeleider begeleider)
        {
            context.Entry(begeleider).State = EntityState.Modified;
        }
        public IEnumerable<StageBegeleider> FindAllByAdres(string adres)
        {
            begeleiders.ToList<StageBegeleider>();
            begeleider.AddRange(begeleiders);
            List<StageBegeleider> BegeleiderFilter = begeleider.FindAll(s => s.Adres == adres);

            return BegeleiderFilter;
        }
        public List<StageBegeleider> lijst()
        {
            List<StageBegeleider> begeleiderslijst = new List<StageBegeleider>();
            begeleiderslijst.Add(new StageBegeleider());
            return begeleiderslijst;
        }
        public int FindId(string email)
        {
            StageBegeleider tijdelijk = FindBy(email);

            return tijdelijk.Id;
        }
        public Boolean FindEqual(string email)
        {
            Boolean value = true; ;
            StageBegeleider tijdelijk;
            tijdelijk = FindBy(email);
            if (tijdelijk != null)
                value = true;
            else
                value = false;
            return value;
        }

        public Boolean EersteAanmelding(string email)
        {
            Boolean value = true; ;
            StageBegeleider tijdelijk = FindBy(email);
            if (tijdelijk.EersteAanmelding == 0)
                value = true;
            else
                value = false;
            return value;

        }

        public IQueryable<StageOpdracht> FindAll(StageBegeleider begeleider)
        {
            if (begeleider != null)
                return begeleider.Voorkeurstages.AsQueryable();
            return null;
        }
        /*public IQueryable<StageOpdracht> FindAllNietVoorkeur(StageBegeleider begeleider, string naam)
        {
            if (begeleider != null)
                if(begeleider.stages.AsQueryable().OrderBy(b => b.Naam).Where(b => b.Naam == naam) != null)
                return begeleider.stages.AsQueryable().OrderBy(b => b.Naam).Where(b => b.Naam == naam);
            return null;
        }*/

        /*public IEnumerable<String> FindAllNamen()
        {
            ICollection<String> lijst = new List<string>();
            IEnumerable<StageBegeleider> list = begeleiders.AsEnumerable();
            for (int i = 0; i < list.Count(); i++)
                lijst.Add(list.ElementAt(i).Naam);
            return lijst ;
        }*/
        public Boolean VoorkeurCheck(StageOpdracht stage)
        {
            Boolean value = false;
            int counter = 0;
            IEnumerable<StageBegeleider> lijst = GetBegeleiders();//lijst van alle begeleiders
           // IEnumerable<String> sublijst = rep.FindAllNamen();// lijst van alle namen van de stageopdrachten
            IEnumerable<StageOpdracht> sublijst2 = new List<StageOpdracht>();
            for (int i = 0; i < lijst.Count(); i++)
            {
                sublijst2 = lijst.ElementAt(i).stages;//geeft alle opdrachten van één begeleider mee                
                if (sublijst2.Any())//als deze lijst opdrachten bevat
                {
                        for (int j = 0; j < sublijst2.Count(); j++)
                        {
                            if (stage.Naam == sublijst2.ElementAt(j).Naam)
                                //vergelijkt de naam van een stageopdracht met de namen van de stageopdrachten van een begeleider.
                            {
                                counter++;                              
                            }
                        }
                    
                }
            }
            if (counter == 0)
                value = true;
            
            return value;
        }
        /*public IQueryable<StageOpdracht> FindAllOpdrachten(Bedrijf bedrijf)
        {
            if (bedrijf.stages != null)
                return bedrijf.stages.AsQueryable();

            return null;

        }*/
        /*public IQueryable<StageMentor> FindAllMentors(Bedrijf bedrijf)
        {
            if (bedrijf.mentors != null)
                return bedrijf.mentors.AsQueryable();

            return null;

        }*/
    }
}