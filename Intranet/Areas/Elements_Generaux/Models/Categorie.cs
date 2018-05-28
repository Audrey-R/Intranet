using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Intranet.Models;

namespace Intranet.Areas.Elements_Generaux.Models
{
    public class Categorie : Composant_General
    {
        [Key]
        public int Id { get; set; }
        public int LibelleCategorie { get; set; }
    }
}