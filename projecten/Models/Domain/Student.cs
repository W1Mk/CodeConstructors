using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace projecten.Models.Domain
{
    public class Student
    {
        //[Required, MaxLength(100)]
        public string naam { get; set; }
        //[Required, MaxLength(100)]
        public string Email { get; set; }
        public string tweedeEmail { get; set; }
       // [Required, MaxLength(100)]
        public string wachtwoord { get; set; }
        public string adres { get; set; }
        public string gsm { get; set; }
        public byte[] foto { get; set; }
        public string keuzevak {get;set;}
        //[Key]
        public int Studentid { get; set; }
        public int EersteAanmelding { get; set; }
        public virtual ICollection<StageOpdracht> Stageopdrachten { get; set; }
       
        public Student()
        {
            Stageopdrachten = new List<StageOpdracht>();
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
            naam = model.naam;
            tweedeEmail = model.tweedeEmail;
            adres = model.adres;
            gsm = model.gsm;
            keuzevak = model.keuzevak;
        }
        
    }
}