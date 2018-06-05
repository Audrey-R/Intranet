using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Intranet.Areas.Composants.Models.BDD;
using Intranet.Areas.Composants.Models.Collaborateurs;

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
            throw new NotImplementedException();
        }

        public List<Element> ListerTousLesElementsGeneraux()
        {
            throw new NotImplementedException();
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