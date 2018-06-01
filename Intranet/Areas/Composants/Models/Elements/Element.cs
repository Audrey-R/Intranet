using System.Collections.Generic;
using System.Linq;
using Intranet.Areas.Composants.Models.BDD;
using Intranet.Areas.Composants.Models.Collaborateurs;
using Intranet.Areas.Elements_Generaux.Models;
using Intranet.Areas.Elements_Generaux.Models.Etats;

namespace Intranet.Areas.Composants.Models.Elements
{
    public class Element
    {
        public int Id { get; set; }
        public Collaborateur Collaborateur { get; set; }
        //public Etat Etat { get; set; }
    }
}