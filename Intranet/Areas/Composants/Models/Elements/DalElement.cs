using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Intranet.Areas.Composants.Models.BDD;
using Intranet.Areas.Composants.Models.Collaborateurs;
using Intranet.Areas.Elements_Generaux.Models;
using Intranet.Areas.Elements_Generaux.Models.Categories;
using Intranet.Areas.Elements_Generaux.Models.Fractions;
using Intranet.Models;

namespace Intranet.Areas.Composants.Models.Elements
{
    public class DalElement
    {
        private BddContext bdd;

        public DalElement()
        {
            bdd = new BddContext();
        }

        public void CreerElement(Collaborateur collaborateur, bool elementCommunautaire, bool elementGeneral)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public List<Element> ListerTousLesElements()
        {
            return bdd.Elements.ToList();
        }

        public List<Element> ListerTousLesElementsCommunautaires()
        {
            return bdd.Elements.Where(e => (e is Element_Communautaire)).ToList();
        }

        public List<Element> ListerTousLesElementsGeneraux()
        {
            return bdd.Elements.Where(e => (e is Element_General)).ToList();
        }

        public List<Element> ListerTousLesElements(string libelleFraction)
        {
            var requete =   from fraction in bdd.Fractions
                            join element in bdd.Elements on fraction.Id  equals element.Fraction.Id
                            where fraction.Libelle == libelleFraction
                            select new { Element = element};
            var elements =  requete.ToList().Select(
                            e => new Element { Id = e.Element.Id }).ToList();

            return elements;
        }

        public void MasquerElement(int id)
        {
            throw new NotImplementedException();
        }

        public void ModifierElement(bool elementCommunautaire, bool elementGeneral)
        {
            throw new NotImplementedException();
        }

        public void SupprimerElement(int id)
        {
            throw new NotImplementedException();
        }
    }
}