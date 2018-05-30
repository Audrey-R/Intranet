using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Intranet.Models;

namespace Intranet.Areas.Elements_Generaux.Models
{
    public interface IElement_General : IDisposable
    {
        int Id { get; set; }
        string Libelle { get; set; }
        Element_General ElementGeneral { get; set; }
    }
}