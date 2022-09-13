using Projektni_Zadatak.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektni_Zadatak.DAO
{
    public interface IDrzavaDAO : ICRUDDAO<Drzava, string>
    {
        string NazivDrzavaById(string idd);
    }
}
