using System.Collections.Generic;
using System.Data.Entity;
using Intranet.Areas.Composants.Models.BDD;
using Intranet.Areas.Composants.Models.Elements;
using Intranet.Areas.Elements_Communautaires.Models;
using Intranet.Areas.Elements_Communautaires.Models.Dal;
using Intranet.Areas.Elements_Communautaires.Models.Ressources;
using Intranet.Areas.Elements_Generaux.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Intranet.Tests.Models
{
    [TestClass]
    public class DalThemeTests
    {
        BddContext bdd = new BddContext();
        //[TestMethod]
        //public void CreerTheme_DeuxNouveauxThemes_ListeTousLesThemes()
        //{
        //    using (IDal_Element_General_Objet dal = new Dal_Element_General_Objet())
        //    {
        //        Theme themeACreer1 = new Theme { Libelle = "Réseau" };
        //        Theme themeACreer2 = new Theme { Libelle = "Sécurité" };
        //        dal.Creer(themeACreer1);
        //        dal.Creer(themeACreer2);

        //        List<Theme> themes = (List<Theme>)dal.Lister(themeACreer1);

        //        Assert.IsNotNull(themes);
        //        Assert.AreEqual(2, themes.Count);
        //        Assert.AreEqual("Réseau", themes[0].Libelle);
        //        Assert.AreEqual("Sécurité", themes[1].Libelle);
        //    }
        //}

        [TestInitialize]
        public void Init_AvantChaqueTest()
        {
            IDatabaseInitializer<BddContext> init = new DropCreateDatabaseAlways<BddContext>();
            Database.SetInitializer(init);
            init.InitializeDatabase(new BddContext());
        }

        [TestMethod]
        public void AjouterThemeAElement_ElementLie_ListeTousLesThemesAssociesAUnElement()
        {
            IDal_Element_General_Objet dalElementGeneral = new Dal_Element_General_Objet();
            IDal_Element_Communautaire_Objet dalElementCommunautaire = new Dal_Element_Communautaire_Objet();
            Theme themeACreer1 = new Theme { Libelle = "Réseau" };
            Theme themeACreer2 = new Theme { Libelle = "Sécurité" };
            dalElementGeneral.Creer(themeACreer1);
            dalElementGeneral.Creer(themeACreer2);

            Element_Communautaire element = new Element_Communautaire();
            Ressource ressourceACreer = new Ressource { Titre = "blabla", Description = "blablabla", Element = element };
            

            //BddContext bdd = dalElementGeneral.RetournerBdd();

            //Element elementALier = bdd.Elements.SingleAsync(u => u.Id == element.Id);
            //Theme themeALier = bdd.Themes.SingleAsync(r => r.Id == themeACreer2.Id);

           // elementALier.ListeThemesAssocies.Add(themeALier);
            List<Theme> listeAAjouter = new List<Theme>();
            listeAAjouter.Add(themeACreer2);
            element.ListeThemesAssocies.Clear();

            foreach(Theme theme in listeAAjouter)
                element.ListeThemesAssocies.Add(theme);
           // themeACreer2.ListeElementsAssocies.Add(element);
            bdd.SaveChanges();
            //List<Element> listeElementsAjouter = new List<Element>();
            //listeElementsAjouter.AddRange(themeACreer2.ListeElementsAssocies);
            //listeElementsAjouter.Add(element);
            //themeACreer2.ListeElementsAssocies = listeElementsAjouter;
            //themeACreer2.ListeElementsAssocies.Add(element);


            //List<Theme> themes = (List<Theme>)dal.Lister(themeACreer1);

            Assert.IsNotNull(element.ListeThemesAssocies);
            Assert.AreEqual(1, element.ListeThemesAssocies.Count);
            //Assert.IsNotNull(themeACreer2.ListeElementsAssocies);
            //Assert.AreEqual(1, themeACreer2.ListeElementsAssocies.Count);

        }

        //[TestMethod]
        //public void ModifierTheme_LibelleRéseauEnLibelleReseau_ModificationReussie()
        //{
        //    using (IDal_Element_General_Objet dal = new DalTheme())
        //    {
        //        dal.Modifier(9, "Reseau");

        //        List<Theme> themes = (List<Theme>)dal.Lister();

        //        Assert.IsNotNull(themes);
        //        Assert.AreEqual("Reseau", themes[0].Libelle);
        //    }
        //}

        //[TestMethod]
        //public void SupprimerTheme_SiNonLieAUnElement_SuppressionReussie()
        //{
        //    using (IDal_Element_General_Objet dal = new DalTheme())
        //    {
        //        dal.Creer("themeFictif");
        //        dal.Supprimer(11);

        //        List<Theme> themes = (List<Theme>)dal.Lister();

        //        Assert.IsNotNull(themes);
        //        Assert.AreEqual("Sécurité", themes[1].Libelle);
        //    }
        //}
    }
}
