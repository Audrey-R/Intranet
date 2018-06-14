using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Intranet.Areas.Composants.Models.BDD;
using Intranet.Areas.Composants.Models.Elements;
using Intranet.Areas.Elements_Communautaires.Models.Ressources;
using Intranet.Areas.Elements_Generaux.Models.Fractions;
using Intranet.Models;
using System.Data.Entity;

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
            Fraction fractionCategorie = bdd.Fractions.FirstOrDefault(f => f.Libelle.Contains("Catégorie"));

            // Création de l'élément de type Catégorie
            Element_General element = bdd.ElementsGeneraux.Add(new Element_General());

            if (fractionCategorie == null)
            {
                // Création de la fraction "Catégorie" si elle n'existe pas
                Fraction fraction = bdd.Fractions.Add(new Fraction { Libelle = "Catégorie", Element = element });
                bdd.SaveChanges();
            }

            // Nouvelle recherche de la fraction "Catégorie"
            fractionCategorie = bdd.Fractions.FirstOrDefault(fraction => fraction.Libelle.Contains("Catégorie"));

            if (fractionCategorie != null)
            {
                //Association de la fraction "Categorie" à l'élément et Création de la catégorie
                element.Fraction = fractionCategorie;
                bdd.Categories.Add(new Categorie { Libelle = libelle, Element = element });
                bdd.SaveChanges();
            }
        }

        public void Modifier(int id, string nouveauLibelle)
        {
            Categorie categorieTrouvee = bdd.Categories.Include(c => c.Element).FirstOrDefault(c => c.Element.Id == id);
            if (categorieTrouvee != null && categorieTrouvee.Libelle != nouveauLibelle)
            {
                categorieTrouvee.Libelle = nouveauLibelle;
                bdd.SaveChanges();
            }
        }

        public Element ExtraireElement(Element_General_Objet element)
        {
            return element.Element;
        }

        public void Supprimer(int id)
        {
            Categorie categorieASupprimer = bdd.Categories.Include(c => c.Element).FirstOrDefault(c => c.Id == id);
            
            //Suppression de la contrainte Fraction liée à l'élément créé pour la catégorie
            Element elementASupprimer = bdd.Elements.FirstOrDefault(e => e.Id == id);
            Fraction fractionElementAOter = elementASupprimer.Fraction;
            fractionElementAOter = null;

            Fraction fractionASupprimer = bdd.Fractions.FirstOrDefault(f => f.Element.Id == id);


            Element ElementContenantFractionASupprimer = bdd.Elements.FirstOrDefault(e => e.Fraction.Element.Id == id);
            
            //Suppression de la catégorie si elle n'est liee à aucune Ressource, et de son élément lié
            Ressource ressourceTrouvee = bdd.Ressources.Include(r => r.Element).FirstOrDefault(r => r.Categorie.Element.Id == id);
            if (ressourceTrouvee == null)
            {
                bdd.Categories.Remove(categorieASupprimer);

                if (fractionASupprimer == null)
                {
                    bdd.Elements.Remove(elementASupprimer);
                }
                else if (ElementContenantFractionASupprimer == null)
                {
                    bdd.Elements.Remove(elementASupprimer);
                    bdd.Fractions.Remove(fractionASupprimer);
                }
                bdd.SaveChanges();
            }
        }

        public virtual IEnumerable<Element_General_Objet> Lister()
        {
            return bdd.Categories.Include(c => c.Element).ToList();
        }
        
        public void Dispose()
        {
            bdd.Dispose();
        }
        
        public void Masquer(int id)
        {
            Categorie categorieAMasquer = bdd.Categories.Include(c => c.Element).FirstOrDefault(c => c.Element.Id == id);

            //Suppression de la contrainte Fraction liée à l'élément créé pour la catégorie
            Element elementAMasquer = bdd.Elements.FirstOrDefault(e => e.Id == id);
            //Fraction fractionElementAOter = elementASupprimer.Fraction;
            elementAMasquer.Etat = Element.Etats.Masqué;

            //Fraction fractionASupprimer = bdd.Fractions.FirstOrDefault(f => f.Element.Id == id);
            
            List<Ressource> ressources = bdd.Ressources.Include(r => r.Element).Where(r=> r.Categorie.Element.Id == id).ToList();
            //List<Ressource> ressourcesContenantCategorie = ressources.Contains(r.categorieAMasquer);
            //Element elementRessourceAMasquer = bdd.Elements.FirstOrDefault(e => e.Id == elementRessource.Id);

            foreach (Ressource ress in ressources)
            {
                //if(ressource.Categorie.Id == categorieAMasquer.Element.Id)
                //{
                Element elementRessource = ress.Element;
                Element elementRessourceAMasquer = bdd.Elements.FirstOrDefault(e => e.Id == elementRessource.Id);
                elementRessourceAMasquer.Etat = Element.Etats.Masqué;
                //}
            }


            ////Suppression de la catégorie si elle n'est liee à aucune Ressource, et de son élément lié
            //Ressource ressourceTrouvee = bdd.Ressources.FirstOrDefault(r => r.Categorie.Element.Id == categorieASupprimer.Element.Id);
            //if (ressourceTrouvee == null)
            //{
            //    bdd.Categories.Remove(categorieASupprimer);

            //    if (fractionASupprimer == null)
            //    {
            //        bdd.Elements.Remove(elementASupprimer);
            //    }
            //    else if (ElementContenantFractionASupprimer == null)
            //    {
            //        bdd.Elements.Remove(elementASupprimer);
            //        bdd.Fractions.Remove(fractionASupprimer);
            //    }
                bdd.SaveChanges();
            //}
        }

        public Element_General_Objet Obtenir(string libelle)
        {
            throw new NotImplementedException();
        }
    }
}