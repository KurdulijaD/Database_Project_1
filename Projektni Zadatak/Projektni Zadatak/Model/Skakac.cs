using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektni_Zadatak.Model
{
    public class Skakac
    {
        public Skakac(int idSc, string imeSc, string przSc, string idD, int titule, double pbSc)
        {
            IdSc = idSc;
            ImeSc = imeSc;
            PrzSc = przSc;
            IdD = idD;
            Titule = titule;
            PbSc = pbSc;
        }

        public Skakac()
        {

        }

        public int IdSc { get; set; }
        public string ImeSc { get; set; }
        public string PrzSc { get; set; }
        public string IdD { get; set; }
        public int Titule { get; set; }
        public double PbSc { get; set; }
    }
}
