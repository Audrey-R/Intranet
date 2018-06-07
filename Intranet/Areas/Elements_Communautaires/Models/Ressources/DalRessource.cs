using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using Intranet.Areas.Composants.Models.BDD;
using Intranet.Areas.Composants.Models.Elements;
using Intranet.Areas.Elements_Generaux.Models;
using Intranet.Areas.Elements_Communautaires.Models.Medias;
using Intranet.Models;
using Intranet.Areas.Elements_Generaux.Models.Fractions;
using Intranet.Areas.Elements_Generaux.Models.Themes;

namespace Intranet.Areas.Elements_Communautaires.Models.Ressources
{
    public class DalRessource 
    {
        private BddContext bdd;

        public DalRessource()
        {
            bdd = new BddContext();
        }

        public void CreerRessource(string titre)
        {
            // Recherche de la fraction "Ressource"
            Fraction rechercheRessourceDansFractions = bdd.Fractions.FirstOrDefault(fraction => fraction.Libelle.Contains("Ressource"));
            // Création de l'élément de type Ressource
            Element_Communautaire element = bdd.ElementsCommunautaires.Add(new Element_Communautaire());

            if (rechercheRessourceDansFractions == null)
            {
                // Création de la fraction "Ressource"
                Fraction fraction = bdd.Fractions.Add(new Fraction { Libelle = "Ressource", Element = element });
                bdd.SaveChanges();
            }

            // Nouvelle recherche de la fraction "Ressource"
            Fraction fractionRessourceTrouvee = bdd.Fractions.FirstOrDefault(fraction => fraction.Libelle.Contains("Ressource"));

            if (rechercheRessourceDansFractions != null || fractionRessourceTrouvee != null)
            {
                element.Fraction = fractionRessourceTrouvee;
                Ressource ressource = bdd.Ressources.Add(new Ressource { Titre = titre, Element= element});
                bdd.SaveChanges();

                //Recherche du dernier média créé
                List<Media> medias = bdd.Medias.ToList();
                Media dernierMediaCree = medias.LastOrDefault();

                //Ajout du dernier média créé à la ressource
                AjouterUnMediaAUneRessource(ressource.Element.IdElement, dernierMediaCree);
                bdd.SaveChanges();
            }
        }

        public void AjouterUnMediaAUneRessource(int id, Media media)
        {
            //Recherche de la ressource dans la BDD
            Ressource ressourceTrouvee = bdd.Ressources.FirstOrDefault(ressource => ressource.Element.IdElement == id);
            if (ressourceTrouvee != null)
            {
                //Création d'une liste de médias à associer
                List<Media> MediasAAssocier;

                if (ressourceTrouvee.ListeMediasAssocies != null)
                {
                    //Initialisation de la liste avec récupération de la liste de médias associés à la ressource
                    MediasAAssocier = ressourceTrouvee.ListeMediasAssocies;
                }
                else
                {
                    //Initialisation de la liste avec nouvelle liste
                    MediasAAssocier = new List<Media>();
                }

                //Ajout du média à la liste
                MediasAAssocier.Add(media);

                //Remplacement de la liste de la ressource avec la liste mise à jour
                ressourceTrouvee.ListeMediasAssocies = MediasAAssocier;
                bdd.SaveChanges();
            }
        }

        public void AjouterUnThemeAUneRessource(Ressource ressource, string theme)
        {
            Element elementAAjouter = ExtraireElement(ressource);
            List<Theme> themes = bdd.Themes.ToList();
            Theme themeAAjouter = themes.FirstOrDefault(t => t.Libelle == theme);
            
            Element elmt =  bdd.Elements.Single(a => a.IdElement == elementAAjouter.IdElement);
            elmt.ListeThemesAssocies.Add(themeAAjouter) ;
            bdd.SaveChanges();
        }

        public void ModifierRessource(int id, string titre, List<Media> listeMediasAssocies)
        {
            Ressource ressourceTrouvee = bdd.Ressources.FirstOrDefault(ressource => ressource.Element.IdElement == id);
            if (ressourceTrouvee != null)
            {
                ressourceTrouvee.Titre = titre;
                ressourceTrouvee.ListeMediasAssocies = listeMediasAssocies;

                bdd.SaveChanges();
            }
        }

        public void SupprimerRessource(int id)
        {
            Ressource ressourceTrouvee = bdd.Ressources.FirstOrDefault(ressource => ressource.Element.IdElement == id);

            if (ressourceTrouvee != null)
            {
                foreach (Media media in ressourceTrouvee.ListeMediasAssocies)
                {
                    bdd.Medias.Remove(media);
                    ressourceTrouvee.ListeMediasAssocies.Remove(media);
                    bdd.Elements.Remove(media.Element);
                }

                if (ressourceTrouvee.ListeMediasAssocies == null)
                {
                    bdd.Ressources.Remove(ressourceTrouvee);
                    bdd.SaveChanges();
                }
            }
        }

        public List<Ressource> ListerToutesLesRessources()
        {
            return bdd.Ressources.ToList();
        }

        public Element ExtraireElement(Ressource ressource)
        {
            return ressource.Element;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}