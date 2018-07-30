using System;
using System.Collections.Generic;
using System.Linq;
using Intranet.Areas.Composants.Models.BDD;
using Intranet.Areas.Elements_Generaux.Models;
using System.Data.Entity;
using Intranet.Areas.Composants.Models.Operations;
using System.Data.Entity.Infrastructure;
using Intranet.Areas.Elements_Communautaires.Models;

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

        public List<Operation> ListerTousLesElementsAvecLogParEtat(EntityState etat)
        {
            List<DbEntityEntry> listEntities = bdd.ChangeTracker.Entries()
                   .Where(p => p.State == EntityState.Modified || p.State == EntityState.Deleted || p.State == EntityState.Added)
                   .ToList();

            List<Operation> logs = new List<Operation>();

            foreach (DbEntityEntry entry in listEntities)
            {
                string entityName = entry.Entity.GetType().Name;
                Object primaryKey = bdd.GetPrimaryKeyValue(entry);

                Operation log = bdd.Operations.Add(new Operation
                {
                    Id = Convert.ToInt32(entry.CurrentValues["Id"]),
                    Element = (Element)entry.CurrentValues["Element"]
                    //Propriete = entry.CurrentValues["Propriete"].ToString(),
                    //AncienneValeur = entry.CurrentValues["AncienneValeur"].ToString(),
                    //NouvelleValeur = entry.CurrentValues["NouvelleValeur"].ToString(),
                    //DateLog = Convert.ToDateTime(entry.CurrentValues["DateLog"].ToString())
                });

                if (etat == EntityState.Added && entry.State == EntityState.Added)
                {
                    logs.Add(log);
                }
                else if (etat == EntityState.Modified && entry.State == EntityState.Modified)
                {
                    logs.Add(log);
                }
                else if (etat == EntityState.Deleted && entry.State == EntityState.Deleted)
                {
                    logs.Add(log);
                }
            }
            return logs;
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
            DbEntityEntry<Element> entryElement = bdd.Entry(elementASupprimer);

            Fraction fractionElementAOter = elementASupprimer.Fraction;
            fractionElementAOter = null;
            
            if (fractionASupprimer != null)
            {
                Element elementFractionAOter = fractionASupprimer.Element;
                elementFractionAOter = null;
                if (elementFractionAOter == null && fractionElementAOter == null)
                {
                    bdd.Fractions.Remove(fractionASupprimer);
                    bdd.Elements.Remove(elementASupprimer);
                }
            }
            else
            {
                bdd.Elements.Remove(elementASupprimer);
            }
            entryElement.State = EntityState.Deleted;
            bdd.SaveChanges();
        }

        public void Dispose()
        {
            bdd.Dispose();
        }
    }
}