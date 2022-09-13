using Projektni_Zadatak.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektni_Zadatak.DTO
{
    public class SkokForSkakaonicaDTO
    {
        public SkokForSkakaonicaDTO(List<Skok> skokovi, int brojSkakaca)
        {
            Skokovi = skokovi;
            BrojSkakaca = brojSkakaca;
        }

        public SkokForSkakaonicaDTO()
        {

        }

        public Skakaonica Skakaonica { get; set; }
        public List<Skok> Skokovi { get; set; }
        public int BrojSkakaca { get; set; }
    }
}
