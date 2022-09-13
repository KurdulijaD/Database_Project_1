using Projektni_Zadatak.DAO;
using Projektni_Zadatak.DAO.Implementarion;
using Projektni_Zadatak.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektni_Zadatak.Service
{
    public class SkakaonicaService
    {
        private static readonly ISkakaonicaDAO skakaonicaDAO = new SkakaonicaDAOImpl();

        public List<Skakaonica> FindAll()
        {
            return skakaonicaDAO.FindAll().ToList();
        }

        public Skakaonica FindById(string id)
        {
            return skakaonicaDAO.FindById(id);
        }

        public int Save(Skakaonica p)
        {
            return skakaonicaDAO.Save(p);
        }

        public bool ExistsById(string id)
        {
            return skakaonicaDAO.ExistsById(id);
        }

        public int DeleteById(string id)
        {
            return skakaonicaDAO.DeleteById(id);
        }
        public int SaveAll(List<Skakaonica> skakaonicaList)
        {
            return skakaonicaDAO.SaveAll(skakaonicaList);
        }
    }
}
