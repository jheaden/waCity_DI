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
                        Console.WriteLine("Renton");
                        sAttr = "x";
                        instantiateACity(sAttr, path, rando);
                        break;
                    case "Pasco":
                        Console.WriteLine("Pasco");
                        instantiateACity(sAttr, path, rando);
                        doPascoStuff(sAttr, path, rando);
                        sAttr = "x";
                        break;
                    case "s":
                        Console.WriteLine("SeaTac");
                        instantiateACity(sAttr, path, rando);
                        sAttr = "x";
                        break;
                    default:
                        Console.WriteLine("Something is terribly wrong!");
                        Console.ReadLine();
                        break;
                }


            }

        }

        private static void doPascoStuff(string sAttr, string path, string rando)
        {
            //Open the file just written and 
            // append to the end of the file on a new line another random number 1-1000 preceeded by the text "Pasco".

            string Folder = @path;
            var files = new System.IO.DirectoryInfo(Folder).GetFiles("*.txt");
            string latestfile = "";

            DateTime lastModified = DateTime.MinValue;

            foreach (System.IO.FileInfo fileX in files)
            {
                if (fileX.LastWriteTime > lastModified)
                {
                    lastModified = fileX.LastWriteTime;
                    latestfile = fileX.Name;
                }
            }
            //Show the name of the latestfile
            Console.Write("Latest File Name: " + latestfile);

            //open latest file, append the city's name and a random number to the end of the contents, save the file to the new name of the city plus latest timestamp
            string docPath = (path);

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, latestfile), true))
            {
                outputFile.WriteLine("Hello, appendage! " + ConfigurationManager.AppSettings.Get("City") + " " + rando);
                Console.WriteLine("\n" + sAttr + " appended successfully!");
            }

        }

       

        private static void instantiateACity(string sAttr, string path, string rando)
        {
            waCity newCity = new waCity();
            newCity.GenerateFile(sAttr, path, rando);

        }


    }


}
