using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Intranet.Areas.Composants.Models.BDD;
using Intranet.Areas.Composants.Models.Elements;
using Intranet.Areas.Elements_Generaux.Models;
using Intranet.Areas.Elements_Generaux.Models.Categories;
using Intranet.Models;

namespace Intranet.Areas.Elements_Generaux.Models.Fractions
{
    public class DalFraction : IDalElement_General
    {
        private BddContext bdd;

        public DalFraction()
        {
            bdd = new BddContext();
        }

        public void Creer(string libelle)
        {
            // Recherche de la fraction "Fraction"
            Fraction rechercheFractionDansFractions = bdd.Fractions.FirstOrDefault(fractionTrouvee => fractionTrouvee.Libelle.Contains("Fraction"));

            // Création de l'élément de type Fraction, puis de la fraction
            Element_General element = bdd.ElementsGeneraux.Add(new Element_General());
            // bdd.SaveChanges();
            
            if (rechercheFractionDansFractions == null)
            {
                // Création de la fraction "Fraction"
                rechercheFractionDansFractions = bdd.Fractions.Add(new Fraction { Libelle = "Fraction", Element = element });
                bdd.SaveChanges();
            }

            element.Fraction = rechercheFractionDansFractions;
            if (rechercheFractionDansFractions.Libelle != libelle)
            {
                Fraction fraction = bdd.Fractions.Add(new Fraction { Libelle = libelle, Element = element });
            }
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

        public IEnumerable<Element_General_Objet> Lister()
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

        public Element_General_Objet Obtenir(string libelle)
        {
            throw new NotImplementedException();
        }
    }
}