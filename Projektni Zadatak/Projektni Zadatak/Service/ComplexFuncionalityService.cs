using Projektni_Zadatak.DAO;
using Projektni_Zadatak.DAO.Implementarion;
using Projektni_Zadatak.DTO;
using Projektni_Zadatak.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektni_Zadatak.Service
{
    public class ComplexFuncionalityService
    {
        private static readonly ISkakaonicaDAO skakaonicaDAO = new SkakaonicaDAOImpl();
        private static readonly ISkokDAO skokDAO = new SkokDAOImpl();
        private static readonly IDrzavaDAO drzavaDAO = new DrzavaDAOImpl();
        private static readonly ISkakacDAO skakacDAO = new SkakacDAOImpl();

        //Zadatak 3
        public SkokForSkakaonicaDTO GetSkokForSkakaonica(string idSa)
        {
            SkokForSkakaonicaDTO dto = new SkokForSkakaonicaDTO();

            dto.Skokovi = skokDAO.GetSkokBySkakaonica(idSa);
            if (dto.Skokovi.Count != 0)
                dto.BrojSkakaca = skokDAO.GetNumOfDiffSkakac(dto.Skokovi);

            return dto;
        }

        //Zadatak 4
        public List<SkokForDrzavaDTO> GetSkokForDrzava()
        {
            List<SkokForDrzavaDTO> ret = new List<SkokForDrzavaDTO>();
            SkokForDrzavaDTO dto = new SkokForDrzavaDTO();
            dto.skokoviDrzave = new Dictionary<Drzava, List<Skok>>();

            foreach (Drzava drzava in drzavaDAO.FindAll())
            {    
                dto.skokoviDrzave.Add(drzava, new List<Skok>());                
                List<string> ids = skakaonicaDAO.GetSkakaoniceFromDrzava(drzava.IdD);
               if (ids.Count != 0)
               { 
                    foreach (string idSkakaonice in ids)
                    {
                        List<Skok> skokovi = skokDAO.GetSkokBySkakaonica(idSkakaonice);
                        if (skokovi.Count != 0)
                        {
                            foreach (Skok skok in skokovi)
                            {
                                Skakac skakac = skakacDAO.FindById(skok.IdSc);
                                if (skakac.IdD.Equals(drzava.IdD))
                                {
                                    dto.skokoviDrzave[drzava].Add(skok);
                                }

                            }
                        }
                    }
               }
            }
            ret.Add(dto);
            return ret;
        }

        //Zadatak 5
        public bool IzmenaBodovaVetra(string idSk, double bVetar)
        {
            if(skokDAO.BVetarIzmena(idSk, bVetar) != 0)
            {
                Skok skok = skokDAO.FindById(idSk);
                double bUkupno = skok.BDuzina + skok.BStil + skok.BVetar;
                double pbsc = skakacDAO.GetPbsc(skok.IdSc);

                if(pbsc < bUkupno)
                {
                    skakacDAO.PbscIzmena(skok.IdSc, bUkupno);                     
                }

     
            }
            else
            {
                return false;
            }

            return true;
        }

        //Zadatak 6
        public List<SkakaoniceOpsegDTO> GetSkakaoniceOpseg(int min, int max)
        {
            List<SkakaoniceOpsegDTO> ret = new List<SkakaoniceOpsegDTO>();
            List<Skakaonica> skakaonice = new List<Skakaonica>();

            skakaonice = skakaonicaDAO.DuzineSkakaonicaOpseg(min, max);

            foreach (Skakaonica item in skakaonice)
            {
                ret.Add(new SkakaoniceOpsegDTO(item, drzavaDAO.NazivDrzavaById(item.IdD)));
            }

            return ret;
        }
    }
}
