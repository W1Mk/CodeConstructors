using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projecten.Models.Domain
{
    public class Bedrijf
    {
        private int id { get; set; }
        private string naam { get; set; } 
        private string email { get; set; }
        private string url { get; set; }
        private string telefoon { get; set; }
        private string paswoord { get; set; }
        private string adres { get; set; }
        private string bedrijfsactiviteit { get; set; }
        private string bereikbaarheid { get; set; }
        private StageOpdracht stageOpdracht { get; set; }

    
        public Bedrijf()
        {
            naam ="*";
            email = "*@*.*";
            url = "*..*";
            telefoon = "0000000000";
            paswoord = "paswoord";
            adres = "**";
            bedrijfsactiviteit = "Bedrijf";
            bereikbaarheid = "wagen";
            stageOpdracht = null;
        }
        public int Id
        {
            get { return Id; }
            private set { Id = value; }
        }

        public string Naam { get; set; }
        public string Email { get; set; }
        public string Telefoon { get; set; }
        public string Adres { get; set; }
        public string Url { get; set; }
        public string Paswoord { get; set; }
        public string Bedrijfsactiviteit { get; set; }
        public string Bereikbaarheid { get; set; }
        public virtual ICollection<StageOpdracht> stages { get; set; }

        public void AddStageOpdracht(StageOpdracht stage)
        {
            stages.Add(stage);
        }
    }
}