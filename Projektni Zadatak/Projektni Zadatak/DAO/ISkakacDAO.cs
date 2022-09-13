using Projektni_Zadatak.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektni_Zadatak.DAO
{
    public interface ISkakacDAO : ICRUDDAO<Skakac, int>
    {
        List<int> GetSkakaciFromDrzava(string id);
        double GetPbsc(int idSc);
        int PbscIzmena(int idSc, double pbsc);
    }
}
