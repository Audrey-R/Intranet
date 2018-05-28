using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Intranet.Areas.Elements_Communautaires.Models;

namespace Intranet.Models
{
    public interface IDalComposantCommunautaire : IDisposable
    {
        //// Méthodes liées aux composants communautaires
        //void CreerComposantCommunautaire(string libelle);
        //void ModifierComposantCommunautaire(int id, string libelle);
        //void SupprimerComposantCommunautaire(int id);
        //List<Composant_Communautaire> ListerTousLesComposantsCommunautaires();

        // Méthodes liées aux Médias
        void CreerMedia(string titre, string description, string chemin);
        void ModifierMedia(int id, string titre, string description, string chemin);
        void SupprimerMedia(int id);
        List<Media> ListerTousLesMedias();

        // Méthodes liées aux Ressources
        void CreerRessource(string titre);
        void ModifierRessource(int id, string titre, List<Media> listeMediasAssocies);
        void AjouterUnMediaAUneRessource(int id, Media media);
        void SupprimerRessource(int id);
        List<Ressource> ListerToutesLesRessources();
    }
}