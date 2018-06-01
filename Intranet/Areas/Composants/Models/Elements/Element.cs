using System;
using System.ComponentModel.DataAnnotations;
using Intranet.Areas.Composants.Models.Collaborateurs;
using Intranet.Models;

namespace Intranet.Areas.Composants.Models.Elements
{
    public class Element
    {
        public int Id { get; set; }
        //public DateTime Date_Creation { get; set; }
        public Collaborateur Collaborateur { get; set; }

        public Element()
        {
            //Date_Creation = DateTime.Now;
        }
    }

    
}