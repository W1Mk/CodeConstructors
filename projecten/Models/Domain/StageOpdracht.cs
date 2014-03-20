using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projecten.Models.Domain
{
    public class StageOpdracht
    {
        private int id;
        private string naam { get; set; }
        // private Student student { get; set; }
        private string semester { get; set; }
        private string omschrijving { get; set; }
        private string specialisatie { get; set; }
        private string aantalStudenten { get; set; }
        private string stageMentor { get; set; }

        public StageOpdracht()
        {
            //StageOpdrachten = new List<StageOpdracht>();
            naam = naam;
            // student = student;
        }

        public StageOpdracht(String naam, String semester)
        {
            this.naam = naam;
            this.semester = semester;
        }
        public virtual ICollection<StageOpdracht> StageOpdrachten { get; private set; }
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Semester { get; set; }
        public string Omschrijving { get; set; }
        public string Specialisatie { get; set; }
        public string AantalStudenten { get; set; }
        public string StageMentor { get; set; }
    }
}
