using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;

namespace projecten.Models.Domain
{
    public class StageOpdracht
    {
        public int StageOpdrachtid { get; set; }
        public string Naam { get; set; }
        public int Semester { get; set; }
        public string Omschrijving { get; set; }
        public string Specialisatie { get; set; }
        public int AantalStudenten { get; set; }
        public string StageMentor { get; set; }
        /*public Bedrijf Bedrijf { get; set; }
        public int Bedrijfid { get; set; }*/
        public string Status { get; set; }
        private string[] status { get; set; }
        public virtual ICollection<Student> studenten { get; set; }
        public virtual ICollection<StageBegeleider> begeleiders { get; set; }
        public virtual ICollection<StageBegeleider> voorkeurbegeleiders { get; set; }

        public StageOpdracht()
        {
            status = new string[] { "wachten", "goedgekeurd", "afgekeurd" };
            Status = status[0];
            studenten = new List<Student>();
            begeleiders = new List<StageBegeleider>();
            voorkeurbegeleiders = new List<StageBegeleider>();
        }

        public StageOpdracht(StageOpdrachtToevoegenModel model)
        {
            Naam = model.StageNaam;
            Semester = model.Semester;
            Omschrijving = model.Omschrijving;
            Specialisatie = model.Specialisatie;
            AantalStudenten = model.Aantal;
            StageMentor = model.StageMentor;
        }
        public void setUpdates(StageOpdrachtToevoegenModel stage)
        {
            Naam = stage.StageNaam;
            Semester = stage.Semester;
            Omschrijving = stage.Omschrijving;
            Specialisatie = stage.Specialisatie;
            AantalStudenten = stage.Aantal;
            StageMentor = stage.StageMentor;
        }

        public void setUpdates(IngenomenOpdrachtenModel stage)
        {
            Naam = stage.StageNaam;
            Semester = stage.Semester;
            Omschrijving = stage.Omschrijving;
            Specialisatie = stage.Specialisatie;
            AantalStudenten = stage.Aantal;
        }

        public SelectList GetstStudents(StageOpdracht stage)
        {
            SelectList list = new SelectList(stage.studenten,"naam","naam",0);
            return list;
        }
 


    }
}
