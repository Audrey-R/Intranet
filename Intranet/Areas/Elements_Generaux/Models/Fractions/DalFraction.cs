using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Intranet.Areas.Composants.Models.BDD;
using Intranet.Areas.Composants.Models.Elements;
using Intranet.Areas.Composants.Models.Operations;
using Intranet.Areas.Elements_Generaux.Models;
using Intranet.Areas.Elements_Generaux.Models.Categories;
using Intranet.Models;
using System.Data.Entity;

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
            Fraction fractionFraction = bdd.Fractions.FirstOrDefault(f => f.Libelle.Contains("Fraction"));

            // Création de l'élément de type Fraction, puis de la fraction
            Element_General element = bdd.ElementsGeneraux.Add(new Element_General());
            // bdd.SaveChanges();
            
            if (fractionFraction == null)
            {
                // Création de l'élément de type Fraction
                Element_General elementFraction = bdd.ElementsGeneraux.Add(new Element_General());
                // Création de la fraction "Fraction"
                fractionFraction = bdd.Fractions.Add(new Fraction { Libelle = "Fraction", Element = elementFraction });
                bdd.Operations.Add(new Operation { Element = elementFraction, Type_Operation = Operation.Operations.Création });
                bdd.SaveChanges();
            }

            //Association de la fraction à l'élément et création de la fraction si ce n'est pas la fraction "Fraction"
            element.Fraction = fractionFraction;
            if (fractionFraction.Libelle != libelle)
            {
                Fraction fraction = bdd.Fractions.Add(new Fraction { Libelle = libelle, Element = element });
                bdd.Operations.Add(new Operation { Element = element, Type_Operation = Operation.Operations.Création });
            }
            bdd.SaveChanges();
        }

        public void Modifier(Element_General_Objet element)
        {
            //Fraction fractionTrouvee = bdd.Fractions.FirstOrDefault(f => f.Element.Id == id);
            //if (fractionTrouvee != null && fractionTrouvee.Libelle != nouveauLibelle)
            //{
            //    fractionTrouvee.Libelle = nouveauLibelle;
            //    bdd.SaveChanges();
            //}
        }

        public void Supprimer(int id)
        {
            Fraction fractionASupprimer = bdd.Fractions.Include(f => f.Element).FirstOrDefault(f => f.Element.Id == id);

            //Suppression de la contrainte Fraction liée à l'élément créé pour la catégorie
            Element elementASupprimer = bdd.Elements.FirstOrDefault(e => e.Id == id);
            Fraction fractionElementAOter = elementASupprimer.Fraction;
            fractionElementAOter = null;

            Element elementFractionAOter = fractionASupprimer.Element;
            elementFractionAOter = null;

            if (fractionASupprimer != null && elementFractionAOter == null && fractionElementAOter == null)
            {
                bdd.Fractions.Remove(fractionASupprimer);
                bdd.Elements.Remove(elementASupprimer);
                bdd.SaveChanges();
            }
        }

        public IEnumerable<Element_General_Objet> Lister()
        {
            return bdd.Fractions.Include(f => f.Element).ToList();
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

        public Element ExtraireElement(Element_General_Objet element)
        {
            throw new NotImplementedException();
        }
    }
}