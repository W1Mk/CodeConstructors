using System.Collections.Generic;
using System.Web.Mvc;

namespace projecten.Models.Domain
{
    public class StageOpdracht
    {
        public int StageOpdrachtid { get; set; }
        public string Naam { get; set; }
        public string Semester { get; set; }
        public string Omschrijving { get; set; }
        public string Specialisatie { get; set; }
        public int AantalStudenten { get; set; }
        public string StageMentor { get; set; }
        public string Status { get; set; }
        public string Status2 { get; set; }
        public virtual ICollection<Student> StudentSolicitaties { get; set; }
        public virtual ICollection<Student> Studenten { get; set; }
        public virtual ICollection<StageBegeleider> Begeleiders { get; set; }
        public virtual ICollection<StageBegeleider> Voorkeurbegeleiders { get; set; }
        public string Academiejaar { get; set; }

        public StageOpdracht()
        {

            Studenten = new List<Student>();
            Begeleiders = new List<StageBegeleider>();
            Voorkeurbegeleiders = new List<StageBegeleider>();
            StudentSolicitaties = new List<Student>();
        }

        public StageOpdracht(StageOpdrachtToevoegenModel model)
        {
            Naam = model.StageNaam;
            Semester = model.Semester;
            Omschrijving = model.Omschrijving;
            Specialisatie = model.Specialisatie;
            AantalStudenten = model.Aantal;
            StageMentor = model.StageMentor;
            Academiejaar = model.Academiejaar;
        }
        public void setUpdates(StageOpdrachtToevoegenModel stage)
        {
            Naam = stage.StageNaam;
            Semester = stage.Semester;
            Omschrijving = stage.Omschrijving;
            Specialisatie = stage.Specialisatie;
            AantalStudenten = stage.Aantal;
            StageMentor = stage.StageMentor;
            Academiejaar = stage.Academiejaar;
        }

        public void setUpdates(IngenomenOpdrachtenModel stage)
        {
            Naam = stage.StageNaam;
            Semester = stage.Semester;
            Omschrijving = stage.Omschrijving;
            Specialisatie = stage.Specialisatie;
            AantalStudenten = stage.Aantal;
        }
        public void setUpdates(BegIngenomenOpdrachtenModel stage)
        {
            Omschrijving = stage.Omschrijving;
        }

        public SelectList GetstStudents(StageOpdracht stage)
        {
            SelectList list = new SelectList(stage.Studenten,"naam","naam",0);
            return list;
        }
    }
}
