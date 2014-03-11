using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projecten.Models.Domain
{
    public class StageBegeleider
    {
        private int id;
        private string naam { get; set; }
        private Student student { get; set; }

        public StageBegeleider()
        {
            naam = "**";
            student = null;
        }
    }
}