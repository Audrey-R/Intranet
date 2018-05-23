using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.Models
{
    public class DalComposantCommunautaire : IDalComposantCommunautaire
    {
        private BddContext bdd;

        public DalComposantCommunautaire()
        {
            bdd = new BddContext();
        }

        public void CreerComposantCommunautaire(string libelle)
        {
            bdd.Composants_Communautaires.Add(new Composant_Communautaire { Libelle = libelle });
            bdd.SaveChanges();
        }

        public void ModifierComposantCommunautaire(int id, string libelle)
        {
            Composant_Communautaire composantTrouve = bdd.Composants_Communautaires.FirstOrDefault(composant => composant.Id == id);
            if (composantTrouve != null)
            {
                composantTrouve.Libelle = libelle;
                bdd.SaveChanges();
            }
        }

        public void SupprimerComposantCommunautaire(int id)
        {
            Composant_Communautaire composantTrouve = bdd.Composants_Communautaires.FirstOrDefault(composant => composant.Id == id);
            if (composantTrouve != null)
            {
                bdd.Composants_Communautaires.Remove(composantTrouve);
                bdd.SaveChanges();
            }
        }

        public List<Composant_Communautaire> ObtientTousLesComposantsCommunautaires()
        {
            return bdd.Composants_Communautaires.ToList();
        }



        public void Dispose()
        {
            bdd.Dispose();
        }

        
    }
}