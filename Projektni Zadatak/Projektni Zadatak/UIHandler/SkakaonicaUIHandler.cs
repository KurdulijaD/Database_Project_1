using Projektni_Zadatak.Model;
using Projektni_Zadatak.Service;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektni_Zadatak.UIHandler
{
    public class SkakaonicaUIHandler
    {
        private static readonly SkakaonicaService skakaonicaService = new SkakaonicaService();

        public void HandleSkakaonicaMenu()
        {
            String answer;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Odaberite opciju za rad nad skakaonicama:");
                Console.WriteLine("1 - Prikaz svih");
                Console.WriteLine("2 - Prikaz po identifikatoru");
                Console.WriteLine("3 - Unos jedne skakaonice");
                Console.WriteLine("4 - Unos vise skakaonica");
                Console.WriteLine("5 - Izmena po identifikatoru");
                Console.WriteLine("6 - Brisanje po identifikatoru");
                Console.WriteLine("X - Izlazak iz rukovanja skakaonicama");

                answer = Console.ReadLine();

                switch (answer)
                {
                    case "1":
                        ShowAll();
                        break;
                    case "2":
                        ShowById();
                        break;
                    case "3":
                        HandleSingleInsert();
                        break;
                    case "4":
                        HandleMultipleInserts();
                        break;
                    case "5":
                       HandleUpdate();
                        break;
                    case "6":
                        HandleDelete();
                        break;

                }

            } while (!answer.ToUpper().Equals("X"));
        }

        private void ShowAll()
        {
            Console.WriteLine(Skakaonica.GetFormattedHeader());

            try
            {
                foreach (Skakaonica skakaonica in skakaonicaService.FindAll())
                {
                    Console.WriteLine(skakaonica);
                }
            }
            catch (DbException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void ShowById()
        {
            Console.WriteLine("IdSa: ");
            string id = Console.ReadLine();

            try
            {
                Skakaonica skakaonica = skakaonicaService.FindById(id);

                Console.WriteLine(Skakaonica.GetFormattedHeader());
                Console.WriteLine(skakaonica);
            }
            catch (DbException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void HandleSingleInsert()
        {
            Console.WriteLine("ID: ");
            string id = Console.ReadLine();

            Console.WriteLine("Naziv: ");
            string nazivSa = Console.ReadLine();

            Console.WriteLine("Duzina: ");
            int duzinaSa = int.Parse(Console.ReadLine());

            Console.WriteLine("Tip: ");
            string tipSa = Console.ReadLine();

            Console.WriteLine("IDD: ");
            string IdD = Console.ReadLine();

            try
            {
                int inserted = skakaonicaService.Save(new Skakaonica(id, nazivSa, duzinaSa, tipSa, IdD));
                if (inserted != 0)
                {
                    Console.WriteLine("Skakaonica \"{0}\" uspešno uneta.", nazivSa);
                }
            }
            catch (DbException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void HandleMultipleInserts()
        {
            List<Skakaonica> skakaonicaList = new List<Skakaonica>();
            String answer;
            do
            {
                Console.WriteLine("ID: ");
                string id = Console.ReadLine();

                Console.WriteLine("Naziv: ");
                string nazivSa = Console.ReadLine();

                Console.WriteLine("Duzina: ");
                int duzinaSa = int.Parse(Console.ReadLine());

                Console.WriteLine("Tip: ");
                string tipSa = Console.ReadLine();

                Console.WriteLine("IDD: ");
                string IdD = Console.ReadLine();

                skakaonicaList.Add(new Skakaonica(id, nazivSa, duzinaSa, tipSa, IdD));

                Console.WriteLine("Unesi još jednu skakaonicu? (ENTER za potvrdu, X za odustanak)");
                answer = Console.ReadLine();
            } while (!answer.ToUpper().Equals("X"));

            try
            {
                int numInserted = skakaonicaService.SaveAll(skakaonicaList);
                Console.WriteLine("Uspešno uneto {0} skakaonica.", numInserted);
            }
            catch (DbException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void HandleUpdate()
        {
            Console.WriteLine("ID: ");
            string id = Console.ReadLine();

            try
            {
                if (!skakaonicaService.ExistsById(id))
                {
                    Console.WriteLine("Uneta vrednost ne postoji!");
                    return;
                }

                Console.WriteLine("Naziv: ");
                string nazivSa = Console.ReadLine();

                Console.WriteLine("Duzina: ");
                int duzinaSa = int.Parse(Console.ReadLine());

                Console.WriteLine("Tip: ");
                string tipSa = Console.ReadLine();

                Console.WriteLine("IDD: ");
                string IdD = Console.ReadLine();

                int updated = skakaonicaService.Save(new Skakaonica(id, nazivSa, duzinaSa, tipSa, IdD));
                if (updated != 0)
                {
                    Console.WriteLine("Skakaonica \"{0}\" uspešno izmenjena.", id);
                }
            }
            catch (DbException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void HandleDelete()
        {
            Console.WriteLine("ID: ");
            string id = Console.ReadLine();

            try
            {
                int deleted = skakaonicaService.DeleteById(id);
                if (deleted != 0)
                {
                    Console.WriteLine("Skakaonica sa ID: \"{0}\" uspešno obrisana.", id);
                }
            }
            catch (DbException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
