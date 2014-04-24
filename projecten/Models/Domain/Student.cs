using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace projecten.Models.Domain
{
    public class Student
    {
        [Required, MaxLength(100)]
        public string naam { get; set; }
        [Required, MaxLength(100)]
        public string email { get; set; }
        [Required, MaxLength(100)]
        public string wachtwoord { get; set; }
        [Key]
        public int id { get; set; }
        

        public Student(int id, string naam, string email, string wachtwoord) 
        {
            id = 1;
            naam = "Laurens";
            email = "voetballer.laurens@telenet.be";
        }
        
    }
}