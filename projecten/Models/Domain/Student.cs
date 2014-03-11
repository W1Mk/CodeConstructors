using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projecten.Models.Domain
{
    public class Student
    {
        private int id;
        private string naam { get; set; }

        public Student()
        {
            naam = "**";
        }
    }
}