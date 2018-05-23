using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.Models
{
    public interface IDalComposantCommunautaire : IDisposable
    {
        void CreerComposantCommunautaire(string libelle);
        void ModifierComposantCommunautaire(int id, string libelle);
        void SupprimerComposantCommunautaire(int id);
        List<Composant_Communautaire> ObtientTousLesComposantsCommunautaires();
    }
}