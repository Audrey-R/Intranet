using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intranet.Areas.Composants.Models.BDD;
using Intranet.Areas.Composants.Models.Elements;
using Intranet.Areas.Elements_Generaux.Models.Categories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Intranet.Tests.Models
{
        [TestClass]
        public class DalElementTests
        {
            //[TestInitialize]
            //public void Init_AvantChaqueTest()
            //{
            //    IDatabaseInitializer<BddContext> init = new DropCreateDatabaseAlways<BddContext>();
            //    Database.SetInitializer(init);
            //    init.InitializeDatabase(new BddContext());
            //}


            [TestMethod]
            public void Lister_ListeElements_ListeTousLesElements()
            {
                DalElement dal = new DalElement();

                List<Element> listeElements = dal.ListerTousLesElements();
                
                Assert.IsNotNull(listeElements);
                Assert.AreEqual(2, listeElements.Count);
            }

            [TestMethod]
            public void Lister_ListeElementsCommunautaires_ListeTousLesElementsCommunautaires()
            {
                DalElement dal = new DalElement();
            
                List<Element> listeElementsCommunautaires = dal.ListerTousLesElementsCommunautaires();
                
                Assert.IsNotNull(listeElementsCommunautaires);
                Assert.AreEqual(0, listeElementsCommunautaires.Count);
            }

            [TestMethod]
            public void Lister_ListeElementsGeneraux_ListeTousLesElementsGeneraux()
            {
                DalElement dal = new DalElement();

                List<Element> listeElementsGeneraux = dal.ListerTousLesElementsGeneraux();
            
                Assert.IsNotNull(listeElementsGeneraux);
                Assert.AreEqual(2, listeElementsGeneraux.Count);
            }

            [TestMethod]
            public void Lister_ListeElementsAvecParametreFraction_ListeTousLesElementsDeLaFraction()
            {
                DalElement dal = new DalElement();

                List<Element> listeElementsCategorie = dal.ListerTousLesElements("Catégorie");
                //List<Categorie> listeElementsCategorie = (List<Categorie>)dal.ListerTousLesElements("Catégorie");

                Assert.IsNotNull(listeElementsCategorie);
                Assert.AreEqual(2, listeElementsCategorie.Count);
                Assert.AreEqual(1, listeElementsCategorie[0].IdElement);
                Assert.AreEqual(2, listeElementsCategorie[1].IdElement);
        }
        
        }
    }

