using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Intranet.Areas.Composants.Models.BDD;
using Intranet.Areas.Composants.Models.Collaborateurs;
using Intranet.Areas.Elements_Generaux.Models;
using Intranet.Areas.Elements_Generaux.Models.Categories;
using Intranet.Areas.Elements_Generaux.Models.Fractions;
using Intranet.Models;
using System.Data.Entity;
using Intranet.Areas.Composants.Models.Operations;
using System.Data.Entity.Infrastructure;

namespace Intranet.Areas.Composants.Models.Elements
{
    public class DalElement
    {
        private BddContext bdd;

        public DalElement()
        {
            bdd = new BddContext();
        }
        
        public List<Element> ListerTousLesElements()
        {
            return bdd.Elements.Include(e => e.Fraction).ToList();
        }

        public List<Element> ListerTousLesElementsCommunautaires()
        {
            return bdd.Elements.Include(e => e.Fraction).Where(e => (e is Element_Communautaire)).ToList();
        }

        public List<Element> ListerTousLesElementsGeneraux()
        {
            return bdd.Elements.Include(e=> e.Fraction).Where(e => (e is Element_General)).ToList();
        }

        public List<Element> ListerTousLesElements(int? id)
        {
            return bdd.Elements.Include(e => e.Fraction).Where(e => (e.Fraction.Element.Id == id)).ToList();
        }

        public List<Log> ListerTousLesElementsAvecLog()
        {
            //List<DbEntityEntry> modifiedChanges = bdd.ChangeTracker.Entries().Where(x => x.State == EntityState.Modified).ToList();
            return bdd.Logs.ToList(); ;
        }

        public List<Operation> Details(int? id)
        {
            return bdd.Operations.Include(o=> o.Element).Where(o => (o.Element.Id == id)).ToList();
        }

        public void Masquer(int id)
        {
            throw new NotImplementedException();
        }

        public void Modifier(bool elementCommunautaire, bool elementGeneral)
        {
            throw new NotImplementedException();
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

        public void Dispose()
        {
            bdd.Dispose();
        }
    }
}