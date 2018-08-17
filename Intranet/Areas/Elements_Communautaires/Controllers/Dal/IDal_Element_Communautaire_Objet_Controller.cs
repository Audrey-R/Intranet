using System;
using System.Web.Mvc;
using Intranet.Areas.Elements_Communautaires.Models;
using Intranet.Areas.Elements_Communautaires.ViewModels;

namespace Intranet.Areas.Elements_Communautaires.Controllers.Dal
{
    public interface IDal_Element_Communautaire_Objet_Controller : IDisposable
    {
        ActionResult Afficher<Entite>(Entite element) where Entite : Element_Communautaire_Objet;
        ActionResult Creer<ViewModel>(ViewModel element) where ViewModel : Element_Communautaire_ViewModel;
        ActionResult Creer<ViewModel>(ViewModel element, Element_Communautaire_Objet entite) where ViewModel : Element_Communautaire_ViewModel;
        ActionResult Detailler<Entite>(Entite element, int? id) where Entite : Element_Communautaire_Objet;
        ActionResult Modifier<ViewModel>(ViewModel model) where ViewModel : Element_Communautaire_ViewModel;
        ActionResult Modifier<ViewModel>(ViewModel element, Element_Communautaire_Objet entite) where ViewModel : Element_Communautaire_ViewModel;
    }
}
