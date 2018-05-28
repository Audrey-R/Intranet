using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Intranet.Areas.Elements_Generaux.Models;

namespace Intranet.Models
{
    public class Element
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date_Creation { get; set; }
        public virtual Collaborateur Collaborateur { get; set; }
        //public Fraction Fraction { get; set; }
        public bool ComposantCommunautaire { get; set; }
        public bool ComposantGeneral{ get; set; }

        public Element()
        {
            Date_Creation = DateTime.Now;
        }
    }

    
}