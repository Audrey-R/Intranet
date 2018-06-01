using System;
using Intranet.Areas.Composants.Models.Collaborateurs;
using Intranet.Areas.Composants.Models.Elements;

namespace Intranet.Areas.Composants.Models.Operations
{
    public class Operation
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Collaborateur Collaborateur { get; set; }
        public Element Element { get; set; }
        public enum Operations { Création, Modification, Supression, Masquage };
        public Operations Type { get; set; } 

        public Operation()
        {
            Date = DateTime.Now;
        }
    }
}