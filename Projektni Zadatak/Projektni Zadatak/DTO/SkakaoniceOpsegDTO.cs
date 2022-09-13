using Projektni_Zadatak.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektni_Zadatak.DTO
{
    public class SkakaoniceOpsegDTO
    {
        public SkakaoniceOpsegDTO(Skakaonica skakaonica, string drzava)
        {
            Skakaonica = skakaonica;
            nazivDrzave = drzava;
        }

        public SkakaoniceOpsegDTO()
        {

        }
        public Skakaonica Skakaonica { get; set; }
        public string nazivDrzave { get; set; }

    }
}
