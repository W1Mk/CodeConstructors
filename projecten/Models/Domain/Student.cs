using System;
using System.Collections.Generic;
using System.Linq;

namespace projecten.Models.Domain
{
    public class Student
    {
        public string Naam { get; set; }
        public string Email { get; set; }
        public string TweedeEmail { get; set; }
        public string Wachtwoord { get; set; }
        public string Adres { get; set; }
        public string Gsm { get; set; }
        public byte[] Foto { get; set; }
        public string Keuzevak {get;set;}
        public int Studentid { get; set; }
        public DateTime? BeginDatum { get; set; }
        public DateTime? EindeDatum { get; set; }
        public string StageContract { get; set; }
        public virtual ICollection<StageOpdracht> Solicitaties { get; set; }  
        public virtual ICollection<StageOpdracht> Stageopdrachten { get; set; }
       
        public Student()
        {
            Stageopdrachten = new List<StageOpdracht>();
            Solicitaties = new List<StageOpdracht>();
        }

        public void Soliciteer(StageOpdracht opdracht)
        {
            Solicitaties.Add(opdracht);
        }

        public void VerwijderSolicitatie(StageOpdracht opdracht)
        {
            Solicitaties.Remove(opdracht);
        }
        public void AddStageOpdracht(StageOpdracht stageopdracht)
        {
            Stageopdrachten.Add(stageopdracht);
            
        }

        public void DeleteStageOpdracht(StageOpdracht stageopdracht)
        {
            Stageopdrachten.Remove(stageopdracht);
        }

        public List<StageOpdracht> getStageOpdrachten()
        {
            List<StageOpdracht> lijst = Stageopdrachten.ToList();
            return lijst;
        }

        public void setUpdates(ProfielModel model)
        {
            Naam = model.Naam;
            TweedeEmail = model.TweedeEmail;
            Adres = model.Adres;
            Gsm = model.Gsm;
            Keuzevak = model.Keuzevak;
        }
        
    }
}