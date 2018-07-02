using Intranet.Areas.Elements_Communautaires.Models.Ressources;
using Intranet.Areas.Elements_Generaux.Models;

namespace Intranet.Areas.Elements_Communautaires.Models.Medias
{
    public class Media : Element_Communautaire_Objet,IElement_Communautaire
    {
        //public int Id { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }
        public string Chemin { get; set; }
        //public virtual Element Element { get; set; }
        public virtual Ressource Ressource { get; set; }
    }
}