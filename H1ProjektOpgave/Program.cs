using H1ProjektOpgave.Modeller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1ProjektOpgave
{
    class Program
    {
        static void Main(string[] args)
        {
            //Skaber connection til databasen.

            //Console.WriteLine(Kunde.Create("Lucas", "Lund Jensen", "lucas.lund@live.dk"));

            //Console.WriteLine(Biler.Create(87654321, "BMW", "2015", 510515, "Diesel", 2));

            Console.WriteLine(Biler.ShowCar(4));

            Console.ReadKey();
        }
    }
}
