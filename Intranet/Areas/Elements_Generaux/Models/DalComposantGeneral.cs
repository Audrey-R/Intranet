using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.Models
{
    public class DalComposantGeneral : IDalComposantGeneral
    {
        private BddContext bdd;

        public DalComposantGeneral()
        {
            bdd = new BddContext();
        }

        public void CreerComposantGeneral(string libelle)
        {
            bdd.Composants_Generaux.Add(new Composant_General { LibelleComposantGeneral = libelle });
            bdd.SaveChanges();
        }

        public void ModifierComposantGeneral(int id, string libelle)
        {
            Composant_General composantTrouve = bdd.Composants_Generaux.FirstOrDefault(composant => composant.Id == id);
            if (composantTrouve != null)
            {
                composantTrouve.LibelleComposantGeneral = libelle;
                bdd.SaveChanges();
            }
        }

        public void SupprimerComposantGeneral(int id)
        {
            Composant_General composantTrouve = bdd.Composants_Generaux.FirstOrDefault(composant => composant.Id == id);
            if (composantTrouve != null)
            {
                bdd.Composants_Generaux.Remove(composantTrouve);
                bdd.SaveChanges();
            }
        }

        public List<Composant_General> ObtientTousLesComposantsGeneraux()
        {
            return bdd.Composants_Generaux.ToList();
        }



        public void Dispose()
        {
            bdd.Dispose();
        }

        
    }
}