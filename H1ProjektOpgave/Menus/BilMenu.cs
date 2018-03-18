using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H1ProjektOpgave.Modeller;

namespace H1ProjektOpgave.Menus
{
    class BilMenu
    {
        public static void SpawnMenu()
        {
            Console.Clear();
            Console.WriteLine("Du har nu følgende muligheder: \n");
            Console.WriteLine("1. Opret Bil \n2. Vis Bil \n3. Slet Bil \n4. Opdater Bil ");
            string option = Console.ReadLine();

            if (option == "1")
            {
                Console.Write("RegNr: ");
                string regNr = Console.ReadLine();

                Console.Write("Mærke: ");
                string maerke = Console.ReadLine();

                Console.Write("Årgang: ");
                string aargang = Console.ReadLine();

                Console.Write("Kilometer Kørt: ");
                string km = Console.ReadLine();

                Console.Write("Brændstofstype: ");
                string brandstofstype = Console.ReadLine();

                Console.Write("KundeID (Hvis tom bliver kundeID til bilen 0): ");
                string kundeid = Console.ReadLine();
                try
                {

                    if (string.IsNullOrEmpty(kundeid))
                    {
                        kundeid = "1";
                    }

                    Console.WriteLine(Biler.Create(Convert.ToInt32(regNr), maerke, aargang, Convert.ToInt32(km), brandstofstype, Convert.ToInt32(kundeid)));
                    MainMenu.ReturnMenu();

                }
                catch (Exception)
                {
                    Console.WriteLine("Sket en fejl med input, prøv igen.");
                    MainMenu.ReturnMenu();
                }
            }
            else if (option == "2")
            {
                Console.Write("BilID: ");
                string bilid = Console.ReadLine();

                try
                {
                    Console.WriteLine(Biler.ShowCar(Convert.ToInt32(bilid)));
                    MainMenu.ReturnMenu();
                }
                catch (Exception)
                {
                    Console.WriteLine("Der skete en fejl, prøv igen.");
                    MainMenu.ReturnMenu();
                }
            }
            else if (option == "3")
            {
                Console.Write("BilID: ");
                string bilid = Console.ReadLine();

                try
                {
                    Console.WriteLine(Biler.Delete(Convert.ToInt32(bilid)));
                    MainMenu.ReturnMenu();
                }
                catch (Exception )
                {
                    Console.WriteLine("Der skete en fejl, prøv igen.");
                    MainMenu.ReturnMenu();
                }
            }
            else if (option == "4")
            {
                Console.Write("BilID (Den bil du vil opdatere): ");
                string bilid = Console.ReadLine();

                Console.WriteLine("Du har nu følgende muligheder: \n");
                Console.WriteLine("1. Opdater RegNr \n2. Opdater Mærke \n3. Opdater Årgang \n4. Opdater Kilometer kørt \n5. Opdater Brændstofstype \n6. Opdater ejer af bil");
                string bilOption = Console.ReadLine();

                if (bilOption == "1")
                {

                    Console.Write("Nye registerings nummer: ");
                    string input = Console.ReadLine();
                    try
                    {
                        Console.WriteLine(Biler.Update(Convert.ToInt32(bilid), bilOption, input));
                        MainMenu.ReturnMenu();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Forkert format i input, prøv igen.");
                        MainMenu.ReturnMenu();
                    }
                }

                if (bilOption == "2")
                {

                    Console.Write("Nye Mærke: ");
                    string input = Console.ReadLine();
                    try
                    {
                        Console.WriteLine(Biler.Update(Convert.ToInt32(bilid), bilOption, input));
                        MainMenu.ReturnMenu();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Forkert format i input, prøv igen.");
                        MainMenu.ReturnMenu();
                    }
                }

                if (bilOption == "3")
                {

                    Console.Write("Nye Årgang: ");
                    string input = Console.ReadLine();
                    try
                    {
                        Console.WriteLine(Biler.Update(Convert.ToInt32(bilid), bilOption, input));
                        MainMenu.ReturnMenu();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Forkert format i input, prøv igen.");
                        MainMenu.ReturnMenu();
                    }
                }
                if (bilOption == "4")
                {

                    Console.Write("Nye Kilometer Kørt: ");
                    string input = Console.ReadLine();
                    try
                    {
                        Console.WriteLine(Biler.Update(Convert.ToInt32(bilid), bilOption, input));
                        MainMenu.ReturnMenu();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Forkert format i input, prøv igen.");
                        MainMenu.ReturnMenu();
                    }
                }
                if (bilOption == "5")
                {

                    Console.Write("Nye Brændstofstype: ");
                    string input = Console.ReadLine();
                    try
                    {
                        Console.WriteLine(Biler.Update(Convert.ToInt32(bilid), bilOption, input));
                        MainMenu.ReturnMenu();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Forkert format i input, prøv igen.");
                        MainMenu.ReturnMenu();
                    }
                }
                if (bilOption == "6")
                {

                    Console.Write("Nye Ejer: ");
                    string input = Console.ReadLine();
                    try
                    {
                        Console.WriteLine(Biler.Update(Convert.ToInt32(bilid), bilOption, input));
                        MainMenu.ReturnMenu();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Forkert format i input, prøv igen.");
                        MainMenu.ReturnMenu();
                    }
                }
            }
        }
    }
}
