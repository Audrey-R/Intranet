using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Intranet.Areas.Elements_Communautaires.Models;
using Intranet.Areas.Elements_Generaux.Models;

namespace Intranet.Areas.Composants.Models.Dal
{
    public class Dal_Composants : IDal_Composants
    {
        private BddContext bdd;

        public Dal_Composants()
        {
            bdd = new BddContext();
        }

        public List<Element> ListerTousLesElements()
        {
            return bdd.Elements.Include(e => e.Fraction).ToList();
        }

        public List<Element> ListerTousLesElementsCommunautaires()
        {
            return bdd.Elements.Include(e => e.Fraction).Where(e => (e is Element_Communautaire)).ToList();
        }

        public List<Element> ListerTousLesElementsGeneraux()
        {
            return bdd.Elements.Include(e => e.Fraction).Where(e => (e is Element_General)).ToList();
        }

        public List<Element> ListerTousLesElements(int? id)
        {
            return bdd.Elements.Include(e => e.Fraction).Where(e => (e.Fraction.Id == id)).ToList();
        }

        public List<Log> ListerTousLesElementsAvecLog()
        {
            return bdd.Logs.ToList(); ;
        }

    }
}