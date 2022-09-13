using Projektni_Zadatak.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektni_Zadatak.DAO
{
    interface ISkakaonicaDAO : ICRUDDAO<Skakaonica, string>
    {
        List<string> GetSkakaoniceFromDrzava(string id);
        List<Skakaonica> DuzineSkakaonicaOpseg(int min, int max);
    }
}
