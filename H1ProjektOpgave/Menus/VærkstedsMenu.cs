using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H1ProjektOpgave.Modeller;

namespace H1ProjektOpgave.Menus
{
    class VærkstedsMenu
    {
        public static void SpawnMenu()
        {
            Console.Clear();
            Console.WriteLine("Du har nu følgende muligheder: \n");
            Console.WriteLine("1. Opret Ophold \n2. Slet Ophold \n3. Vis Ophold \n4. Opdater Ophold \n5. Opholds Oversigt \n6. Opgaver i dag");
            string option = Console.ReadLine();

            if (option == "1")
            {
                Console.Write("BilID: ");
                string bilid = Console.ReadLine();
                Console.WriteLine("Dato format: yyyy-MM-dd");
                Console.WriteLine("Opholds Dato: ");
                string opholdsdato = Console.ReadLine();

                try
                {

                    if (string.IsNullOrEmpty(bilid) || string.IsNullOrEmpty(opholdsdato))
                    {
                        Console.WriteLine("Et eller flere felter er tomme, prøv igen.");
                        MainMenu.ReturnMenu();
                    }
                    else
                    {
                        Console.WriteLine(Service.Create(Convert.ToInt32(bilid), opholdsdato));
                        MainMenu.ReturnMenu();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Der skete en fejl, prøv igen.");
                    MainMenu.ReturnMenu();
                }

            }
            else if (option == "2")
            {
                Console.Write("Opholds ID: ");
                string opholdsID = Console.ReadLine();

                try
                {
                    Console.WriteLine(Service.Delete(Convert.ToInt32(opholdsID)));
                    MainMenu.ReturnMenu();
                }
                catch (Exception )
                {
                    Console.WriteLine("Der skete en fejl, prøv igen.");
                    MainMenu.ReturnMenu();
                }
            }

            else if (option == "3")
            {
                Console.Write("Opholds ID: ");
                string opholdsID = Console.ReadLine();

                try
                {
                    Console.WriteLine(Service.ShowOphold(Convert.ToInt32(opholdsID)));
                    MainMenu.ReturnMenu();
                }
                catch (Exception)
                {
                    Console.WriteLine("Der skete en fejl, prøv igen.");
                    MainMenu.ReturnMenu();
                }
            }
            else if (option == "4")
            {
                Console.WriteLine("\nOpholds ID: ");
                string opholdsid = Console.ReadLine();

                Console.WriteLine("\nDu har nu følgende valgmuligheder: ");
                Console.WriteLine("1. Opdater BilID \n2. Opdater Værkstedsophold Dato");
                string serviceOption = Console.ReadLine();
                if (serviceOption == "1")
                {
                    Console.WriteLine("Nye BilID: ");
                    string input = Console.ReadLine();

                    try
                    {
                        Service.Update(Convert.ToInt32(opholdsid), serviceOption, input);
                        MainMenu.ReturnMenu();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Der skete en fejl, prøv igen.");
                        MainMenu.ReturnMenu();
                    }
                }
                else if (serviceOption == "2")
                {
                    Console.WriteLine("Nye Værksteds Opholds Dato: ");
                    string input = Console.ReadLine();

                    try
                    {
                        Console.WriteLine(Service.Update(Convert.ToInt32(opholdsid), serviceOption, input));
                        MainMenu.ReturnMenu();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Der skete en fejl, prøv igen.");
                        MainMenu.ReturnMenu();
                    }
                }
                else
                {
                    MainMenu.ReturnMenu();
                }

            }
            else if (option == "5")
            {
                Console.WriteLine(Kunde.KundeOversigt("værksted"));
                MainMenu.ReturnMenu();
            }
            else if (option == "6")
            {
                Console.WriteLine("Værksteds opgaver i dag: \n");
                Console.WriteLine(Service.OpholdIdag());
                MainMenu.ReturnMenu();
            }
            else
            {
                MainMenu.ReturnMenu();
            }
        }
    }
}
