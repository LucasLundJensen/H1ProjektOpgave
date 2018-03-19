using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1ProjektOpgave.Modeller
{
    class KundeMenu
    {
        public static void SpawnMenu()
        {
            Console.Clear();
            Console.WriteLine("Du har nu følgende muligheder: \n");
            Console.WriteLine("1. Opret Kunde \n2. Vis Kunde (Virker kun hvis de har en bil) \n3. Slet Kunde \n4. Kundeoversigt ");
            string option = Console.ReadLine();

            if (option == "1")
            {
                Console.Write("Fornavn: ");
                string fornavn = Console.ReadLine();

                Console.Write("Efternavn: ");
                string efternavn = Console.ReadLine();

                Console.Write("Email: ");
                string email = Console.ReadLine();

                if (string.IsNullOrEmpty(fornavn) || string.IsNullOrEmpty(efternavn) || string.IsNullOrEmpty(email))
                {
                    Console.WriteLine("Fejl i input, prøv igen.");
                    MainMenu.ReturnMenu();
                }
                else
                {
                    Console.WriteLine(Kunde.Create(fornavn, efternavn, email));
                    MainMenu.ReturnMenu();
                }
            }
            else if (option == "2")
            {
                Console.Write("KundeID (tal): ");
                string KundeID = Console.ReadLine();

                try
                {
                    Console.WriteLine(Kunde.Overview(Convert.ToInt32(KundeID)));
                    MainMenu.ReturnMenu();
                }
                catch (Exception)
                {
                    Console.WriteLine("Input er ikke et tal, prøv igen.");
                    MainMenu.ReturnMenu();
                }
            }
            else if (option == "3")
            {
                Console.Write("KundeID (tal): ");
                string KundeID = Console.ReadLine();

                try
                {
                    Console.WriteLine(Kunde.Delete(Convert.ToInt32(KundeID)));
                    MainMenu.ReturnMenu();
                }
                catch (Exception)
                {
                    Console.WriteLine("Input er ikke et tal, prøv igen.");
                    MainMenu.ReturnMenu();
                }
            }
            else if (option == "4")
            {
                Console.WriteLine("1. Kundeoversigt \n2. Bil Oversigt");
                string oversigtOption = Console.ReadLine();

                if (oversigtOption == "1")
                {
                    Console.WriteLine(Kunde.KundeOversigt("Kundeoversigt"));
                    MainMenu.ReturnMenu();
                }
                else if (oversigtOption == "2")
                {
                    Console.WriteLine(Kunde.KundeOversigt("Biloversigt"));
                    MainMenu.ReturnMenu();
                }
                else
                {
                    Console.WriteLine("Ikke en gyldig valgmulighed");
                    MainMenu.ReturnMenu();
                }
            }
            else
            {
                MainMenu.ReturnMenu();
            }
        }
    }
}
