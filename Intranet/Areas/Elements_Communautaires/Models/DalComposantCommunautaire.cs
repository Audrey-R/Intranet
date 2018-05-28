using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Intranet.Areas.Elements_Communautaires.Models;
using Intranet.Areas.Elements_Generaux.Models;

namespace Intranet.Models
{
    public class DalComposantCommunautaire : IDalComposantCommunautaire
    {
        private BddContext bdd;

        public DalComposantCommunautaire()
        {
            bdd = new BddContext();
        }

        ////**********************************************************//
        ////                 COMPOSANTS COMMUNAUTAIRES                           //
        ////**********************************************************//
        //public void CreerComposantCommunautaire(string libelle)
        //{
        //    //Incrémentation de l'IdComposantCommunautaire
        //    //List<Composant_Communautaire> ListeComposantsCommunautaires = ListerTousLesComposantsCommunautaires();
        //    //int idComposantCommunautaire = ListeComposantsCommunautaires.Count + 1;
        //    bdd.Composants_Communautaires.Add(new Composant_Communautaire { LibelleComposantCommunautaire = libelle });
        //    bdd.SaveChanges();
        //}

        //public void ModifierComposantCommunautaire(int id, string libelle)
        //{
        //    Composant_Communautaire composantTrouve = bdd.Composants_Communautaires.FirstOrDefault(composant => composant.IdComposantCommunautaire == id);
        //    if (composantTrouve != null)
        //    {
        //        composantTrouve.LibelleComposantCommunautaire = libelle;
        //        bdd.SaveChanges();
        //    }
        //}

        //public void SupprimerComposantCommunautaire(int id)
        //{
        //    Composant_Communautaire composantTrouve = bdd.Composants_Communautaires.FirstOrDefault(composant => composant.IdComposantCommunautaire == id);
        //    if (composantTrouve != null)
        //    {
        //        bdd.Composants_Communautaires.Remove(composantTrouve);
        //        bdd.SaveChanges();
        //    }
        //}

        //public List<Composant_Communautaire> ListerTousLesComposantsCommunautaires()
        //{
        //    return bdd.Composants_Communautaires.ToList();
        //}

        //**********************************************************//
        //                         MEDIAS                           //
        //**********************************************************//
        public void CreerMedia(string titre, string description, string chemin)
        {
            // Recherche de la fraction "Média"
            Fraction fractionComposantCommunautaireTrouvee = bdd.Fractions.First(fraction => fraction.LibelleFraction == "Média");
            // Création de l'élément de type Média, puis du média
            if (fractionComposantCommunautaireTrouvee != null) {
                Element element = bdd.Elements.Add(new Element { ComposantCommunautaire = true, ComposantGeneral = false });
                bdd.Medias.Add(new Media { Titre = titre, Description = description, Chemin = chemin, Element = element , Fraction = fractionComposantCommunautaireTrouvee });
                bdd.SaveChanges();
            }
        }

        public void ModifierMedia(int id, string titre, string description, string chemin)
        {
            Media mediaTrouve = bdd.Medias.FirstOrDefault(media => media.Element.Id == id);
            if (mediaTrouve != null)
            {
                mediaTrouve.Titre = titre;
                mediaTrouve.Description = description;
                mediaTrouve.Chemin = chemin;

                bdd.SaveChanges();
            }
        }

        public void SupprimerMedia(int id)
        {
            Media mediaTrouve = bdd.Medias.FirstOrDefault(media => media.Element.Id == id);
            if (mediaTrouve != null)
            {
                bdd.Medias.Remove(mediaTrouve);
                bdd.Elements.Remove(mediaTrouve.Element);
                bdd.SaveChanges();
            }
        }

        public List<Media> ListerTousLesMedias()
        {
            return bdd.Medias.ToList();
        }

        //**********************************************************//
        //                     RESSOURCES                           //
        //**********************************************************//
        public void CreerRessource(string titre)
        {
            // Recherche de la fraction "Ressource"
            Fraction fractionComposantCommunautaireTrouvee = bdd.Fractions.First(fraction => fraction.LibelleFraction == "Ressource");
            
            if (fractionComposantCommunautaireTrouvee != null)
            {
                // Création de l'élément de type Ressource, puis de la ressource
                Element element = bdd.Elements.Add(new Element { ComposantCommunautaire = true, ComposantGeneral = false });
                Ressource ressource = bdd.Ressources.Add(new Ressource { Titre = titre, Element = element, Fraction = fractionComposantCommunautaireTrouvee });
                bdd.SaveChanges();

                //Recherche du dernier média créé
                List<Media> medias = ListerTousLesMedias();
                Media dernierMediaCree = medias.LastOrDefault();

                //Ajout du dernier média créé à la ressource
                AjouterUnMediaAUneRessource(ressource.Element.Id, dernierMediaCree);
                bdd.SaveChanges();
            }
        }

        public void AjouterUnMediaAUneRessource(int id, Media media)
        {
            //Recherche de la ressource dans la BDD
            Ressource ressourceTrouvee = bdd.Ressources.FirstOrDefault(ressource => ressource.Element.Id == id);
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



        public void ModifierRessource(int id, string titre, List<Media> listeMediasAssocies)
        {
            Ressource ressourceTrouvee = bdd.Ressources.FirstOrDefault(ressource => ressource.Element.Id == id);
            if (ressourceTrouvee != null)
            {
                ressourceTrouvee.Titre = titre;
                ressourceTrouvee.ListeMediasAssocies = listeMediasAssocies;

                bdd.SaveChanges();
            }
        }

        public void SupprimerRessource(int id)
        {
            Ressource ressourceTrouvee = bdd.Ressources.FirstOrDefault(ressource => ressource.Element.Id == id);
           
            if (ressourceTrouvee != null)
            {
                foreach(Media media in ressourceTrouvee.ListeMediasAssocies)
                {
                    bdd.Medias.Remove(media);
                    ressourceTrouvee.ListeMediasAssocies.Remove(media);
                    bdd.Elements.Remove(media.Element);
                }

                if(ressourceTrouvee.ListeMediasAssocies == null)
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









        public void Dispose()
        {
            bdd.Dispose();
        }
    }
}