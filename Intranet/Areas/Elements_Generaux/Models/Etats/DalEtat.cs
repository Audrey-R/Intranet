using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Intranet.Areas.Composants.Models.BDD;
using Intranet.Areas.Elements_Generaux.Models.Fractions;
using Intranet.Models;

namespace Intranet.Areas.Elements_Generaux.Models.Etats
{
    public class DalEtat : IDalElement_General
    {
        private BddContext bdd;

        public DalEtat()
        {
            bdd = new BddContext();
        }


        public void Creer(string libelle)
        {
            // Recherche de la fraction "Catégorie"
            Fraction fraction = bdd.Fractions.FirstOrDefault(fractionEtatTrouvee => fractionEtatTrouvee.Libelle.Contains("Etat"));

            // Création de l'élément de type Catégorie
            Element_General element = bdd.ElementsGeneraux.Add(new Element_General());

            //List<Categorie> listeCategories = new List<Categorie>();

            if (fraction == null)
            {
                // Création de la fraction "Catégorie"
                fraction = bdd.Fractions.Add(new Fraction { Libelle = "Etat", Element = element });
                bdd.SaveChanges();
            }
            
            //if (fraction != null)
            //{
                //    List<Categorie> CategoriesExistantes = element.Categories ;
                //    List<Categorie> listeCategories = new List<Categorie>();
                //Categorie categorie = 
                bdd.Etats.Add(new Etat { Libelle = libelle, Element = element });
                //    listeCategories.Add(categorie);

                //    if (CategoriesExistantes == null)
                //    {
                //        element.Categories = listeCategories;
                //    }
                //    else
                //    {
                //        element.Categories.AddRange(listeCategories);
                //    }
                bdd.SaveChanges();
           // }
        }

        public void Dispose()
        {
            bdd.Dispose();
        }

        public IEnumerable<Element_General_Objet> Lister()
        {
            return bdd.Etats.ToList();
        }

       

        public void Masquer(int id)
        {
            throw new NotImplementedException();
        }

        public void Modifier(int id, string libelle)
        {
            throw new NotImplementedException();
        }

        public void Supprimer(int id)
        {
            throw new NotImplementedException();
        }
        
    }
}