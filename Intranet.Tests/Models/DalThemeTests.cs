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
            using (IDalElement_General dal = new DalTheme())
            {
                dal.Creer("Réseau");
                dal.Creer("Sécurité");

                List<Theme> etats = (List<Theme>)dal.Lister();

                Assert.IsNotNull(etats);
                Assert.AreEqual(2, etats.Count);
                Assert.AreEqual("Réseau", etats[0].Libelle);
                Assert.AreEqual("Sécurité", etats[1].Libelle);
            }
        }
    }
}
