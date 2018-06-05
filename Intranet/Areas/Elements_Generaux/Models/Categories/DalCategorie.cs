using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Intranet.Areas.Composants.Models.BDD;
using Intranet.Areas.Composants.Models.Elements;
using Intranet.Areas.Elements_Generaux.Models.Fractions;
using Intranet.Models;

namespace Intranet.Areas.Elements_Generaux.Models.Categories
{
    public class DalCategorie : IDalElement_General
    {
        private BddContext bdd;

        public DalCategorie()
        {
            bdd = new BddContext();
        }

        public void Creer(string libelle)
        {
            // Recherche de la fraction "Catégorie"
            Fraction rechercheCategorieDansFractions = bdd.Fractions.FirstOrDefault(fraction => fraction.Libelle.Contains("Catégorie"));

            // Création de l'élément de type Catégorie
            Element_General element = bdd.ElementsGeneraux.Add(new Element_General());
            
            //List<Categorie> listeCategories = new List<Categorie>();

            if (rechercheCategorieDansFractions == null)
            {
                // Création de la fraction "Catégorie"
                Fraction fraction = bdd.Fractions.Add(new Fraction { Libelle = "Catégorie", Element = element });
                bdd.SaveChanges();
            }

            // Nouvelle recherche de la fraction "Catégorie"
            Fraction fractionCategorieTrouvee = bdd.Fractions.FirstOrDefault(fraction => fraction.Libelle.Contains("Catégorie"));

            if (fractionCategorieTrouvee != null)
            {
                //    List<Categorie> CategoriesExistantes = element.Categories ;
                //    List<Categorie> listeCategories = new List<Categorie>();
                //Categorie categorie = 
                bdd.Categories.Add(new Categorie { Libelle = libelle, Element = element });
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
            }

        }

        //public Element_General RetournerElementGeneral(int id)
        //{
        //    Element_General elementTrouvee = bdd.ElementsGeneraux.FirstOrDefault(element => element.Id == id);
        //    if (elementTrouvee != null)
        //    {
        //        return elementTrouvee;
        //    }
        //    return null;
        //}

        public void Modifier(int id, string libelle)
        {
            Categorie categorieTrouvee = bdd.Categories.FirstOrDefault(categorie => categorie.Id == id);
            if (categorieTrouvee != null)
            {
                categorieTrouvee.Libelle = libelle;
                bdd.SaveChanges();
            }
        }

        public void Supprimer(int id)
        {
            Categorie categorieTrouvee = bdd.Categories.FirstOrDefault(categorie => categorie.Id == id);
            if (categorieTrouvee != null)
            {
                bdd.Categories.Remove(categorieTrouvee);
                bdd.SaveChanges();
            }
        }

        public virtual IEnumerable<Element_General_Objet> Lister()
        {
            return bdd.Categories.ToList();
        }

        //public virtual IEnumerable<Element_General> Lister(IEnumerable<Element_General> categories)
        //{
        //    List<Categorie> ListeCategories = new List<Categorie>();
        //    foreach(Categorie categorie in categories)
        //    {
        //        ListeCategories.AddRange(categorie.ListeCategories);
        //    }
        //    return ListeCategories;
        //}

        public void Dispose()
        {
            bdd.Dispose();
        }

        public void ModifierFraction(string libelle)
        {
            throw new NotImplementedException();
        }

        public void Masquer(int id)
        {
            throw new NotImplementedException();
        }

        public Element_General_Objet Obtenir(string libelle)
        {
            throw new NotImplementedException();
        }
    }
}