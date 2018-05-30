using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intranet.Areas.Composants.Models.BDD;
using Intranet.Areas.Composants.Models.Elements;
using Intranet.Areas.Elements_Generaux;
using Intranet.Areas.Elements_Generaux.Models;
using Intranet.Areas.Elements_Generaux.Models.Categories;
using Intranet.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Intranet.Tests.Models
{
    [TestClass]
    public class DalCategorieTests 
    {
        //[TestInitialize]
        //public void Init_AvantChaqueTest()
        //{
        //    IDatabaseInitializer<BddContext> init = new DropCreateDatabaseAlways<BddContext>();
        //    Database.SetInitializer(init);
        //    init.InitializeDatabase(new BddContext());
        //}


        [TestMethod]
        public void CreerCategorie_DeuxNouvellesCategories_ListeToutesLesFractions()
        {
            IDatabaseInitializer<BddContext> init = new DropCreateDatabaseAlways<BddContext>();
            Database.SetInitializer(init);
            init.InitializeDatabase(new BddContext());

            DalCategorie dalCategorie = new DalCategorie();
            DalFraction dalFraction = new DalFraction();


                dalCategorie.Creer("Entreprise");
                dalCategorie.Creer("Communauté");
                List<Categorie> categories = dalCategorie.Lister();

                Assert.IsNotNull(categories);
                //Assert.AreEqual(2, categories.Count);
                //Assert.AreEqual("Entreprise", categories[0].Libelle);
                //Assert.AreEqual("Communauté", categories[1].Libelle);
            
        }
    }
}
