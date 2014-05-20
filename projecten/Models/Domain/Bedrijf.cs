
using System.Collections.Generic;
using System.Linq;

namespace projecten.Models.Domain
{
    public class Bedrijf
    {
        public int BedrijfId { get; set; }
        public string Bedrijfsnaam { get; set; }
        public string Email { get; set; }
        public string telefoon { get; set; }
        public string adres { get; set; }
        public string url { get; set; }
        public string Wachtwoord { get; set; }
        public string Bedrijfsactiviteit { get; set; }
        public string Bereikbaarheid { get; set; }
        public byte[] Foto { get; set; }
        public string FotoString { get; set; }
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