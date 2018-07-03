using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Intranet.Areas.Elements_Generaux.Models;

namespace Intranet.Areas.Elements_Generaux.Controllers
{
    interface IDal_Element_General_Objet_Controller : IDisposable
    {
        ActionResult Afficher<Entite>(Entite element) where Entite : Element_General_Objet;
        ActionResult Creer(string element);
        ActionResult Creer<Entite>([Bind(Include = "Id,Libelle,Element")] Entite elementACreer) where Entite : Element_General_Objet;
        ActionResult Detailler<Entite>(Entite element, int? id) where Entite : Element_General_Objet;
        ActionResult Modifier<Entite>(Entite element, int? id) where Entite : Element_General_Objet;
        ActionResult Modifier<Entite>([Bind(Include = "Id,Libelle,Element")] Entite elementAModifier) where Entite : Element_General_Objet;
        ActionResult Masquer<Entite>(Entite element, int? id) where Entite : Element_General_Objet;
        ActionResult Masquer<Entite>([Bind(Include = "Id,Libelle,Element")] Entite elementAMasquer) where Entite : Element_General_Objet;
        ActionResult Supprimer<Entite>(Entite element, int? id) where Entite : Element_General_Objet;
        ActionResult Supprimer<Entite>([Bind(Include = "Id,Libelle,Element")] Entite elementASupprimer) where Entite : Element_General_Objet;
    }
}
