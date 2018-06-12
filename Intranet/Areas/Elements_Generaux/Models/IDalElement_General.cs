using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Intranet.Areas.Composants.Models.Elements;
using Intranet.Areas.Elements_Generaux;
using Intranet.Areas.Elements_Generaux.Models;

namespace Intranet.Areas.Elements_Generaux.Models
{
    public interface IDalElement_General : IDisposable
    {
        void Creer(string libelle);
        void Modifier(int id, string nouveauLibelle);
        void Masquer(int id);
        void Supprimer(int id);
        Element ExtraireElement(Element_General_Objet element);
        Element_General_Objet Obtenir(string libelle);
        IEnumerable <Element_General_Objet> Lister();
    }
}