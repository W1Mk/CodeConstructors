using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;
using System.Windows.Forms;
using projecten.Models.Domain;
using CheckBox = System.Web.UI.WebControls.CheckBox;

namespace projecten.Models
{
   
       

    public class LocalPasswordModel
    {
        
       
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Dit veld is verplicht")]
        [StringLength(100, ErrorMessage = "de {0} moet minstens {2} karakters lang zijn.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nieuw wachtwoord")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Bevestig nieuw wachtwoord")]
        [Compare("NewPassword", ErrorMessage = "Het nieuwe wachtwoord komt niet overeen met het huidig wachtwoord.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginModel
    {
        [Required(ErrorMessage = "Dit veld is verplicht")]
        [Display(Name = "email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Dit veld is verplicht")]
        [DataType(DataType.Password)]
        [Display(Name = "wachtwoord")]
        public string Wachtwoord { get; set; }

        [Display(Name = "onthouden?")]
        public bool RememberMe { get; set; }
    }
    public class SelectAccountModel
    {
        [Display(Name = "Account")]
        public String Account { get; set; }
    }

    public class RegisterModel
    {
        [Required(ErrorMessage = "Dit veld is verplicht")]
        [Display(Name = "bedrijfsnaam")]
        public string BedrijfsNaam { get; set; }

        [Required(ErrorMessage = "Dit veld is verplicht")]
        [Display(Name = "adres")]
        public string Adres { get; set; }

        [Required(ErrorMessage = "Dit veld is verplicht")]
        [DataType(DataType.Url)]
        [Display(Name = "url")]
        // [RegularExpression("http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?", ErrorMessage = "Geen correcte Url ingevoerd")]
        public string Url { get; set; }

        [Required(ErrorMessage = "Dit veld is verplicht")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "e-mail")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Email adres is niet correct ingevoerd")]
        public string email { get; set; }

        [DataType(DataType.Password)]
        public string Wachtwoord { get; set; }

        [Required(ErrorMessage = "Dit veld is verplicht")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "telefoon")]
        public string Telefoon { get; set; }

        [Required(ErrorMessage = "Dit veld is verplicht")]
        [Display(Name = "bereikbaarheid")]
        public string Bereikbaarheid { get; set; }

        [Required(ErrorMessage = "Dit veld is verplicht")]
        [Display(Name = "bedrijfsactiviteit")]
        public string BedrijfsActiviteit { get; set; }

        public string Foto { get; set; }
    }
    public class DeleteOpdracht
    {
        [Display(Name = "Naam")]
        public String Naam { get; set; }
    }
    public class StageMentorModel
    {
        public StageMentorModel(StageMentor mentor)
        {
            Naam = mentor.Naam;
            Voornaam = mentor.Voornaam;
            Email = mentor.Email;
            Gsm = mentor.Gsm;
            Functie = mentor.Functie;
            Aanspreektitel = mentor.Aanspreektitel;
        }

        public StageMentorModel()
        {
            
        }

        [Display(Name = "Naam")]
        public String Naam { get; set; }

        [Display(Name = "Voornaam")]
        public String Voornaam { get; set; }

        [Display(Name = "E-mail")]
        public String Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Gsm")]
        public String Gsm { get; set; }

        [Display(Name = "Functie")]
        public String Functie { get; set; }

        [Display(Name = "Aanspreektitel")]
        public String Aanspreektitel { get; set; }

    }
    public class StageMentorWijzigenModel
    {
        public StageMentorWijzigenModel(StageMentor mentor)
        {
            Naam = mentor.Naam;
            Voornaam = mentor.Voornaam;
            Email = mentor.Email;
            Gsm = mentor.Gsm;
            Functie = mentor.Functie;
            Aanspreektitel = mentor.Aanspreektitel;
        }

        public StageMentorWijzigenModel()
        {

        }
        [Required(ErrorMessage = "Dit veld is verplicht")]
        [StringLength(100, ErrorMessage = "de {0} moet minstens {2} karakters lang zijn.", MinimumLength = 3)]
        [Display(Name = "Naam")]
        public String Naam { get; set; }

        [Required(ErrorMessage = "Dit veld is verplicht")]
        [StringLength(100, ErrorMessage = "de {0} moet minstens {2} karakters lang zijn.", MinimumLength = 3)]
        [Display(Name = "Voornaam")]
        public String Voornaam { get; set; }

        [Required(ErrorMessage = "Dit veld is verplicht")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-mail")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Email adres is niet correct ingevoerd")]
        public String Email { get; set; }

        [Required(ErrorMessage = "Dit veld is verplicht")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Gsm")]
        public String Gsm { get; set; }

        [Required(ErrorMessage = "Dit veld is verplicht")]
        [Display(Name = "Functie")]
        public String Functie { get; set; }

        [Required(ErrorMessage = "Dit veld is verplicht")]
        [Display(Name = "Aanspreektitel")]
        public String Aanspreektitel { get; set; }

    }
    public class StageOpdrachtenModel
    {
        [Required(ErrorMessage = "Dit veld is verplicht")]
        [StringLength(100, ErrorMessage = "de {0} moet minstens {2} karakters lang zijn.", MinimumLength = 3)]
        [Display(Name = "Stagenaam")]
        public String StageNaam { get; set; }

        [Required(ErrorMessage = "Dit veld is verplicht")]
        [StringLength(500, ErrorMessage = "de {0} moet minstens {2} karakters lang zijn.", MinimumLength = 10)]
        [Display(Name = "Omschrijving")]
        public String Omschrijving { get; set; }

        [Required(ErrorMessage = "Dit veld is verplicht")]
        [Display(Name = "Specialisatie")]
        public String Specialisatie { get; set; }

        [Required(ErrorMessage = "Dit veld is verplicht")]
        [Display(Name = "Semester")]
        public int Semester { get; set; }

        [Required(ErrorMessage = "Dit veld is verplicht")]
        [Display(Name = "Aantal Studenten")]
        public int Aantal { get; set; }

        [Required(ErrorMessage = "Dit veld is verplicht")]
        [Display(Name = "Status")]
        public String Status { get; set; }

        [Display(Name = "Stagementor")]
        public String StageMentor { get; set; }
    }

    public class IngenomenOpdrachtenModel
    {
        public IngenomenOpdrachtenModel()
        {
            
        }

        public IngenomenOpdrachtenModel(StageOpdracht opdracht)
        {
            StageNaam = opdracht.Naam;
            Omschrijving = opdracht.Omschrijving;
            Specialisatie = opdracht.Specialisatie;
            Semester = opdracht.Semester;
            Aantal = opdracht.AantalStudenten;
        }
        [Required(ErrorMessage = "Dit veld is verplicht")]
        [StringLength(100, ErrorMessage = "de {0} moet minstens {2} karakters lang zijn.", MinimumLength = 3)]
        [Display(Name = "Stagenaam")]
        public String StageNaam { get; set; }

        [Required(ErrorMessage = "Dit veld is verplicht")]
        [StringLength(500, ErrorMessage = "de {0} moet minstens {2} karakters lang zijn.", MinimumLength = 10)]
        [Display(Name = "Omschrijving")]
        public String Omschrijving { get; set; }

        [Required(ErrorMessage = "Dit veld is verplicht")]
        [Display(Name = "Specialisatie")]
        public String Specialisatie { get; set; }

        [Required(ErrorMessage = "Dit veld is verplicht")]
        [Display(Name = "Semester")]
        public int Semester { get; set; }

        [Required(ErrorMessage = "Dit veld is verplicht")]
        [Display(Name = "Aantal Studenten")]
        public int Aantal { get; set; }
    }
    public class StageOpdrachtToevoegenModel
    {
        public StageOpdrachtToevoegenModel(StageOpdracht stage)
        {
            StageNaam = stage.Naam;
            Omschrijving = stage.Omschrijving;
            Specialisatie = stage.Specialisatie;
            Semester = stage.Semester;
            Aantal = stage.AantalStudenten;
            StageMentor = stage.StageMentor;
        }

        public StageOpdrachtToevoegenModel()
        {
            
        }
        [Required(ErrorMessage = "Stagenaam is verplicht")]
        [StringLength(100, ErrorMessage = "de {0} moet minstens {2} karakters lang zijn.", MinimumLength = 3)]
        [Display(Name = "Stagenaam")]
        public String StageNaam { get; set; }

        [Required(ErrorMessage = "Omschrijving is verplicht")]
        [StringLength(500, ErrorMessage = "de {0} moet minstens {2} karakters lang zijn.", MinimumLength = 10)]
        [Display(Name = "Omschrijving")]
        public String Omschrijving { get; set; }

        [Required(ErrorMessage = "Specialisatie is verplicht")]
        [Display(Name = "Specialisatie")]
        public String Specialisatie { get; set; }

        [Required(ErrorMessage = "Semester is verplicht")]
        [Display(Name = "Semester")]
        public int Semester { get; set; }

        [Required(ErrorMessage = "Aantal studenten is verplicht")]
        [Display(Name = "Aantal Studenten")]
        public int Aantal { get; set; }

        [Required(ErrorMessage = "Stagementor is verplicht")]
        [Display(Name = "Stagementor")]
        public String StageMentor { get; set; }
    }

    public class LoginStudentModel
    {
        [Required(ErrorMessage = "Dit veld is verplicht")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }

        [Required(ErrorMessage = "Dit veld is verplicht")]
        [Display(Name = "Wachtwoord")]
        [DataType(DataType.Password)]
        public String Wachtwoord { get; set; }
    }
    public class EersteAanmeldingModel
    {
        [Required(ErrorMessage = "Email is verplicht")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }

        [Required(ErrorMessage = "Wachtoord is verplichtd")]
        [Display(Name = "Geef je wachtwoord in")]
        [DataType(DataType.Password)]
        public String Wachtwoord { get; set; }

        [Required(ErrorMessage = "Bevestig je wachtwoord!")]
        [Display(Name = "Bevestig je wachtwoord")]
        [DataType(DataType.Password)]
        public string Wachtwoordbevestigd { get; set; }
    }
    public class RegistreerStudentModel
    {
        [Display(Name = "Email")]
        [Required]
        public String Email { get; set; }
        [Required(ErrorMessage = "Dit veld is verplicht")]
        [DataType(DataType.Password)]
        public String Wachtwoord { get; set; }

    }
    public class WachtwoordVeranderenModel
    {
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "huidig wachtwoord")]
        public string CurrentWachtwoord { get; set; }

        [Required(ErrorMessage = "Niew wachtwoord is verplicht")]
        [StringLength(100, ErrorMessage = "het {0} moet minstens {2} caracters lang zijn.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "nieuw wachtwoord")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Dit veld is verplicht")]
        [DataType(DataType.Password)]
        [Display(Name = "bevestig nieuw wachtwoord")]
        [Compare("NewPassword", ErrorMessage = "Het nieuwe wachtwoord komt niet overeen met het bevestigingswachtwoord.")]
        public string ConfirmPassword { get; set; }

    }

