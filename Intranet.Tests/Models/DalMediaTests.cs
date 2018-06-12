using System;
using System.Collections.Generic;
using Intranet.Areas.Elements_Communautaires.Models.Medias;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Intranet.Tests.Models
{
    [TestClass]
    public class DalMediaTests
    {
        //[TestInitialize]
        //public void Init_AvantChaqueTest()
        //{
        //    IDatabaseInitializer<BddContext> init = new DropCreateDatabaseAlways<BddContext>();
        //    Database.SetInitializer(init);
        //    init.InitializeDatabase(new BddContext());
        //}

        [TestMethod]
        public void CreerMedia_DeuxNouveauxMedias_ListeTousLesMedias()
        {
            DalMedia dal = new DalMedia();
            
                dal.Creer("Média1", "Ceci est un test", "https://openclassrooms.com/dashboard");
                dal.Creer("Média2", "Ceci est un test", "~/Shared/Img/img1.jpg");

                List<Media> medias = dal.Lister();

                Assert.IsNotNull(medias);
                Assert.AreEqual(2, medias.Count);
                Assert.AreEqual("Média1", medias[0].Titre);
                Assert.AreEqual("Ceci est un test", medias[0].Description);
                Assert.AreEqual("https://openclassrooms.com/dashboard", medias[0].Chemin);
                Assert.AreEqual("Média2", medias[1].Titre);
                Assert.AreEqual("Ceci est un test", medias[1].Description);
                Assert.AreEqual("~/Shared/Img/img1.jpg", medias[1].Chemin);
        }

        //[TestMethod]
        //public void ModifierFraction_LibelleMédiaEnLibelleMedia_ModificationReussie()
        //{
        //    DalMedia dal = new DalMedia();
        //    dal.Modifier("Média", "Media");

        //    List<Fraction> fractions = (List<Fraction>)dal.Lister();

        //    Assert.IsNotNull(fractions);
        //    Assert.AreEqual("Media", fractions[2].Libelle);
        //}
    }
}
