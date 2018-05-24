using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.Models
{
    public interface IDalComposantGeneral : IDisposable
    {
        void CreerComposantGeneral(string libelle);
        void ModifierComposantGeneral(int id, string libelle);
        void SupprimerComposantGeneral(int id);
        List<Composant_General> ListerTousLesComposantsGeneraux();
    }
}