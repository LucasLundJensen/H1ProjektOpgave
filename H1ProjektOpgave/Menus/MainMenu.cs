using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H1ProjektOpgave.Menus;

namespace H1ProjektOpgave.Modeller
{
    class MainMenu
    {
        public static void SpawnMenu()
        {
            Console.Clear();
            Console.WriteLine("Du har nu følgende muligheder: \n");
            Console.WriteLine("1. Kunde Menu \n2. Bil Menu \n3. Værksteds Menu ");

            string option = Console.ReadLine();

            if (option == "1")
            {
                KundeMenu.SpawnMenu();
            }
            else if (option == "2")
            {
                BilMenu.SpawnMenu();
            }
            else if (option == "3")
            {
                VærkstedsMenu.SpawnMenu();
            }
            else
            {
                Console.WriteLine("Ikke en valid mulighed, prøv igen.\n");
                SpawnMenu();
            }

        }

        public static void ReturnMenu()
        {
            Console.WriteLine("Tryk på en tast for at fortsætte");
            Console.ReadKey();
            SpawnMenu();
        }
    }
}
