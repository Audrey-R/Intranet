using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intranet.Areas.Composants.Models.Dal
{
    interface IDal_Composants
    {
        List<Element> ListerTousLesElements();
        List<Element> ListerTousLesElementsCommunautaires();
        List<Element> ListerTousLesElementsGeneraux();
        List<Element> ListerTousLesElements(int? id);
        List<Log> ListerTousLesElementsAvecLog();
    }
}
