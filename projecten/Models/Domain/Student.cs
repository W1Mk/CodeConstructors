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
       // [Required, MaxLength(100)]
        public string wachtwoord { get; set; }
        public string adres { get; set; }
        public string gsm { get; set; }
        //[Key]
        public int Studentid { get; set; }
        

        public Student(int Studentid, string naam, string email, string wachtwoord) 
        {
            //id = 1;
           
        }
        public Student()
        {

        }
        
    }
}