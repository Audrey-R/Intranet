using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Intranet.Areas.Elements_Generaux.Models;

namespace Intranet.Models
{
    public interface IDalComposantGeneral : IDisposable
    {
        void Creer(string libelle);
        void Modifier(int id, string libelle);
        void Masquer(int id);
        void Supprimer(int id);
        IEnumerable <Composant_General> Lister();
    }
}