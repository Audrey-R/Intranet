using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        [TestMethod]
        public void CreerComposantCommunauaire_AvecUnNouveauComposantCommunautaire_ObtientTousLesComposantsCommunautairesRenvoitBienLeComposantCommunautaire()
        {
            using (IDalComposantCommunautaire dal = new DalComposantCommunautaire())
            {
                dal.CreerComposantCommunautaire("Ressource");
                List<Composant_Communautaire> composants = dal.ObtientTousLesComposantsCommunautaires();

                Assert.IsNotNull(composants);
                Assert.AreEqual(1, composants.Count);
                Assert.AreEqual("Ressource", composants[0].LibelleComposantCommunautaire);
            }
        }

        //[TestMethod]
        //public void ModifierComposantCommunautaire_CreationDUnNouveauComposantCommunautaireEtChangementLibelle_LaModificationEstCorrecteApresRechargement()
        //{
        //    using (IDalComposantCommunautaire dal = new DalComposantCommunautaire())
        //    {
        //        dal.CreerComposantCommunautaire("Ressource");
        //        List<Composant_Communautaire> composants = dal.ObtientTousLesComposantsCommunautaires();
        //        int id = composants.First(composant => composant.LibelleComposantCommunautaire == "Ressource").Id;

        //        dal.ModifierComposantCommunautaire(id, "Evenement");

        //        composants = dal.ObtientTousLesComposantsCommunautaires();
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
        //        List<Composant_Communautaire> composants = dal.ObtientTousLesComposantsCommunautaires();
        //        int id = composants.First(composant => composant.LibelleComposantCommunautaire == "Ressource").Id;

        //        dal.SupprimerComposantCommunautaire(id);

        //        composants = dal.ObtientTousLesComposantsCommunautaires();
        //        Assert.IsNotNull(composants);
        //        Assert.AreEqual(0, composants.Count);
        //    }
        //}
    }
}
