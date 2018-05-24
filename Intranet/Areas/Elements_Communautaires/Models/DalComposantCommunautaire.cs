using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Intranet.Areas.Elements_Communautaires.Models;

namespace Intranet.Models
{
    public class DalComposantCommunautaire : IDalComposantCommunautaire
    {
        private BddContext bdd;

        public DalComposantCommunautaire()
        {
            bdd = new BddContext();
        }

        //**********************************************************//
        //                 COMPOSANTS COMMUNAUTAIRES                           //
        //**********************************************************//
        public void CreerComposantCommunautaire(string libelle)
        {
            //Incrémentation de l'IdComposantCommunautaire
            //List<Composant_Communautaire> ListeComposantsCommunautaires = ListerTousLesComposantsCommunautaires();
            //int idComposantCommunautaire = ListeComposantsCommunautaires.Count + 1;
            bdd.Composants_Communautaires.Add(new Composant_Communautaire { LibelleComposantCommunautaire = libelle });
            bdd.SaveChanges();
        }

        public void ModifierComposantCommunautaire(int id, string libelle)
        {
            Composant_Communautaire composantTrouve = bdd.Composants_Communautaires.FirstOrDefault(composant => composant.Id == id);
            if (composantTrouve != null)
            {
                composantTrouve.LibelleComposantCommunautaire = libelle;
                bdd.SaveChanges();
            }
        }

        public void SupprimerComposantCommunautaire(int id)
        {
            Composant_Communautaire composantTrouve = bdd.Composants_Communautaires.FirstOrDefault(composant => composant.Id == id);
            if (composantTrouve != null)
            {
                bdd.Composants_Communautaires.Remove(composantTrouve);
                bdd.SaveChanges();
            }
        }

        public List<Composant_Communautaire> ListerTousLesComposantsCommunautaires()
        {
            return bdd.Composants_Communautaires.ToList();
        }

        //**********************************************************//
        //                         MEDIAS                           //
        //**********************************************************//
        public void CreerMedia(string titre, string description, string chemin, DateTime? dateExpiration)
        {
            //Incrémentation de l'IdMedia
            //List<Media> ListeMedias = ListerTousLesMedias();
            //int idMedia = ListeMedias.Count + 1;

            // Association de l'IdComposantCommunautaire adéquat
            List<Composant_Communautaire> ListeComposantsCommunautaires = ListerTousLesComposantsCommunautaires();
            Composant_Communautaire composantMedia = ListeComposantsCommunautaires.First(composant => composant.LibelleComposantCommunautaire == "Média");
            bdd.Medias.Add(new Media { Titre = titre, Description = description, Chemin = chemin, Date_Expiration = dateExpiration, ComposantCommunautaire = composantMedia });
            bdd.SaveChanges();
        }

        public void ModifierMedia(int id, string titre, string description, string chemin, DateTime? dateExpiration)
        {
            Media mediaTrouve = bdd.Medias.FirstOrDefault(media => media.Id == id);
            if (mediaTrouve != null)
            {
                mediaTrouve.Titre = titre;
                mediaTrouve.Description = description;
                mediaTrouve.Chemin = chemin;
                mediaTrouve.Date_Expiration = dateExpiration;

                bdd.SaveChanges();
            }
        }

        public void SupprimerMedia(int id)
        {
            Media mediaTrouve = bdd.Medias.FirstOrDefault(media => media.Id == id);
            if (mediaTrouve != null)
            {
                bdd.Medias.Remove(mediaTrouve);
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
        public void CreerRessource(string titre, List <Media> listeMedias)
        {
            //Incrémentation de l'IdRessource
            //List<Ressource> ListeRessources = ListerToutesLesRessources();
            //int idRessource = ListeRessources.Count + 1;

            //Association de l'IdComposantCommunautaire adéquat
            List<Composant_Communautaire> ListeComposantsCommunautaires = ListerTousLesComposantsCommunautaires();
            Composant_Communautaire composantRessource = ListeComposantsCommunautaires.First(composant => composant.LibelleComposantCommunautaire == "Ressource");
            
            // Ajout du dernier média créé à la liste de médias associée à la ressource
            List<Media> ListeMedias = ListerTousLesMedias();
            Media dernierMediaEnregistre = ListeMedias.Last();
            List<Media> listeMediasAssocies = new List<Media>();
            listeMediasAssocies.Add(dernierMediaEnregistre);

            bdd.Ressources.Add(new Ressource {Titre = titre, ListeMediasAssocies = listeMediasAssocies, ComposantCommunautaire = composantRessource });
            bdd.SaveChanges();
        }

        public void ModifierRessource(int id, string titre, List<Media> listeMediasAssocies)
        {
            Ressource ressourceTrouvee = bdd.Ressources.FirstOrDefault(ressource => ressource.Id == id);
            if (ressourceTrouvee != null)
            {
                ressourceTrouvee.Titre = titre;
                ressourceTrouvee.ListeMediasAssocies = listeMediasAssocies;

                bdd.SaveChanges();
            }
        }

        public void SupprimerRessource(int id)
        {
            Ressource ressourceTrouvee = bdd.Ressources.FirstOrDefault(ressource => ressource.Id == id);
            if (ressourceTrouvee != null)
            {
                bdd.Ressources.Remove(ressourceTrouvee);
                bdd.SaveChanges();
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