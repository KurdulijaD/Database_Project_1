using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektni_Zadatak.Model
{
    public class Skok
    {
        public Skok(string idSk, int idSc, string idSa, double bDuzina, double bStil, double bVetar)
        {
            IdSk = idSk;
            IdSc = idSc;
            IdSa = idSa;
            BDuzina = bDuzina;
            BStil = bStil;
            BVetar = bVetar;
        }

        public Skok()
        {

        }

        public string IdSk { get; set; }
        public int IdSc { get; set; }
        public string IdSa { get; set; }
        public double BDuzina { get; set; }
        public double BStil { get; set; }
        public double BVetar { get; set; }

        public override string ToString()
        {
            return string.Format("{0,-15} {1,-15} {2,-15} {3,-15} {4,-15} {5,-15}", IdSk, IdSc, IdSa, BDuzina, BStil, BVetar);
        }

        public static string GetFormattedHeader()
        {
            return string.Format("{0,-15} {1,-15} {2,-15} {3,-15} {4,-15} {5,-15}", "Id_Sk", "Id_Sc", "Id_Sa", "BDuzina", "BStil", "BVetar");
        }
    }
}
