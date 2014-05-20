using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;
using projecten.Models.Domain;

namespace projecten.Models
{
     public class ProfielModel
    {
         public ProfielModel()
         {   
         }

         public ProfielModel(Student student)
         {
             Email = student.Email;
             TweedeEmail = student.TweedeEmail;
             Naam = student.Naam;
             Keuzevak = student.Keuzevak;
             Adres = student.Adres;
             Gsm = student.Gsm;
             if(student.Foto != null)
             Foto = student.Foto.ToString();
             else
             {
                 Foto = "geen foto";
             }
         }
         [Display(Name = "Email")]
         public string Email { get; set; }

         [Display(Name = "adres")]
         public string TweedeEmail { get; set; }

         [Display(Name = "naam")]
         public string Naam { get; set; }
        

         [Display(Name = "keuzevak")]
         public string Keuzevak { get; set; }

          [Display(Name = "adres")]
        public string Adres { get; set; }

       
        [Display(Name = "foto")]
        public string Foto { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "gsm")]
        public string Gsm { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "NieuwWachtwoord")]
        public string NieuwWachtwoord { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "OudWachtwoord")]
        public string OudWachtwoord { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "BevestigWachtwoord")]
        [Compare("NieuwWachtwoord", ErrorMessage = "Het nieuwe wachtwoord komt niet overeen met het bevestigings wachtwoord.")]
        public string BevestigWachtwoord { get; set; }

        
    }
     public class StagesModel
     {

         public Guid Id { get; set; }
         public string Title { get; set; }
         public string Description { get; set; }
         public string Level { get; set; }
     }
	
}