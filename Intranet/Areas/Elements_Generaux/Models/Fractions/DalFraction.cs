using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Intranet.Areas.Composants.Models.BDD;
using Intranet.Areas.Composants.Models.Elements;
using Intranet.Models;

namespace Intranet.Areas.Elements_Generaux.Models.Fractions
{
    public class DalFraction : IDalComposantGeneral
    {
        private BddContext bdd;

        public DalFraction()
        {
            bdd = new BddContext();
        }

        public void Creer(string libelle)
        {
            Element element = bdd.Elements.Add(new Element { ElementCommunautaire = false, ElementGeneral = true });
            bdd.Fractions.Add(new Fraction { Libelle = libelle, Element = element });
            bdd.SaveChanges();
        }

        public void Modifier(int id, string libelle)
        {
            Fraction fractionTrouvee = bdd.Fractions.FirstOrDefault(fraction => fraction.Element.Id == id);
            if (fractionTrouvee != null)
            {
                fractionTrouvee.Libelle = libelle;
                bdd.SaveChanges();
            }
        }

        public void Supprimer(int id)
        {
            Fraction fractionTrouvee = bdd.Fractions.FirstOrDefault(fraction => fraction.Element.Id == id);
            if (fractionTrouvee != null)
            {
                bdd.Fractions.Remove(fractionTrouvee);
                bdd.SaveChanges();
            }
        }

        public IEnumerable<Composant_General> Lister()
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