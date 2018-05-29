using System;
using System.ComponentModel.DataAnnotations;
using Intranet.Areas.Composants.Models.Collaborateurs;

namespace Intranet.Areas.Composants.Models.Elements
{
    public class Element
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date_Creation { get; set; }
        public Collaborateur Collaborateur { get; set; }
        public bool ElementCommunautaire { get; set; }
        public bool ElementGeneral{ get; set; }

        public Element()
        {
            Date_Creation = DateTime.Now;
        }
    }

    
}