using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intranet.Areas.Composants.Models.Elements;
using Intranet.Areas.Elements_Generaux.Models.Ressources;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Intranet.Tests.Models
{
    [TestClass]
    public class DalRessourceTests
    {
        //[TestInitialize]
        //public void Init_AvantChaqueTest()
        //{
        //    IDatabaseInitializer<BddContext> init = new DropCreateDatabaseAlways<BddContext>();
        //    Database.SetInitializer(init);
        //    init.InitializeDatabase(new BddContext());
        //}

        //[TestMethod]
        //public void CreerRessource_NouvelleRessource_ListeToutesLesRessources()
        //{
        //    DalRessource dal = new DalRessource();

        //    dal.CreerRessource("Ressource1");
        //    List<Ressource> ressources = dal.ListerToutesLesRessources();

        //    Assert.IsNotNull(ressources);
        //    Assert.AreEqual(1, ressources.Count);
        //    Assert.AreEqual("Ressource1", ressources[0].Titre);
        //}

        //[TestMethod]
        //public void CreerRessource_ModifierRessourceEnAjoutantThemeSecurite_AssociationReussie()
        //{
        //    DalRessource dalRessource = new DalRessource();
            
        //    //Création de la ressource
        //    dalRessource.CreerRessource("Ressource1","blabla");
        //    List<Ressource> ressources = dalRessource.ListerToutesLesRessources();
        //    Ressource dernirereRessource = ressources.FirstOrDefault(ressource => ressource.Titre == "Ressource1");
            
        //    //Ajout d'un thème à la ressource
        //    dalRessource.AjouterUnThemeAUneRessource(dernirereRessource, "Sécurité");
            
        //    Assert.IsNotNull(ressources);
        //    Assert.AreEqual(1, ressources.Count);
        //    Assert.AreEqual("Ressource1", ressources[0].Titre);
        //    Assert.AreEqual("Ressource1", dernirereRessource.Titre);
        //}

        //[TestMethod]
        //public void ModifierRessource_AjouterUnMedia_ListeTousLesMediasAssociesALaRessource()
        //{
        //    using (IDalRessource dal = new DalRessource())
        //    {
        //        dal.AjouterUnMediaAUneRessource(5, dal.ListerTousLesMedias()[0]);


        //        //List<Media> medias = dal.ListerTousLesMedias();
        //        //Media dernierMediaCree = medias.LastOrDefault();

        //        //List<Ressource> ressources = dal.ListerToutesLesRessources();
        //        //Ressource derniereRessource = ressources.LastOrDefault();

        //        //dal.ListerTousLesMedias();


        //        //Assert.IsNotNull(ressources);
        //        //Assert.IsNotNull(medias);
        //        //Assert.AreEqual(0, medias.Count);
        //        //Assert.AreEqual(1, ressources.Count);
        //        //Assert.AreEqual("Ressource1", ressources[0].Titre);
        //        //Assert.AreEqual(mediasAssocies.IndexOf(dernierMediaEnregistre), ressources[0].ListeMediasAssocies[1]);
        //        //Assert.AreEqual("Média2", medias[IndexDernierMediaEnregistre].Titre);
        //        //Assert.AreEqual("Ceci est un test", medias[IndexDernierMediaEnregistre].Description);
        //        //Assert.AreEqual("~/Shared/Img/img1.jpg", medias[IndexDernierMediaEnregistre].Chemin);
        //        //Assert.AreEqual(null, medias[IndexDernierMediaEnregistre].Date_Expiration);
        //    }
        //}
    }
}
