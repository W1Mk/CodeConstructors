using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projecten.Models.Domain
{
    public class StageOpdracht
    {
        private int id;
        private string naam { get; set; }
        private Student student { get; set; }

        public StageOpdracht()
        {
            naam = "**";
            student = student;
        }
    }
}