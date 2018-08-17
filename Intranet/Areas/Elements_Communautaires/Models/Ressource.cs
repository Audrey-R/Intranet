using System.Collections.Generic;

namespace Intranet.Areas.Elements_Communautaires.Models
{
    public class Ressource : Element_Communautaire_Objet
    {
        public Ressource()
        {
            this.ListeMediasAssocies = new HashSet<Media>();
        }
    }
}