using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Intranet.Areas.Composants.Models.BDD;
using Intranet.Areas.Elements_Generaux.Models.Fractions;
using Intranet.Models;

namespace Intranet.Areas.Elements_Generaux.Models.Themes
{
    public class DalTheme : IDalElement_General
    {
        private BddContext bdd;

        public DalTheme()
        {
            bdd = new BddContext();
        }


        public void Creer(string libelle)
        {
            // Recherche de la fraction "Thème"
            Fraction fraction = bdd.Fractions.FirstOrDefault(fractionEtatTrouvee => fractionEtatTrouvee.Libelle.Contains("Thème"));

            // Création de l'élément de type Catégorie
            Element_General element = bdd.ElementsGeneraux.Add(new Element_General());

            //List<Categorie> listeCategories = new List<Categorie>();

            if (fraction == null)
            {
                // Création de la fraction "Catégorie"
                fraction = bdd.Fractions.Add(new Fraction { Libelle = "Thème", Element = element });
                bdd.SaveChanges();
            }
             
            bdd.Themes.Add(new Theme { Libelle = libelle, Element = element });
            bdd.SaveChanges();
        }

        public void Dispose()
        {
            bdd.Dispose();
        }

        public IEnumerable<Element_General_Objet> Lister()
        {
            return bdd.Themes.ToList();
        }

       

        public void Masquer(int id)
        {
            throw new NotImplementedException();
        }

        public void Modifier(int id, string libelle)
        {
            throw new NotImplementedException();
        }

        public Element_General_Objet Obtenir(string libelle)
        {
            Theme themeTrouve = bdd.Themes.FirstOrDefault(theme => theme.Libelle == libelle);
            return themeTrouve;
        }

        public void Supprimer(int id)
        {
            throw new NotImplementedException();
        }
        
    }
}