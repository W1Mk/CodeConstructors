using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace projecten.Models
{
     public class ProfielModel
    {
        
        [Display(Name = "adres")]
        public string adres { get; set; }

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
	
}