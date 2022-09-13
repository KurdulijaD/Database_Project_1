using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektni_Zadatak.Model
{
    public class Skakaonica
    {
        public Skakaonica(string idSa, string nazivSa, int duzinaSa, string tipSa, string idD)
        {
            IdSa = idSa;
            NazivSa = nazivSa;
            DuzinaSa = duzinaSa;
            TipSa = tipSa;
            IdD = idD;
        }

        public Skakaonica()
        {


        }

        public string IdSa { get; set; }
        public string NazivSa { get; set; }
        public int DuzinaSa { get; set; }
        public string TipSa { get; set; }
        public string IdD { get; set; }

        public override string ToString()
        {
            return string.Format("{0,-8} {1,-40} {2,-8} {3,25} {4,-8}", IdSa, NazivSa, DuzinaSa, TipSa, IdD);
        }

        public static string GetFormattedHeader()
        {
            return string.Format("{0,-8} {1,-40} {2,-8} {3,25} {4,-8}", "Id_Sa", "Name_Sa", "Duzina_Sa", "Tip_Sa", "IdD_Sa");
        }
    }
}
