using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektni_Zadatak.Model
{
    public class Drzava
    {
        public Drzava(string idD, string nazivD)
        {
            IdD = idD;
            NazivD = nazivD;
        }

        public Drzava()
        {

        }

        public string IdD { get; set; }
        public string NazivD { get; set; }

        public override string ToString()
        {
            return string.Format("{0,-10} {1,-20}", IdD, NazivD);
        }
        public static string GetFormattedHeader()
        {
            return string.Format("{0,-10} {1,-20} ", "IdD", "NazivD");
        }

    }
}
