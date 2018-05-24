using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Intranet.Models
{
    public class Composant_General : Element
    {
        [Key]
        public int IdComposantGeneral { get; set; }
        public string LibelleComposantGeneral { get; set; }

        public Composant_General()
        {
            using (IDalComposantGeneral dal = new DalComposantGeneral())
            {
                //Incrémentation de l'IdComposantCommunautaire
                List<Composant_General> ListeComposantsGeneral = dal.ListerTousLesComposantsGeneraux();
                IdComposantGeneral = ListeComposantsGeneral.Count + 1;
            }
        }
    }
}