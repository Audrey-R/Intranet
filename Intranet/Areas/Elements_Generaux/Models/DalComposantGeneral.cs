using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Intranet.Areas.Elements_Generaux.Models;

namespace Intranet.Models
{
    public class DalComposantGeneral : IDalComposantGeneral
    {
        private BddContext bdd;

        public DalComposantGeneral()
        {
            bdd = new BddContext();
        }

        public void CreerFraction(string libelle)
        {
            Element element = bdd.Elements.Add(new Element { ComposantCommunautaire = false, ComposantGeneral = true });
            bdd.Fractions.Add(new Fraction { LibelleFraction = libelle, Element = element });
            bdd.SaveChanges();
        }

        public void ModifierFraction(int id, string libelle)
        {
            Fraction fractionTrouvee = bdd.Fractions.FirstOrDefault(fraction => fraction.Element.Id == id);
            if (fractionTrouvee != null)
            {
                fractionTrouvee.LibelleFraction = libelle;
                bdd.SaveChanges();
            }
        }

        public void SupprimerFraction(int id)
        {
            Fraction fractionTrouvee = bdd.Fractions.FirstOrDefault(fraction => fraction.Element.Id == id);
            if (fractionTrouvee != null)
            {
                bdd.Fractions.Remove(fractionTrouvee);
                bdd.SaveChanges();
            }
        }

        public List<Fraction> ListerToutesLesFractions()
        {
            return bdd.Fractions.ToList();
        }



        public void Dispose()
        {
            bdd.Dispose();
        }

        
    }
}