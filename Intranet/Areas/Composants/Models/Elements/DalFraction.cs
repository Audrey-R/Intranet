using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Intranet.Areas.Composants.Models.BDD;
using Intranet.Areas.Composants.Models.Elements;
using Intranet.Areas.Elements_Generaux.Models;
using Intranet.Areas.Elements_Generaux.Models.Categories;
using Intranet.Models;

namespace Intranet.Areas.Composants.Models.Elements
{
    public class DalFraction 
    {
        private BddContext bdd;

        public DalFraction()
        {
            bdd = new BddContext();
        }

        public void Creer(string libelle)
        {
            // Recherche de la fraction "Fraction"
            //Fraction rechercheFractionDansFractions = bdd.Fractions.FirstOrDefault(fractionTrouvee => fractionTrouvee.Libelle.Contains("Fraction"));

            // Création de l'élément de type Fraction, puis de la fraction
            Element_General element = bdd.ElementsGeneraux.Add(new Element_General());
            // bdd.SaveChanges();
            Fraction fraction = bdd.Fractions.Add(new Fraction { Libelle = libelle, Element = element });
            

            ////List<Categorie> listeCategories = new List<Categorie>();

            //if (rechercheFractionDansFractions == null)
            //{
            //    // Création de la fraction "Fraction"
            //    bdd.Fractions.Add(new Fraction { Libelle = "Fraction", ElementGeneral = element });
            //    bdd.SaveChanges();
            //}

            //// Nouvelle recherche de la fraction "Fraction"
            //Fraction fractionFractionTrouvee = bdd.Fractions.FirstOrDefault(fractionTrouvee => fractionTrouvee.Libelle.Contains("Fraction"));

            //if (rechercheFractionDansFractions != null || fractionFractionTrouvee != null)
            //{
            //    List<Fraction> FractionsExistantes = element.Fractions;
            //    List<Fraction> listeFractions = new List<Fraction>();
            //    Fraction nouvelleFraction = new Fraction { Libelle = libelle, ElementGeneral = element };
            //    listeFractions.Add(nouvelleFraction);

            //    if (FractionsExistantes == null)
            //    {
            //        element.Fractions = listeFractions;
            //    }
            //    else
            //    {
            //        element.Fractions.AddRange(listeFractions);
            //    }

            //}

            //Fraction fraction = bdd.Fractions.Add(new Fraction());
            bdd.SaveChanges();
        }

        public void Modifier(int id, string libelle)
        {
            Fraction fractionTrouvee = bdd.Fractions.FirstOrDefault(fraction => fraction.Id == id);
            if (fractionTrouvee != null)
            {
                fractionTrouvee.Libelle = libelle;
                bdd.SaveChanges();
            }
        }

        public void Supprimer(int id)
        {
            Fraction fractionTrouvee = bdd.Fractions.FirstOrDefault(fraction => fraction.Id == id);
            if (fractionTrouvee != null)
            {
                bdd.Fractions.Remove(fractionTrouvee);
                bdd.SaveChanges();
            }
        }

        public List<Fraction> Lister()
        {
            return bdd.Fractions.ToList();
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