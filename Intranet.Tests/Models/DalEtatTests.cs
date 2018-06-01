using System.Collections.Generic;
using Intranet.Areas.Elements_Generaux.Models;
using Intranet.Areas.Elements_Generaux.Models.Etats;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Intranet.Tests.Models
{
    [TestClass]
    public class DalEtatTests
    {
        [TestMethod]
        public void CreerEtat_DeuxNouveauxEtats_ListeTousLesEtats()
        {
            using (IDalElement_General dal = new DalEtat())
            {
                dal.Creer("Publié");
                dal.Creer("Modifié");

                List<Etat> etats = (List<Etat>)dal.Lister();

                Assert.IsNotNull(etats);
                Assert.AreEqual(2, etats.Count);
                Assert.AreEqual("Publié", etats[0].Libelle);
                Assert.AreEqual("Modifié", etats[1].Libelle);
            }
        }
    }
}
