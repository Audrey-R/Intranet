using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Intranet.Areas.Composants.Models.Elements;
using Intranet.Models;

namespace Intranet.Areas.Elements_Communautaires.Models
{
    public interface IElement_Communautaire
    {
      Element Element { get; set; }
    }
}