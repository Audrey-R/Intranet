using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Intranet.Areas.Composants.Models.Elements;
using Intranet.Areas.Elements_Generaux.Models.Categories;

namespace Intranet.Areas.Elements_Generaux.ViewModels.Creer
{
    public class CategorieViewModel 
    {
        public String Categorie { get; set; }
        public int ElementId { get; set; }
    }
}