using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intranet.Areas.Composants.Models.BDD;
using Intranet.Areas.Composants.Models.Elements;
using Intranet.Areas.Elements_Generaux.Models;
using Intranet.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Intranet.Tests.Models
{
    [TestClass]
    public class DalFractionTests
    {
        //[TestInitialize]
        //public void Init_AvantChaqueTest()
        //{
        //    IDatabaseInitializer<BddContext> init = new DropCreateDatabaseAlways<BddContext>();
        //    Database.SetInitializer(init);
        //    init.InitializeDatabase(new BddContext());
        //}


        [TestMethod]
        public void CreerFraction_DeuxNouvellesFractions_ListeToutesLesFractions()
        {
            DalFraction dal = new DalFraction();
            
                dal.Creer("Média");
                dal.Creer("Ressource");
                List<Fraction> fractions = dal.Lister();

                Assert.IsNotNull(fractions);
                Assert.AreEqual(2, fractions.Count);
                Assert.AreEqual("Média", fractions[0].Libelle);
                Assert.AreEqual("Ressource", fractions[1].Libelle);}
        }
        //[TestMethod]
        //public void CreerComposantGeneral_AvecUnNouveauComposantGeneral_ObtientTousLesComposantsGenerauxRenvoitBienLeComposantGeneral()
        //{
        //    using (IDalComposantGeneral dal = new DalComposantGeneral())
        //    {
        //        dal.CreerComposantGeneral("Catégorie");
        //        List<Composant_General> composants = dal.ListerTousLesComposantsGeneraux();

        //        Assert.IsNotNull(composants);
        //        Assert.AreEqual(1, composants.Count);
        //        Assert.AreEqual("Catégorie", composants[0].LibelleComposantGeneral);
        //    }
        //}

        //[TestMethod]
        //public void ModifierComposantGeneral_CreationDUnNouveauComposantGeneralEtChangementLibelle_LaModificationEstCorrecteApresRechargement()
        //{
        //    using (IDalComposantGeneral dal = new DalComposantGeneral())
        //    {
        //        dal.CreerComposantGeneral("Catégorie");
        //        List<Composant_General> composants = dal.ListerTousLesComposantsGeneraux();
        //        int id = composants.First(composant => composant.LibelleComposantGeneral == "Catégorie").Id;

        //        dal.ModifierComposantGeneral(id, "Thème");

        //        composants = dal.ListerTousLesComposantsGeneraux();
        //        Assert.IsNotNull(composants);
        //        Assert.AreEqual(1, composants.Count);
        //        Assert.AreEqual("Thème", composants[0].LibelleComposantGeneral);
        //    }
        //}

        //[TestMethod]
        //public void SupprimerComposantGeneral_CreationPuisSuppressionDUnComposantGeneralRenvoiDUneListeVide_SupprimeBienLeComposantGeneral()
        //{
        //    using (IDalComposantGeneral dal = new DalComposantGeneral())
        //    {
        //        dal.CreerComposantGeneral("Catégorie");
        //        List<Composant_General> composants = dal.ListerTousLesComposantsGeneraux();
        //        int id = composants.First(composant => composant.LibelleComposantGeneral == "Catégorie").Id;

        //        dal.SupprimerComposantGeneral(id);

        //        composants = dal.ListerTousLesComposantsGeneraux();
        //        Assert.IsNotNull(composants);
        //        Assert.AreEqual(0, composants.Count);
        //    }
        //}
    }
