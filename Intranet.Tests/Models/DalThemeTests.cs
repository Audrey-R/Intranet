using System.Collections.Generic;
using Intranet.Areas.Elements_Generaux.Models;
using Intranet.Areas.Elements_Generaux.Models.Themes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Intranet.Tests.Models
{
    [TestClass]
    public class dalthemetests
    {
        [TestMethod]
        public void creertheme_deuxnouveauxthemes_listetouslesthemes()
        {
            using (IDal_Element_General_Objet dal = new DalTheme())
            {
                dal.Creer("Réseau");
                dal.Creer("Sécurité");

                List<Theme> themes = (List<Theme>)dal.Lister();

                Assert.IsNotNull(themes);
                Assert.AreEqual(2, themes.Count);
                Assert.AreEqual("Réseau", themes[0].Libelle);
                Assert.AreEqual("Sécurité", themes[1].Libelle);
            }
        }

        [TestMethod]
        public void ModifierTheme_LibelleRéseauEnLibelleReseau_ModificationReussie()
        {
            using (IDal_Element_General_Objet dal = new DalTheme())
            {
                dal.Modifier(9, "Reseau");

                List<Theme> themes = (List<Theme>)dal.Lister();

                Assert.IsNotNull(themes);
                Assert.AreEqual("Reseau", themes[0].Libelle);
            }
        }

        [TestMethod]
        public void SupprimerTheme_SiNonLieAUnElement_SuppressionReussie()
        {
            using (IDal_Element_General_Objet dal = new DalTheme())
            {
                dal.Creer("themeFictif");
                dal.Supprimer(11);

                List<Theme> themes = (List<Theme>)dal.Lister();

                Assert.IsNotNull(themes);
                Assert.AreEqual("Sécurité", themes[1].Libelle);
            }
        }
    }
}
