using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intranet.Areas.Elements_Communautaires.Models;
using Intranet.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Intranet.Tests.Models
{
    [TestClass]
    public class DalComposantCommunautaireTests
    {
        //[TestInitialize]
        //public void Init_AvantChaqueTest()
        //{
        //    IDatabaseInitializer<BddContext> init = new DropCreateDatabaseAlways<BddContext>();
        //    Database.SetInitializer(init);
        //    init.InitializeDatabase(new BddContext());
        //}

        //[TestMethod]
        //public void CreerComposantCommunauaire_AvecUnNouveauComposantCommunautaire_ObtientTousLesComposantsCommunautairesRenvoitBienLeComposantCommunautaire()
        //{
        //    using (IDalComposantCommunautaire dal = new DalComposantCommunautaire())
        //    {
        //        dal.CreerComposantCommunautaire("Média");
        //        List<Composant_Communautaire> composants = dal.ListerTousLesComposantsCommunautaires();

        //        Assert.IsNotNull(composants);
        //        Assert.AreEqual(1, composants.Count);
        //        Assert.AreEqual("Média", composants[0].LibelleComposantCommunautaire);
        //    }
        //}

        [TestMethod]
        public void CreerComposantCommunauaire_AvecDeuxComposantsCommunautaires_ObtientTousLesComposantsCommunautairesRenvoitBienLesComposantsCommunautaires()
        {
            using (IDalComposantCommunautaire dal = new DalComposantCommunautaire())
            {
                dal.CreerComposantCommunautaire("Média");
                dal.CreerComposantCommunautaire("Ressource");
                List<Composant_Communautaire> composants = dal.ListerTousLesComposantsCommunautaires();

                Assert.IsNotNull(composants);
                Assert.AreEqual(2, composants.Count);
                Assert.AreEqual("Média", composants[0].LibelleComposantCommunautaire);
                Assert.AreEqual("Ressource", composants[1].LibelleComposantCommunautaire);
            }
        }

        [TestMethod]
        public void CreerMedia_SansDateExpiration_ListeTousLesMediasEtRenvoitBienLeMedia()
        {
            //using (IDalComposantCommunautaire dal = new DalComposantCommunautaire())
            //{
            //    dal.CreerMedia("Média1", "Ceci est un test", "https://openclassrooms.com/dashboard", null);
            //    List <Media> medias = dal.ListerTousLesMedias();

            //    List<Composant_Communautaire> composants = dal.ListerTousLesComposantsCommunautaires();
            //    int idComposantCommunautaire = composants.First(composant => composant.LibelleComposantCommunautaire == "Média").Id;

            //    Assert.IsNotNull(medias);
            //    Assert.AreEqual(1, medias.Count);
            //    Assert.AreEqual("Média1", medias[0].Titre);
            //    Assert.AreEqual("Ceci est un test", medias[0].Description);
            //    Assert.AreEqual("https://openclassrooms.com/dashboard", medias[0].Chemin);
            //    Assert.AreEqual(null, medias[0].Date_Expiration);
            //    Assert.AreEqual(idComposantCommunautaire, medias[0].IdComposantCommunautaire);
            //}
        }

        [TestMethod]
        public void CreerRessource_AvecDernierMediaCreeSansDateExpiration_ListeToutesLesRessourcesEtRenvoitBienLaRessource()
        {
            using (IDalComposantCommunautaire dal = new DalComposantCommunautaire())
            {
                List<Media> mediasAssocies = new List<Media>();

                dal.CreerMedia("Média1", "Ceci est un test", "https://openclassrooms.com/dashboard", null);
                dal.CreerMedia("Média2", "Ceci est un test", "~/Shared/Img/img1.jpg", null);
                List<Media> medias = dal.ListerTousLesMedias();
                Media dernierMediaEnregistre = medias.Last();
                int IndexDernierMediaEnregistre = medias.IndexOf(dernierMediaEnregistre);

                mediasAssocies.Add(dernierMediaEnregistre);

                dal.CreerRessource("Ressource1", mediasAssocies);
                List<Ressource> ressources = dal.ListerToutesLesRessources();
                
                Assert.IsNotNull(ressources);
                Assert.IsNotNull(medias);
                Assert.AreEqual(2, medias.Count);
                Assert.AreEqual(1, ressources.Count);
                Assert.AreEqual("Ressource1", ressources[0].Titre);
                Assert.AreEqual(mediasAssocies.IndexOf(dernierMediaEnregistre), ressources[0].ListeMediasAssocies[0]);
                Assert.AreEqual("Média2", medias[IndexDernierMediaEnregistre].Titre);
                Assert.AreEqual("Ceci est un test", medias[IndexDernierMediaEnregistre].Description);
                Assert.AreEqual("~/Shared/Img/img1.jpg", medias[IndexDernierMediaEnregistre].Chemin);
                Assert.AreEqual(null, medias[IndexDernierMediaEnregistre].Date_Expiration);
            }
        }

        //[TestMethod]
        //public void ModifierComposantCommunautaire_CreationDUnNouveauComposantCommunautaireEtChangementLibelle_LaModificationEstCorrecteApresRechargement()
        //{
        //    using (IDalComposantCommunautaire dal = new DalComposantCommunautaire())
        //    {
        //        dal.CreerComposantCommunautaire("Ressource");
        //        List<Composant_Communautaire> composants = dal.ListerTousLesComposantsCommunautaires();
        //        int id = composants.First(composant => composant.LibelleComposantCommunautaire == "Ressource").Id;

        //        dal.ModifierComposantCommunautaire(id, "Evenement");

        //        composants = dal.ListerTousLesComposantsCommunautaires();
        //        Assert.IsNotNull(composants);
        //        Assert.AreEqual(1, composants.Count);
        //        Assert.AreEqual("Evenement", composants[0].LibelleComposantCommunautaire);
        //    }
        //}

        //[TestMethod]
        //public void SupprimerComposantCommunautaire_CreationPuisSuppressionDUnComposantCommunautaireRenvoiDUneListeVide_SupprimeBienLeComposantCommunautaire()
        //{
        //    using (IDalComposantCommunautaire dal = new DalComposantCommunautaire())
        //    {
        //        dal.CreerComposantCommunautaire("Ressource");
        //        List<Composant_Communautaire> composants = dal.ListerTousLesComposantsCommunautaires();
        //        int id = composants.First(composant => composant.LibelleComposantCommunautaire == "Ressource").Id;

        //        dal.SupprimerComposantCommunautaire(id);

        //        composants = dal.ListerTousLesComposantsCommunautaires();
        //        Assert.IsNotNull(composants);
        //        Assert.AreEqual(0, composants.Count);
        //    }
        //}
    }
}
