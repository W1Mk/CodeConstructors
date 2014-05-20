using System;
using System.ComponentModel.DataAnnotations;
using projecten.Models.Domain;

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
        [Required(ErrorMessage = "Email is verplicht")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Wachtwoord is verplicht")]
        [DataType(DataType.Password)]
        [Display(Name = "Wachtwoord")]
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
        [Required(ErrorMessage = "Bedrijfsnaam is verplicht")]
        [StringLength(100, ErrorMessage = "de {0} moet minstens {2} karakters lang zijn.", MinimumLength = 3)]
        [Display(Name = "Bedrijfsnaam")]
        public string BedrijfsNaam { get; set; }

        [Required(ErrorMessage = "Adres is verplicht")]
        [Display(Name = "Adres")]
        public string Adres { get; set; }

        [Required(ErrorMessage = "Url is verplicht")]
        [DataType(DataType.Url)]
        [Display(Name = "Url")]
        // [RegularExpression("http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?", ErrorMessage = "Geen correcte Url ingevoerd")]
        public string Url { get; set; }

        [Required(ErrorMessage = "Email is verplicht")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Email adres is niet correct ingevoerd")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Wachtwoord { get; set; }

        [Required(ErrorMessage = "Telefoon is verplicht")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefoon")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Telefoon moet een getal zijn.")]
        public string Telefoon { get; set; }

        [Required(ErrorMessage = "Bereikbaarheid is verplicht")]
        [Display(Name = "Bereikbaarheid")]
        public string Bereikbaarheid { get; set; }

        [Required(ErrorMessage = "Bedrijfsactiviteit is verplicht")]
        [Display(Name = "Bedrijfsactiviteit")]
        public string BedrijfsActiviteit { get; set; }

        [Display(Name = "Logo")]
        public string Logo { get; set; }
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
        [RegularExpression("^[0-9]*$", ErrorMessage = "Gsm moet een getal zijn.")]
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
        [Required(ErrorMessage = "Naam is verplicht")]
        [StringLength(50, ErrorMessage = "de {0} moet minstens {2} karakters lang zijn.", MinimumLength = 3)]
        [Display(Name = "Naam")]
        public String Naam { get; set; }

        [Required(ErrorMessage = "Voornaam is verplicht")]
        [StringLength(50, ErrorMessage = "de {0} moet minstens {2} karakters lang zijn.", MinimumLength = 3)]
        [Display(Name = "Voornaam")]
        public String Voornaam { get; set; }

        [Required(ErrorMessage = "Email is verplicht")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-mail")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Email adres is niet correct ingevoerd")]
        public String Email { get; set; }

        [Required(ErrorMessage = "Gsm is verplicht")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Gsm")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Gsm moet een getal zijn.")]
        public String Gsm { get; set; }

        [Required(ErrorMessage = "Functie is verplicht")]
        [Display(Name = "Functie")]
        public String Functie { get; set; }

        [Required(ErrorMessage = "Aanspreektitel is verplicht")]
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
        public string Semester { get; set; }

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
        [Required(ErrorMessage = "Stagenaam is verplicht")]
        [StringLength(100, ErrorMessage = "de {0} moet minstens {2} karakters lang zijn.", MinimumLength = 3)]
        [Display(Name = "Stagenaam")]
        public String StageNaam { get; set; }

        [Required(ErrorMessage = "omschrijving is verplicht")]
        [StringLength(500, ErrorMessage = "de {0} moet minstens {2} karakters lang zijn.", MinimumLength = 10)]
        [Display(Name = "Omschrijving")]
        public String Omschrijving { get; set; }

        [Required(ErrorMessage = "Specialisatie is verplicht")]
        [Display(Name = "Specialisatie")]
        public String Specialisatie { get; set; }

        [Required(ErrorMessage = "Semester is verplicht")]
        [Display(Name = "Semester")]
        public string Semester { get; set; }

        [Required(ErrorMessage = "Aantal studenten is verplicht")]
        [Display(Name = "Aantal studenten")]
        public int Aantal { get; set; }
    }
    public class BegIngenomenOpdrachtenModel
    {
        public BegIngenomenOpdrachtenModel()
        {

        }

        public BegIngenomenOpdrachtenModel(StageOpdracht opdracht)
        {
            Omschrijving = opdracht.Omschrijving;
        }
        [Required(ErrorMessage = "omschrijving is verplicht")]
        [StringLength(500, ErrorMessage = "de {0} moet minstens {2} karakters lang zijn.", MinimumLength = 10)]
        [Display(Name = "Omschrijving")]
        public String Omschrijving { get; set; }
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
            Academiejaar = stage.Academiejaar;
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
        public string Semester { get; set; }

        [Required(ErrorMessage = "Aantal studenten is verplicht")]
        [Display(Name = "Aantal Studenten")]
        public int Aantal { get; set; }

        [Required(ErrorMessage = "Academiejaar is verplicht")]
        [Display(Name = "Academiejaar")]
        public string Academiejaar { get; set; }

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

        [Display(Name = "Huidig wachtwoord")]
        public string CurrentWachtwoord { get; set; }

        [Required(ErrorMessage = "Niew wachtwoord is verplicht")]
        [StringLength(100, ErrorMessage = "het {0} moet minstens {2} caracters lang zijn.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nieuw wachtwoord")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Dit veld is verplicht")]
        [DataType(DataType.Password)]
        [Display(Name = "Bevestig nieuw wachtwoord")]
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
        [RegularExpression("^[0-9]*$", ErrorMessage = "Telefoon moet een getal zijn.")]
        public string Telefoon { get; set; }

        [Required(ErrorMessage = "Gsm is verplicht")]
        [Display(Name = "Gsm")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Gsm moet een getal zijn.")]
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

    public class ContactProjectModel
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
        [Display(Name = "Omschrijving project")]
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
    
