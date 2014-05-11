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
             tweedeEmail = student.tweedeEmail;
             naam = student.naam;
             keuzevak = student.keuzevak;
             adres = student.adres;
             gsm = student.gsm;
             if(student.foto != null)
             foto = student.foto.ToString();
             else
             {
                 foto = "geen foto";
             }
         }
         [Display(Name = "Email")]
         public string Email { get; set; }

         [Display(Name = "adres")]
         public string tweedeEmail { get; set; }

         [Display(Name = "naam")]
         public string naam { get; set; }
        

         [Display(Name = "keuzevak")]
         public string keuzevak { get; set; }

          [Display(Name = "adres")]
        public string adres { get; set; }

       
        [Display(Name = "foto")]
        public string foto { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "gsm")]
        public string gsm { get; set; }

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