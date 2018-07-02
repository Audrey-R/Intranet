using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Intranet.Areas.Composants.Models.BDD;
using Intranet.Areas.Composants.Models.Elements;
using Intranet.Areas.Elements_Generaux;
using Intranet.Areas.Elements_Generaux.Models;

namespace Intranet.Areas.Elements_Generaux.Models
{
    public interface IDal_Element_General_Objet : IDisposable
    {
        IEnumerable<Entity> Lister<Entity>(Entity table) where Entity : Element_General_Objet;
        void Creer(Element_General_Objet elementACreer);
        void Modifier(Element_General_Objet element);
        void Masquer(Element_General_Objet element);
        void Supprimer(Element_General_Objet element);
        Entite RetournerElementGeneralTrouve<Entite>(Entite element, int? id) where Entite : Element_General_Objet;
        Element RetournerElementLie(int? id);
    }
}