using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Intranet.Models
{
    public class Collaborateur
    {
        [Key]
        public int Id { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
    }
}