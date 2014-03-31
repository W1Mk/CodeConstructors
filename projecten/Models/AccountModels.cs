using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace projecten.Models
{
    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Student> Student { get; set; }
    }

    [Table("UserProfile")]
    public class UserProfile
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Wachtwoord { get; set; }
        public string TypePersoon { get; set; }
    }
    [Table("Student")]
    public class Student
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Wachtwoord { get; set; }

    }

    public class LocalPasswordModel
    {
        
       
        public string OldPassword { get; set; }

        [Required]
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
        [Required]
        [Display(Name = "email")]
        public string Email { get; set; }

        [Required]
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
        [Required]
        [Display(Name = "bedrijfsnaam")]
        public string BedrijfsNaam { get; set; }

        [Required]
        [Display(Name = "adres")]
        public string Adres { get; set; }

        [Required]
        [DataType(DataType.Url)]
        [Display(Name = "url")]
        // [RegularExpression("http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?", ErrorMessage = "Geen correcte Url ingevoerd")]
        public string Url { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "e-mail")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Email adres is niet correct ingevoerd")]
        public string email { get; set; }

        [DataType(DataType.Password)]
        public string Wachtwoord { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "telefoon")]
        public string Telefoon { get; set; }

        [Required]
        [Display(Name = "bereikbaarheid")]
        public string Bereikbaarheid { get; set; }




        [Required]
        [Display(Name = "bedrijfsactiviteit")]
        public string BedrijfsActiviteit { get; set; }
    }

    public class StageOpdrachtenModel
    {
        [Required]
        [Display(Name = "StageNaam")]
        public string StageNaam { get; set; }

        [Required]
        [Display(Name = "Omschrijving")]
        public string Omschrijving { get; set; }

        [Required]
        [Display(Name = "Specialisatie")]
        public string Specialisatie { get; set; }

        [Required]
        [Display(Name = "Semester")]
        public String Semester { get; set; }

        [Required]
        [Display(Name = "Aantal Studenten")]
        public String Aantal { get; set; }

        [Required]
        [Display(Name = "StageMentor")]
        public String StageMentor { get; set; }
    }
    }

    public class StageOpdrachtToevoegenModel
    {
        [Required]
        [Display(Name = "StageNaam")]
        public String StageNaam { get; set; }

        [Required]
        [Display(Name = "Omschrijving")]
        public String Omschrijving { get; set; }

        [Required]
        [Display(Name = "Specialisatie")]
        public String Specialisatie { get; set; }

        [Required]
        [Display(Name = "Semester")]
        public String Semester { get; set; }

        [Required]
        [Display(Name = "Aantal Studenten")]
        public String Aantal { get; set; }

        [Required]
        [Display(Name = "StageMentor")]
        public String StageMentor { get; set; }
    }

    public class LoginStudentModel
    {
        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }

        [Required]
        [Display(Name = "Wachtwoord")]
        [DataType(DataType.Password)]
        public String Wachtwoord { get; set; }



    }
    public class RegistreerStudentModel
    {
        [Display(Name = "Email")]
        public String Email { get; set; }
        public String Wachtwoord { get; set; }

    }
    public class WachtwoordVeranderenModel
    {
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "huidig wachtwoord")]
        public string CurrentWachtwoord { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "het {0} moet minstens {2} caracters lang zijn.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "nieuw wachtwoord")]
        public string NewPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "bevestig nieuw wachtwoord")]
        [Compare("NewPassword", ErrorMessage = "Het nieuwe wachtwoord komt niet overeen met het bevestigingswachtwoord.")]
        public string ConfirmPassword { get; set; }

    }
    public class ExternalLogin
    {
        public string Provider { get; set; }
        public string ProviderDisplayName { get; set; }
        public string ProviderUserId { get; set; }
    }

