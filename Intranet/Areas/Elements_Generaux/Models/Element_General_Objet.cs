﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Intranet.Areas.Composants.Models.Elements;

namespace Intranet.Areas.Elements_Generaux.Models
{
    public class Element_General_Objet
    {
        [Key]
        public int Id { get; set; }
        public string Libelle { get; set; }
        public Element Element { get; set; }
    }
}