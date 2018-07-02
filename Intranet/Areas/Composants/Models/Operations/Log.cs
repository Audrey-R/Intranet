using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Intranet.Areas.Composants.Models.Operations
{
    public class Log
    {
        public int Id { get; set; }
        [DisplayName("Entité")]
        public string Entite { get; set; }
        [DisplayName("Propriété")]
        public string Propriete { get; set; }
        [DisplayName("Clé primaire")]
        public string ClePrimaire { get; set; }
        [DisplayName("Ancienne valeur")]
        public string AncienneValeur { get; set; }
        [DisplayName("Nouvelle valeur")]
        public string NouvelleValeur { get; set; }
        [DisplayName("Opération")]
        public string Operation { get; set; }
        [DisplayName("Date")]
        public DateTime DateLog { get; set; }
    }
}