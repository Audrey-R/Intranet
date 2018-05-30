using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Intranet.Areas.Composants.Models.BDD;
using Intranet.Areas.Composants.Models.Elements;
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
            Fraction fractionComposantGeneralTrouvee = bdd.Fractions.FirstOrDefault(fraction => fraction.Libelle.Contains(libelle));
            // Création de l'élément de type Catégorie, puis de la catégorie
            if (fractionComposantGeneralTrouvee != null)
            {
                Element_General element = bdd.ComposantsGeneraux.Add(new Element_General { Fraction_Element = fractionComposantGeneralTrouvee });
                bdd.Categories.Add(new Categorie { Libelle = libelle,  ElementGeneral = element });
                bdd.SaveChanges();
            }
            else
            {
                Fraction fraction = bdd.Fractions.Add(new Fraction { Libelle = libelle });
                bdd.SaveChanges();
                Element_General element = bdd.ComposantsGeneraux.Add(new Element_General { Fraction_Element = fractionComposantGeneralTrouvee });
                bdd.Categories.Add(new Categorie { Libelle = libelle, ElementGeneral = element });
                bdd.SaveChanges();
            }
        }

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

        public virtual List<Categorie> Lister()
        {
            return bdd.Categories.ToList();
        }

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
    }
}