    public class StageBegeleiderModel
    {
        public StageBegeleiderModel()
        {
            
        }

        public StageBegeleiderModel(StageBegeleider begeleider)
        {
            Naam = begeleider.Naam;
            VoorNaam = begeleider.VoorNaam;
            Adres = begeleider.Adres;
            Email = begeleider.Email;
            Telefoon = begeleider.Telefoon;
            Gsm = begeleider.Gsm;
            if (begeleider.Foto != null)
                Foto = begeleider.Foto.ToString();
            else
            {
                Foto = "geen foto";
            }
        }
        [Required(ErrorMessage = "Naam is verplicht")]
        [Display(Name = "Naam")]
        public string Naam { get; set; }

        [Required(ErrorMessage = "Voornaam is verplicht")]
        [Display(Name = "Voornaam")]
        public string VoorNaam { get; set; }

        [Required(ErrorMessage = "Adres is verplicht")]
        [Display(Name = "Adres")]
        public string Adres { get; set; }

        [Required(ErrorMessage = "Email is verplicht")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telefoon is verplicht")]
        [Display(Name = "Telefoon")]
        public string Telefoon { get; set; }

        [Required(ErrorMessage = "Gsm is verplicht")]
        [Display(Name = "Gsm")]
        public string Gsm { get; set; }

        [Display(Name = "Foto")]
        public string Foto { get; set; }
    }

    public class ContactModel
    {
        [Required(ErrorMessage = "Naam is verplicht")]
        [Display(Name = "Naam")]
        public string Naam { get; set; }

        [Required(ErrorMessage = "Voornaam is verplicht")]
        [Display(Name = "Voornaam")]
        public string Voornaam { get; set; }

        [Required(ErrorMessage = "Bedrijf is verplicht")]
        [Display(Name = "Bedrijf")]
        public string Bedrijf { get; set; }
        
        [Required(ErrorMessage = "Omschrijving is verplicht")]
        [Display(Name = "Omschrijving bachelorproef")]
        public string Omschrijving { get; set; }

        [Required(ErrorMessage = "Vragen/Opmerkingen is verplicht")]
        [Display(Name = "Vragen/Opmerkingen")]
        public string Vragen { get; set; }
    }
    
    public class ExternalLogin
    {
        public string Provider { get; set; }
        public string ProviderDisplayName { get; set; }
        public string ProviderUserId { get; set; }
    }
}
    
