using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Intranet.Areas.Elements_Communautaires.Models;
using Intranet.Areas.Elements_Generaux.Models;

namespace Intranet.Models
{
    public class Ressource : Element
    {
        //[Key]
        //public int IdRessource { get; set; }
        public Composant_Communautaire ComposantCommunautaire { get; set; }
        public string Titre { get; set; }
        public List<Media> ListeMediasAssocies { get; set; }
        //public virtual Categorie Categorie {get; set;}
    }
}