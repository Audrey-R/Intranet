using Intranet.Areas.Elements_Generaux.Models.Ressources;
using Intranet.Areas.Elements_Generaux.Models;
using Intranet.Areas.Elements_Communautaires.Models.Ressources;

namespace Intranet.Areas.Elements_Communautaires.Models.Medias
{
    public class Media : Element_Communautaire_Objet
    {
        public string Chemin { get; set; }
        //public virtual Element Element { get; set; }
        public virtual Ressource Ressource { get; set; }
    }
}