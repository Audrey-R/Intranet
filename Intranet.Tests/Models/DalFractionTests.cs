using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intranet.Areas.Composants.Models.BDD;
using Intranet.Areas.Composants.Models.Elements;
using Intranet.Areas.Elements_Generaux.Models;
using Intranet.Areas.Elements_Generaux.Models.Fractions;
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
        public void CreerFraction_TroisNouvellesFractions_ListeToutesLesFractions()
        {
            using (IDal_Element_General_Objet dal = new DalFraction())
            {

                dal.Creer("Fraction");
                dal.Creer("Média");
                dal.Creer("Ressource");
                List<Fraction> fractions = (List<Fraction>)dal.Lister();

                Assert.IsNotNull(fractions);
                Assert.AreEqual(4, fractions.Count);
                Assert.AreEqual("Catégorie", fractions[0].Libelle);
                Assert.AreEqual("Fraction", fractions[1].Libelle);
                Assert.AreEqual("Média", fractions[2].Libelle);
                Assert.AreEqual("Ressource", fractions[3].Libelle);
            }
        }

        [TestMethod]
        public void ModifierFraction_LibelleMédiaEnLibelleMedia_ModificationReussie()
        {
            using (IDal_Element_General_Objet dal = new DalFraction())
            {
                dal.Modifier(4, "Media");

                List<Fraction> fractions = (List<Fraction>)dal.Lister();

                Assert.IsNotNull(fractions);
                Assert.AreEqual("Media", fractions[2].Libelle);
            }
        }

        [TestMethod]
        public void SupprimerFraction_SiNonLieeAUnElement_SuppressionReussie()
        {
            using (IDal_Element_General_Objet dal = new DalFraction())
            {
                dal.Creer("fractionFictive");
                dal.Supprimer(6);

                List<Fraction> fractions = (List<Fraction>)dal.Lister();

                Assert.IsNotNull(fractions);
                Assert.AreEqual("Media", fractions[2].Libelle);
            }
        }
    }   
}
