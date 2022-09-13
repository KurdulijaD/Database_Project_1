using Projektni_Zadatak.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektni_Zadatak.DTO
{
    public class SkokForDrzavaDTO
    {
       public Drzava Drzava { get; set; }
       public Dictionary<Drzava, List<Skok>>skokoviDrzave { get; set; }
        
    }
}
