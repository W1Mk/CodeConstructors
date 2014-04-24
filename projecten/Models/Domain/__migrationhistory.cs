using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace projecten.Models.Domain
{
    public class __migrationhistory 
    {
        [Key]
        public int  MigrationId { get; set; }
        public string ContextKey { get; set; }
        public string Model { get; set; }
        public string ProductVersion { get; set; }

    }
}

