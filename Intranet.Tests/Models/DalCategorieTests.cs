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

            using (IDal_Element_General_Objet dal = new DalCategorie())
            {
                dal.Creer("Entreprise");
                dal.Creer("Communauté");

                List<Categorie> categories = (List<Categorie>)dal.Lister();
                
                Assert.IsNotNull(categories);
                Assert.AreEqual(2, categories.Count);
                Assert.AreEqual("Entreprise", categories[0].Libelle);
                Assert.AreEqual("Communauté", categories[1].Libelle);
            }
        }

        [TestMethod]
        public void ModifierCategorie_LibelleEntrepriseEnLibelleEntrepris_ModificationReussie()
        {
            using (IDal_Element_General_Objet dal = new DalCategorie())
            {
                dal.Modifier(1, "Entrepris");

                List<Categorie> categories = (List<Categorie>)dal.Lister();

                Assert.IsNotNull(categories);
                Assert.AreEqual("Entrepris", categories[0].Libelle);
            }
        }

        //[TestMethod]
        //public void SupprimerCategorie_SiNonLieeAUneRessourceEtSiNonLieeAAutreElement_SuppressionReussie()
        //{
        //    using (IDalElement_General dal = new DalCategorie())
        //    {
        //        //dal.Creer("categorieFictive");
        //        dal.Supprimer(1);

        //        List<Categorie> categories = (List<Categorie>)dal.Lister();

        //        Assert.IsNotNull(categories);
        //        Assert.AreEqual(1, categories.Count);
        //    }
        //}

        [TestMethod]
        public void MasquerCategorie_EtTousLesElementsLies_MasquageReussi()
        {
            using (IDal_Element_General_Objet dal = new DalCategorie())
            {
                //dal.Creer("categorieFictive");
                dal.Masquer(1);

                List<Categorie> categories = (List<Categorie>)dal.Lister();

                Assert.IsNotNull(categories);
                Assert.AreEqual("Masqué", categories[0].Element.Etat.ToString());
            }
        }
    }
}
