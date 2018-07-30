using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Intranet.Areas.Composants.Models.BDD;
using Intranet.Areas.Composants.Models.Elements;
using Intranet.Areas.Composants.Models.Operations;
using Intranet.Areas.Elements_Communautaires.Models.Ressources;
using Intranet.Areas.Elements_Generaux.Models.Ressources;

namespace Intranet.Areas.Elements_Generaux.Models
{
    public class Dal_Element_General_Objet : IDal_Element_General_Objet
    {
        private BddContext Bdd {get; set;}
        
        public Dal_Element_General_Objet()
        {
            Bdd = new BddContext();
        }

        public BddContext RetournerBdd()
        {
            return Bdd;
        }

        public virtual IEnumerable<Entity> Lister<Entity>(Entity table)
            where Entity : Element_General_Objet
        {
            try
            {
                return Bdd.Set<Entity>()
                    .Include(c => c.Element)
                    .Where(c => c.Element.Etat != Element.Etats.Masqué)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void AjouterLog(Element_General_Objet element)
        {
            try
            {
                Bdd.Logs.Add(new Log
                {
                    Entite = element.GetType().Name,
                    AncienneValeur = string.Empty,
                    NouvelleValeur = element.Libelle,
                    DateLog = DateTime.UtcNow,
                    ClePrimaire = element.Element.Id.ToString(),
                    Operation = "Créé"
                });
            }
            catch (Exception ex)
            {
                Exception message = new Exception("L'enregistrement d'un log a échoué", ex);
                throw message;
            }
            Bdd.SaveChanges();
        }

        public virtual void Creer(Element_General_Objet elementGeneralObjet)
        {
            try
            {
                //Création d'une instance de l'élément à créer (type dynamique)
                dynamic instanceElementACreer = Activator.CreateInstance(elementGeneralObjet.GetType());
                instanceElementACreer.GetType().GetProperty("Libelle").SetValue(instanceElementACreer, elementGeneralObjet.Libelle, null);

                // Recherche de la fraction concernée par l'élément à créer 
                string libelleFractionElementACreer = instanceElementACreer.GetType().Name;
                Fraction fractionElementGeneral = Bdd.Fractions.FirstOrDefault(f => f.Libelle.Contains(libelleFractionElementACreer));

                if (fractionElementGeneral == null)
                {
                    // Création de l'élément de type Fraction
                    Element_General elementFraction = Bdd.ElementsGeneraux.Add(new Element_General());
                    elementFraction.Fraction = null;

                    // Création de la fraction de l'élément à créer si elle n'existe pas
                    Fraction fractionACreer = Bdd.Fractions.Add(new Fraction { Libelle = libelleFractionElementACreer, Element = elementFraction });
                    fractionElementGeneral = fractionACreer;

                    Bdd.SaveChanges();
                    // Enregistrement du log de création de la fraction
                    if (fractionACreer != null)
                        AjouterLog(fractionACreer);
                }
                // Création de l'élément général auquel sera liée le futur élément créée
                Element_General element = Bdd.ElementsGeneraux.Add(new Element_General());
                element.Fraction = fractionElementGeneral;
                instanceElementACreer.GetType().GetProperty("Element").SetValue(instanceElementACreer, element, null);


                //Enregistrement de l'élément créé dans la BDD
                DbSet tableElementACreerEnBdd = Bdd.Set(instanceElementACreer.GetType());
                tableElementACreerEnBdd.Add(instanceElementACreer);
                Bdd.SaveChanges();

                // Enregistrement du log de création de l'élément
                if (instanceElementACreer != null)
                    AjouterLog((Element_General_Objet)instanceElementACreer);
            }
            catch (Exception ex)
            {
                Exception message = new Exception("L'enregistrement de la nouvelle catégorie a échouée", ex);
                throw message;
            }
        }

        public virtual void Modifier(Element_General_Objet element)
        {
            try
            {
                //Création d'une instance de l'élément à comparer (type dynamique)
                dynamic instanceElementAComparer = Activator.CreateInstance(element.GetType());
                dynamic elementAModifier = RetournerElementGeneralTrouve(instanceElementAComparer, element.Id);
                
                if (elementAModifier != null)
                {
                    //Récupération du tuple de l'élément visé dans sa table
                    dynamic tupleElement = RetournerTupleElement(elementAModifier);
                    //Traitement uniquement si le libellé a changé
                    if (tupleElement.Property("Libelle").CurrentValue != element.Libelle)
                    {
                        tupleElement.CurrentValues.SetValues(element);
                        //Récupération du tuple de l'élément lié dans sa table
                        dynamic tupleElementLieElement = RetournerTupleElementLieElement(elementAModifier.Element);
                        //Modification des états trackés dans la sauvegarde de données, pour chaque tuple
                        tupleElement.State = EntityState.Modified;
                        tupleElementLieElement.State = EntityState.Modified;

                        Bdd.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Exception message = new Exception("La modification de la catégorie a échouée", ex);
                throw message;
            }
        }

        //protected Element ExtraireElement(Element_General_Objet element)
        //{
        //    return element.Element;
        //}

        public virtual void Supprimer(Element_General_Objet element)
        {
            try
            {
                //Création d'une instance de l'élément général objet à supprimer (type dynamique)
                dynamic instanceElementAComparer = Activator.CreateInstance(element.GetType());
                //Recherche de l'élément général objet
                dynamic instanceElementASupprimer= RetournerElementGeneralTrouve(instanceElementAComparer, element.Id);

                //Suppression de la contrainte Fraction liée à l'élément créé pour l'élément général objet
                Element elementLieASupprimer = Bdd.Elements.FirstOrDefault(e => e.Id == element.Id);
                if (elementLieASupprimer != null)
                {
                    Fraction fractionElementAOter = elementLieASupprimer.Fraction;
                    fractionElementAOter = null;
                }
                //Suppression de la contrainte Element liée à l'élément général objet
                if (instanceElementASupprimer != null)
                {
                    Element ElementCategorieAOter = instanceElementASupprimer.Element;
                    ElementCategorieAOter = null;
                }

                //Recherche d'une ressource éventuellement liée à cet élément général objet
                int idElementASupprimer = instanceElementASupprimer.Element.Id;
                Ressource ressourceTrouvee = Bdd.Ressources.Include(r => r.Element).FirstOrDefault(r => r.Categorie.Element.Id == idElementASupprimer);

                //Traitement
                if (instanceElementAComparer != null && ressourceTrouvee == null)
                {
                    DbSet tableElementASupprimerEnBdd = Bdd.Set(instanceElementASupprimer.GetType());
                    tableElementASupprimerEnBdd.Remove(instanceElementASupprimer);
                    Bdd.Elements.Remove(elementLieASupprimer);
                    Bdd.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Exception message = new Exception("La suppression de la catégorie a échouée", ex);
                throw message;
            }
        }
        
        public virtual void Masquer(Element_General_Objet element)
        {
            try
            {
                //Création d'une instance de l'élément général objet à masquer (type dynamique)
                dynamic instanceElementAComparer = Activator.CreateInstance(element.GetType());
                //Recherche de l'élément général objet
                dynamic instanceElementAMasquer = RetournerElementGeneralTrouve(instanceElementAComparer, element.Id);
                ////Recherche de l'élément lié
                Element elementLieAMasquer = Bdd.Elements.FirstOrDefault(e => e.Id == element.Id);
                //Recherche d'une ressource éventuellement liée à cet élément général objet
                int idElementAMasquer = instanceElementAMasquer.Element.Id;
                Ressource ressourceTrouvee = Bdd.Ressources.Include(r => r.Element).FirstOrDefault(r => r.Categorie.Element.Id == idElementAMasquer);

                //Traitement
                if (instanceElementAComparer != null && ressourceTrouvee == null)
                {
                    elementLieAMasquer.Etat = Element.Etats.Masqué;
                    Bdd.SaveChanges();
                    if (elementLieAMasquer.Etat == Element.Etats.Masqué)
                    {
                        DbEntityEntry<Element> entryElement = Bdd.Entry(elementLieAMasquer);
                        entryElement.State = EntityState.Deleted;
                    }
                }
            }
            catch (Exception ex)
            {
                Exception message = new Exception("Le masquage de la catégorie a échoué", ex);
                throw message;
            }
        }

        //public virtual Element_General_Objet Obtenir(string libelle)
        //{
        //    throw new NotImplementedException();
        //}


        //Element IDal_Element_General_Objet.ExtraireElement(Element_General_Objet element)
        //{
        //    throw new NotImplementedException();
        //}

        //public Entite RetournerEntite<Entite>(Entite entite, string libelle)
        //    where Entite : Element_General_Objet
        //{
        //    return Bdd.Set<Entite>()
        //        .Include(x => x.Element)
        //        .Where(x => x.Libelle == libelle)
        //        .Select(x => x)
        //        .FirstOrDefault();
        //}

        public Entite RetournerElementGeneralTrouve<Entite>(Entite element, int? id)
        where Entite : Element_General_Objet
        {
            if (element != null && id != null)
            {
                return Bdd.Set<Entite>()
                .Include(x => x.Element)
                .Where(x => x.Element.Id == id)
                .Select(x => x)
                .FirstOrDefault();
            }
            return null;
        }

        //public Element RetournerElementLie<Entite>(Entite element)
        //    where Entite : Element_General_Objet
        //{
        //    return Bdd.Set<Entite>()
        //        .Include(x=> x.Element)
        //        .Select(x => x.Element)
        //        .FirstOrDefault();
        //}

        public Element RetournerElementLie(int? id)
        {
            return Bdd.Set<Element>()
                .Where(x => x.Id == id)
                .Select(x => x)
                .FirstOrDefault();
        }

        private DbEntityEntry<Entite> RetournerTupleElement<Entite>(Entite element)
            where Entite : Element_General_Objet
        {
            return Bdd.Entry(element);
        }

        private DbEntityEntry<Entite> RetournerTupleElementLieElement<Entite>(Entite element)
            where Entite : Element
        {
            return Bdd.Entry(element);
        }

        public void Dispose()
        {
            Bdd.Dispose();
        }

    }
}