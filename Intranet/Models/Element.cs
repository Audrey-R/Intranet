using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Intranet.Models
{
    public class Element
    {
        [Key]
        public int Id { get; set; }
        public virtual Collaborateur Collaborateur { get; set; }
    }

    
}