using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intranet.Areas.Composants.Models.Elements;
using Intranet.Areas.Elements_Communautaires.ViewModels;
using Intranet.Areas.Elements_Communautaires.ViewModels.Creer;
using Intranet.Areas.Elements_Generaux.Models;

namespace Intranet.Areas.Elements_Communautaires.Models.Dal
{
    public interface IDal_Element_Communautaire_Objet : IDisposable
    {
        IEnumerable<Entity> Lister<Entity>(Entity table) where Entity : Element_Communautaire_Objet;
        //void Creer(Element_Communautaire_Objet elementACreer);
        void Creer<ViewModel>(ViewModel elementACreer, Element_Communautaire_Objet entite) where ViewModel : Element_Communautaire_ViewModel;
        void Modifier(Element_Communautaire_Objet element);
        void Masquer(Element_Communautaire_Objet element);
        void Supprimer(Element_Communautaire_Objet element);
        Entite RetournerElementCommunautaireTrouve<Entite>(Entite element, int? id) where Entite : Element_Communautaire_Objet;
        Element RetournerElementLie(int? id);
    }
}
