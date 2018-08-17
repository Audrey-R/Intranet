using System;
using System.Collections.Generic;
using Intranet.Areas.Composants.Models;
using Intranet.Areas.Elements_Communautaires.ViewModels;

namespace Intranet.Areas.Elements_Communautaires.Models.Dal
{
    public interface IDal_Element_Communautaire_Objet : IDisposable
    {
        IEnumerable<Entity> Lister<Entity>(Entity table) where Entity : Element_Communautaire_Objet;
        void Creer<ViewModel>(ViewModel elementACreer, Element_Communautaire_Objet entite) where ViewModel : Element_Communautaire_ViewModel;
        void Modifier<ViewModel>(ViewModel elementAModifier, Element_Communautaire_Objet entite) where ViewModel : Element_Communautaire_ViewModel;
        void Masquer(Element_Communautaire_Objet element);
        void Supprimer(Element_Communautaire_Objet element);
        Entite RetournerElementCommunautaireTrouve<Entite>(Entite element, int? id) where Entite : Element_Communautaire_Objet;
        Element RetournerElementLie(int? id);
    }
}
