using Projektni_Zadatak.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektni_Zadatak.DAO
{
    public interface ISkokDAO : ICRUDDAO<Skok, string>
    {
        List<Skok> GetSkokBySkakaonica(string id);
        List<Skok> GetSkokByDrzava(List<int> skakaci, List<string>skakaonice);
        int GetNumOfDiffSkakac(List<Skok> skokovi);
        int BVetarIzmena(string idSk, double bVetar);
    }
}
