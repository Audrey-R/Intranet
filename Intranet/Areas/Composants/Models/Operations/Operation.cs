using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Intranet.Areas.Composants.Models.Collaborateurs;
using Intranet.Areas.Composants.Models.Elements;

namespace Intranet.Areas.Composants.Models.Operations
{
    public class Operation
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [DisplayName("Collaborateur à l'initiative de l'opération")]
        [DisplayFormat(ConvertEmptyStringToNull = true, NullDisplayText = "Non défini")]
        public Collaborateur Collaborateur { get; set; }
        public Element Element { get; set; }
        public enum Operations { Création, Modification, Masquage, Suppression };
        public Operations Type_Operation { get; set; }
        public string Details { get; set; }

        public Operation()
        {
            Date = DateTime.Now;
        }
    }
}