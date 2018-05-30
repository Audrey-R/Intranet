﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Intranet.Areas.Composants.Models.Elements;
using Intranet.Models;

namespace Intranet.Areas.Elements_Generaux.Models.Categories
{
    public class Categorie 
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public Element_General ElementGeneral { get; set; }
    }
}