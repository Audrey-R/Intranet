using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Intranet.Areas.Elements_Communautaires.Models;
using Intranet.Areas.Elements_Generaux.Models;
using Intranet.Areas.Elements_Communautaires.ViewModels.Afficher;
using Intranet.Areas.Elements_Communautaires.ViewModels;

namespace Intranet.Areas.Elements_Communautaires.Controllers.Dal
{
    public interface IDal_Element_Communautaire_Objet_Controller : IDisposable
    {
        ActionResult Afficher<Entite>(Entite element) where Entite : Element_Communautaire_Objet;
        //ActionResult Creer<Entite>(string element, Entite entite) where Entite : Element_Communautaire_Objet;
        //ActionResult Creer<Entite>(Entite element) where Entite : Element_Communautaire_Objet;
        //ActionResult Creer<Entite>([Bind(Include = "Id,TitreRessource,Element")] Entite elementACreer) where Entite : Element_Communautaire_Objet;
        ActionResult Creer<ViewModel>(ViewModel element) where ViewModel : Element_Communautaire_ViewModel;
        ActionResult Creer<ViewModel>(ViewModel element, Element_Communautaire_Objet entite) where ViewModel : Element_Communautaire_ViewModel;
        ActionResult Detailler<Entite>(Entite element, int? id) where Entite : Element_Communautaire_Objet;
        ActionResult Modifier<ViewModel>(ViewModel model) where ViewModel : Element_Communautaire_ViewModel;
        //ActionResult Modifier<Entite>(Entite element, int? id) where Entite : Element_Communautaire_Objet;
        //ActionResult Modifier<Entite>([Bind(Include = "Id,Libelle,Element")] Entite elementAModifier) where Entite : Element_Communautaire_Objet;
        ActionResult Masquer<Entite>(Entite element, int? id) where Entite : Element_Communautaire_Objet;
        ActionResult Masquer<Entite>([Bind(Include = "Id,Libelle,Element")] Entite elementAMasquer) where Entite : Element_Communautaire_Objet;
        ActionResult Supprimer<Entite>(Entite element, int? id) where Entite : Element_Communautaire_Objet;
        ActionResult Supprimer<Entite>([Bind(Include = "Id,Libelle,Element")] Entite elementASupprimer) where Entite : Element_Communautaire_Objet;
        //IEnumerable<SelectListItem> ListeThemes();
        //IEnumerable<SelectListItem> ListeCategories();
    }
}
