using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak1
{
    class Program
    {
		/* Ovdje definirati funkciju */
        static void Izracun(int broj,out int ZbrojDjelitelja, out int ZbrojDo)
        {
            if (broj < 1 || broj > 1000)
                throw new ArgumentOutOfRangeException("Broj je izvan raspona");
            ZbrojDjelitelja = 0;
            ZbrojDo = 0;
            for (int i = 1; i < broj; i++)
            {
                if (broj % i == 0)
                    ZbrojDjelitelja += i;
                ZbrojDo += i;
            }
        }

        static void Main(string[] args)
        {
            var nastavi = true;
            do
            {
                Console.Write("Broj (1-1000): ");
                var unos = Console.ReadLine();
                if(string.IsNullOrEmpty(unos))
                {
                    nastavi = false;
                }
                else
                {
                    var ok = int.TryParse(unos, out int broj);
                    if (!ok)
                    {
                        Console.WriteLine("Pogrešan format");
                        continue;
                    }
                    try
                    {
                        Izracun(broj, out int zbrojDjelitelja, out int zbrojSve);
                        Console.WriteLine("Zbroj djeljitelja od 1 do {0} je {1} a zbroj svih brojeva do {0} je {2}",
                            broj, zbrojDjelitelja, zbrojSve);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Dogodila se pogreška. Tekst: {0}", ex.Message);
                    }
                }
            } while (nastavi);
        }
    }
}
