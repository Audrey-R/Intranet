using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Intranet.Areas.Composants.Models.BDD;
using Intranet.Areas.Composants.Models.Elements;
using Intranet.Areas.Elements_Generaux.Models.Fractions;
using Intranet.Models;

namespace Intranet.Areas.Elements_Generaux.Models.Themes
{
    public class DalTheme : IDalElement_General
    {
        private BddContext bdd;

        public DalTheme()
        {
            bdd = new BddContext();
        }


        public void Creer(string libelle)
        {
            // Recherche de la fraction "Thème"
            Fraction fraction = bdd.Fractions.FirstOrDefault(f => f.Libelle.Contains("Thème"));

            // Création de l'élément de type Catégorie
            Element_General element = bdd.ElementsGeneraux.Add(new Element_General());
            
            if (fraction == null)
            {
                // Création de la fraction "Catégorie"
                fraction = bdd.Fractions.Add(new Fraction { Libelle = "Thème", Element = element });
                bdd.SaveChanges();
            }

            element.Fraction = fraction ;
            bdd.Themes.Add(new Theme { Libelle = libelle, Element = element });
            bdd.SaveChanges();
        }

        public void Dispose()
        {
            bdd.Dispose();
        }

        public Element ExtraireElement(Element_General_Objet element)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Element_General_Objet> Lister()
        {
            return bdd.Themes.ToList();
        }

       

        public void Masquer(int id)
        {
            throw new NotImplementedException();
        }

        public void Modifier(int id, string nouveauLibelle)
        {
            Theme themeTrouve = bdd.Themes.FirstOrDefault(t => t.Element.Id == id);
            if (themeTrouve != null && themeTrouve.Libelle != nouveauLibelle)
            {
                themeTrouve.Libelle = nouveauLibelle;
                bdd.SaveChanges();
            }
        }

        public void Supprimer(int id)
        {
            Theme themeASupprimer = bdd.Themes.FirstOrDefault(t => t.Element.Id == id);
            //Suppression de la contrainte Fraction liée à l'élément créé pour la catégorie
            Element elementASupprimer = bdd.Elements.FirstOrDefault(e => e.Id == id);
            Fraction fractionAOter = elementASupprimer.Fraction;
            fractionAOter = null;

            //Suppression de la catégorie si elle n'est liee à aucune Ressource, et de son élément lié
            Element elementTrouve = bdd.Elements.FirstOrDefault(e => e.ListeThemesAssocies.Any(t=> t.Element.Id == themeASupprimer.Element.Id));
            if (elementTrouve == null)
            {
                elementASupprimer.ListeThemesAssocies.Remove(themeASupprimer);
                bdd.Themes.Remove(themeASupprimer);
                bdd.Elements.Remove(elementASupprimer);
                bdd.SaveChanges();
            }
        }

        public Element_General_Objet Obtenir(string libelle)
        {
            Theme themeTrouve = bdd.Themes.FirstOrDefault(theme => theme.Libelle == libelle);
            return themeTrouve;
        }
        
    }
}