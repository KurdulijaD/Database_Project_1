using Projektni_Zadatak.UIHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektni_Zadatak
{
    class Program
    {
        private static readonly MainUIHandler mainUIHandler = new MainUIHandler();
        static void Main(string[] args)
        {
            mainUIHandler.HandleMainMenu();
        }
    }
}
