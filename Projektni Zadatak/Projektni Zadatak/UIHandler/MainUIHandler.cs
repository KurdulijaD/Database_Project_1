using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektni_Zadatak.UIHandler
{
    public class MainUIHandler
    {
        private readonly SkakaonicaUIHandler skakaonicaUIHandler = new SkakaonicaUIHandler();
        private readonly ComplexQueryUIHandler complexQueryUIHandler = new ComplexQueryUIHandler();

        public void HandleMainMenu()
        {
            string answer;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Odaberite opciju:");
                Console.WriteLine("1 - Rukovanje skakaonicama");
                Console.WriteLine("2 - Rukovanje kompleksnim upitima");
                Console.WriteLine("X - Izlaz");

                answer = Console.ReadLine();

                switch (answer)
                {
                    case "1":
                        skakaonicaUIHandler.HandleSkakaonicaMenu();
                        break;
                    case "2":
                        complexQueryUIHandler.HandleComplexQueryMenu();
                        break;
                }

            } while (!answer.ToUpper().Equals("X"));
        }
    }
}
