using Projektni_Zadatak.DAO;
using Projektni_Zadatak.DAO.Implementarion;
using Projektni_Zadatak.DTO;
using Projektni_Zadatak.Model;
using Projektni_Zadatak.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektni_Zadatak.UIHandler
{
    public class ComplexQueryUIHandler
    {
        private static readonly ComplexFuncionalityService complexQueryService = new ComplexFuncionalityService();
        private static readonly ISkakaonicaDAO skakaonicaDAO = new SkakaonicaDAOImpl();
        private static readonly IDrzavaDAO drzavaDAO = new DrzavaDAOImpl();

        public void HandleComplexQueryMenu()
        {
            string answer;
            do
            {
                Console.WriteLine("\nOdaberite funkcionalnost:");

                Console.WriteLine(
                        "\n 1  - Za uneti ID skakaonice prikazati sve skokove koji su vrseni na skakaonici sa tim ID-om."
                        + "\nNakon liste skokova prikazati broj razlicitih skakaca koji su izvodili te skokove");
                Console.WriteLine("\n 2 - Izveštaj koji će prikazati podatke o svakoj državi. " +
                    "\nZa svaku državu treba prikazati i sve skokove koje su skakači iz te države izvodili na skakaonicama iz te iste države");
                Console.WriteLine("\n 3 - Izmena vrednosti obeležja BVETAR (korekcija bodova spram vetra) za odabrani skok.");
                Console.WriteLine("\n 4 - za unete granice dužine skakaonice (minimalna i maksimalna dužina) prikazati sve skakaonice čija je dužina između zadatih granica. " +
                    "\nZa svaku od ovih skakaonica prikazati i naziv države u kojoj se skakaonica nalazi.");
                Console.WriteLine("\n X - Izlazak");

                answer = Console.ReadLine();

                switch (answer)
                {
                    case "1":
                        ShowSkokForSkakaonica();
                        break;
                    case "2":
                        ShowSkokForDrzava();
                        break;
                    case "3":
                        UpdateBVetar();
                        break;
                    case "4":
                        SkakaoniceUOpsegu();
                        break;
                    default:
                        answer = "x";
                        break;
                }
            }
            while (answer.ToLower() != "x");
        }

        //Zadatak 3
        private void ShowSkokForSkakaonica()
        {
            Console.WriteLine("Unesite ID skakaonice: ");
            string id = Console.ReadLine();

            SkokForSkakaonicaDTO dto = complexQueryService.GetSkokForSkakaonica(id);
            Skakaonica skakaonica = skakaonicaDAO.FindById(id);
            Console.WriteLine("\n\t\t\t******************-SKAKAONICA-******************");
            Console.WriteLine(Skakaonica.GetFormattedHeader());
            Console.WriteLine(skakaonica);

            if (dto.Skokovi.Count != 0)
            {
                Console.WriteLine();
                Console.WriteLine("\t\t\t******************-SKOKOVI-*********************");
                Console.WriteLine("\t" + Skok.GetFormattedHeader());
                foreach (Skok skok in dto.Skokovi)
                {
                    Console.WriteLine("\t" + skok);
                }

                Console.WriteLine($"\nBroj razlicitih skakaca: {dto.BrojSkakaca}");
                Console.WriteLine("______________________________________________________________________________________________________");
                Console.WriteLine("\n\n");
            }
            else
            {
                Console.WriteLine("\tNema skokova!");
                Console.WriteLine("______________________________________________________________________________________________________");
                Console.WriteLine("\n\n");
            }
        }

        //Zadatak 4
        private void ShowSkokForDrzava()
        {
            List<SkokForDrzavaDTO> dto = complexQueryService.GetSkokForDrzava();

            foreach (SkokForDrzavaDTO d in dto)
            {
                foreach (KeyValuePair<Drzava, List<Skok>> p in d.skokoviDrzave)
                {
                    Console.WriteLine(Drzava.GetFormattedHeader());
                    Console.WriteLine();
                    Console.WriteLine(p.Key);
                    Console.WriteLine();
                    if (p.Value.Count != 0)
                    {
                        Console.WriteLine(Skok.GetFormattedHeader());
                        Console.WriteLine();
                        foreach (Skok skok in p.Value)
                        {
                            Console.WriteLine(skok);
                        }
                        Console.WriteLine("______________________________________________________________________________________________________");
                        Console.WriteLine("\n\n");
                    }
                    else
                    {
                        Console.WriteLine("(nema skakaca koji zadovoljavaju uslove pretrage)");
                        Console.WriteLine("______________________________________________________________________________________________________");
                        Console.WriteLine("\n\n");
                    }
                }
            }
        }

        //Zadatak 5
        private void UpdateBVetar()
        {
            Console.WriteLine("Unesite IdSk: ");
            string idSk = Console.ReadLine();
            Console.WriteLine("Unesite novu vrijednost BVetar: ");
            double bVetar = double.Parse(Console.ReadLine());

            bool temp = complexQueryService.IzmenaBodovaVetra(idSk, bVetar);
            if(temp == true)
            {
                Console.WriteLine($"Uspjesno izmjenjena vrijednost BVetar za skok {idSk}");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Ne postoji trazeni skok!");
                Console.WriteLine();
            }
            
        }

        //Zadatak 6
        private void SkakaoniceUOpsegu()
        {
            Console.WriteLine("Unesite donju granicu skakaonice");
            int min = int.Parse(Console.ReadLine());
            Console.WriteLine("Unesite gornju granicu skakaonice");
            int max = int.Parse(Console.ReadLine());

            if(min > max)
            {
                Console.WriteLine("Donja granica mora biti manja od gornje granice");
                return;
            }

            List<SkakaoniceOpsegDTO> dto = new List<SkakaoniceOpsegDTO>();
            dto = complexQueryService.GetSkakaoniceOpseg(min, max);

            if (dto.Count != 0)
            {
                Console.WriteLine(Skakaonica.GetFormattedHeader() + string.Format("{0,-30}", "nazivD"));
                foreach (SkakaoniceOpsegDTO item in dto)
                {
                    Console.WriteLine(item.Skakaonica + string.Format("{0, -30}", item.nazivDrzave));
                }
            }
            else
            {
                Console.WriteLine("Ne postoje takve skakaonice");
            }
        }

    }
}
