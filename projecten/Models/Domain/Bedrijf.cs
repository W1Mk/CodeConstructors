using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace projecten.Models.Domain
{
    public class Bedrijf
    {
        //[Key]
        public int BedrijfId { get; set; }
        //[Required, MaxLength(50)]
        public string Bedrijfsnaam { get; set; }
       // [Required, MaxLength(50)]
        public string Email { get; set; }
       // [MaxLength(20)]
        public string telefoon { get; set; }
       // [Required, MaxLength(50)]
        public string adres { get; set; }
       // [MaxLength(50)]
        public string url { get; set; }
       // [Required, MaxLength(20)]
        public string Wachtwoord { get; set; }
       // [Required, MaxLength(20)]
        public string bedrijfsactiviteit { get; set; }
       // [Required, MaxLength(20)]
        public string bereikbaarheid { get; set; }
        public virtual ICollection<StageOpdracht> stages { get; set; }
        public virtual ICollection<StageMentor> mentors { get; set; }


        public Bedrijf()
        {
            stages = new List<StageOpdracht>();
            mentors = new List<StageMentor>();
        }

        public Bedrijf(string bedrijfsnaam):this()
        {
            Bedrijfsnaam = bedrijfsnaam;
        }
         public Bedrijf(string Bedrijfsnaam,string Email,string Wachtwoord)
            : this(Bedrijfsnaam)
        {
            this.Email = Email;
            this.Wachtwoord = Wachtwoord;
        }
        public void AddStageOpdracht(StageOpdracht stage)
        {
            stages.Add(stage);
        }

        public StageOpdracht DeleteStageOpdracht(int id)
        {
            StageOpdracht stageOpdracht = stages.Where(l => l.StageOpdrachtid.Equals(id)).SingleOrDefault();
            if (stageOpdracht != null)
                stages.Remove(stageOpdracht);
            return stageOpdracht;
        }

        public void AddStageMentor(StageMentor mentor)
        {
            mentors.Add(mentor);
        }

        public StageMentor DeleteStageMentor(int id)
        {
            StageMentor mentor = mentors.Where(l => l.StageMentorId.Equals(id)).SingleOrDefault();
            if (mentor != null)
                mentors.Remove(mentor);
            return mentor;
        }
        
    }
}