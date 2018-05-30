using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Intranet.Areas.Composants.Models.BDD;
using Intranet.Areas.Composants.Models.Elements;
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
            Fraction fraction = bdd.Fractions.Add(new Fraction { Libelle = libelle });
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