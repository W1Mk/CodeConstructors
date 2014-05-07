using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projecten.Models.Domain
{
    public class StageBegeleider
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string VoorNaam { get; set; }
        public string Adres { get; set; }
        public string Email { get; set; }
        public string Telefoon { get; set; }
        public string Gsm { get; set; }
        public string Wachtwoord { get; set; }
        public byte[] Foto { get; set; }
        public int EersteAanmelding { get; set; }
        public virtual ICollection<StageOpdracht> stages { get; set; }
        public virtual ICollection<StageOpdracht> Voorkeurstages { get; set; }
        public virtual ICollection<StageOpdracht> VoorkeurDefinitief { get; set; } 

        public StageBegeleider()
        {
            stages = new List<StageOpdracht>();
            Voorkeurstages = new List<StageOpdracht>();
            VoorkeurDefinitief = new List<StageOpdracht>();
        }

        public void setVoorkeurTrue(StageOpdracht stage)
        {
            Voorkeurstages.Add(stage);
        }
        public void setVoorkeurFalse(StageOpdracht stage)
        {
            Voorkeurstages.Remove(stage);
        }

        public void setUpdates(StageBegeleiderModel model)
        {
            Naam = model.Naam;
            VoorNaam = model.VoorNaam;
            Adres = model.Adres;
            Email = model.Email;
            Telefoon = model.Telefoon;
            Gsm = model.Gsm;
        }

        public IEnumerable<StageOpdracht> getIngenomenOpdrachten()
        {
            ICollection<StageOpdracht> lijst = new List<StageOpdracht>();
            for (int i = 0; i < stages.Count(); i++)
            {
                if (stages.ElementAt(i).studenten.Any() && stages.ElementAt(i).Status == "Goedgekeurd")
                {
                    lijst.Add(stages.ElementAt(i));
                }
            }
            return lijst;
        }

        public void VoegOpdrachtAanBegeleidersToe(IEnumerable<StageBegeleider> lijst, StageOpdracht stage)
        {
            for (int i = 0; i < lijst.Count(); i++)
            {
                lijst.ElementAt(i).SetOpdrachtBeschikbaar(stage);
            }
        }

        public void SetOpdrachtBeschikbaar(StageOpdracht stage)
        {
            stages.Add(stage);
        }
    }
}