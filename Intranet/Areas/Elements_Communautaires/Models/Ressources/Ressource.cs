using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Intranet.Areas.Elements_Generaux.Models.Medias;
using Intranet.Areas.Elements_Generaux.Models;
using Intranet.Areas.Elements_Communautaires.Models.Medias;
using System.Web.Mvc;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace Intranet.Areas.Elements_Communautaires.Models.Ressources
{
    public class Ressource : Element_Communautaire_Objet
    {
        public Ressource()
        {
            this.ListeMediasAssocies = new HashSet<Media>();
        }
    }
}