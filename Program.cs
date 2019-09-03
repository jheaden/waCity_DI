using System;
using System.Configuration;
using System.IO;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            const string path = "C:\\temp\\";
            string sAttr = ConfigurationManager.AppSettings.Get("City");
            string rando = generateStringyRandomNumber();

            CityController(sAttr, path, rando);
            Console.ReadLine();

            string generateStringyRandomNumber()
            {
                Random random = new Random();
                int num = random.Next(1000);
                return num.ToString();
            }
        }

        private static void CityController(string sAttr, string path, string rando)
        {
            //prompt user for selection
            while (sAttr != "x")
            {
                switch (sAttr)
                {
                    case "Renton":
                        Console.WriteLine("Renton confirmed");
                        Renton renton = new Renton();
                        renton.GenerateFile(sAttr, path, rando);
                        sAttr = "x";
                        break;
                    case "Pasco":
                        Console.WriteLine("Pasco confirmed");
                        Pasco pasco = new Pasco(sAttr, path, rando);
                        pasco.GenerateFile(sAttr, path, rando);
                        sAttr = "x";
                        break;
                    case "SeaTac":
                        Console.WriteLine("SeaTac confirmed");
                        SeaTac seatac = new SeaTac(sAttr, path, rando);
                        seatac.GenerateFile(sAttr, path, rando);
                        sAttr = "x";
                        break;
                    default:
                        Console.WriteLine("Something is terribly wrong.");
                        Console.ReadLine();
                        sAttr = "x";
                        break;
                }
            }

        }
    }
}
