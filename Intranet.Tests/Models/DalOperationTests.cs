using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intranet.Areas.Composants.Models.BDD;
using Intranet.Areas.Elements_Generaux.Models;
using Intranet.Areas.Elements_Generaux.Models.Categories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Intranet.Tests.Models
{
    [TestClass]
    public class DalOperationTests
    {
        //[TestInitialize]
        //public void Init_AvantChaqueTest()
        //{
        //    IDatabaseInitializer<BddContext> init = new DropCreateDatabaseAlways<BddContext>();
        //    Database.SetInitializer(init);
        //    init.InitializeDatabase(new BddContext());
        //}


        //[TestMethod]
        //public void CreerOperatuine_DeuxNouvellesCategories_ListeToutesLesFractions()
        //{
        //    IDatabaseInitializer<BddContext> init = new DropCreateDatabaseAlways<BddContext>();
        //    Database.SetInitializer(init);
        //    init.InitializeDatabase(new BddContext());

        //    using (IDalElement_General dal = new DalCategorie())
        //    {
        //        dal.Creer("Entreprise");
        //        dal.Creer("Communauté");
        //        //IEnumerable<Fraction_Generale> liste = dal.Lister();
        //        List<Categorie> categories = (List<Categorie>)dal.Lister();

        //        //List<Categorie> ListeCategories = (List<Categorie>)dal.Lister(categories);

        //        Assert.IsNotNull(categories);
        //        //Assert.IsNotNull(ListeCategories);
        //        Assert.AreEqual(2, categories.Count);
        //        Assert.AreEqual("Entreprise", categories[0].Libelle);
        //        Assert.AreEqual("Communauté", categories[1].Libelle);
        //    }
        //}
    }
}
