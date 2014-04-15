using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace projecten.Models.Domain
{
    public class StageOpdracht
    {
        
        public int StageOpdrachtId { get; set; }
        public string Naam { get; set; }
        public string Semester { get; set; }
        public string Omschrijving { get; set; }
        public string Specialisatie { get; set; }
        public string AantalStudenten { get; set; }
        public string StageMentor { get; set; }
        public Bedrijf Bedrijf { get; set; }
        public string Status { get; set; }
        private string[] status { get; set; }
        public string Email { get; set; }
        //public virtual ICollection<StageOpdracht> StageOpdrachten { get; private set; }

        public StageOpdracht()
        {
            //StageOpdrachten = new Collection<StageOpdracht>();
            status = new string[]{"wachten", "goedgekeurd", "afgekeurd"};
            Status = status[0];
        }

        
    }
}
