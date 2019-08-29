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
                        InstantiateACity(sAttr, path, rando);
                        sAttr = "x";
                        break;
                    case "Pasco":
                        Console.WriteLine("Pasco confirmed");
                        InstantiateACity(sAttr, path, rando);
                        DoPascoStuff(sAttr, path, rando);
                        sAttr = "x";
                        break;
                    case "SeaTac":
                        Console.WriteLine("SeaTac confirmed");
                        InstantiateACity(sAttr, path, rando);
                        DoSeaTacStuff(sAttr, path, rando);
                        sAttr = "x";
                        break;
                    default:
                        Console.WriteLine("Something is terribly wrong!");
                        Console.ReadLine();
                        sAttr = "x";
                        break;
                }
            }

        }

        // Write another text file to the c:\temp folder - Random.txt
        // Create Random.txt if it is not there.
        // Append a random number 1-1000 to the end of the file.
        private static void DoSeaTacStuff(string sAttr, string path, string rando)
        {
            Console.WriteLine("Do SeaTac Stuff confirmed!" + sAttr + path + rando);

            //look for Random.txt
            string fileName = "Random.txt";
            string fullRandoPathName = @path + fileName;

            if (File.Exists(fullRandoPathName)) {
                Console.WriteLine("Random.txt found");

                using (StreamWriter outputFile = new StreamWriter(Path.Combine(@path, fullRandoPathName), true))
                {
                    outputFile.WriteLine(rando);
                    Console.WriteLine("\n" + "Random.txt appended with random number successfully!");
                }
            }
            else
            {
                Console.WriteLine("Random.txt NOT found");

                using (StreamWriter writer = new StreamWriter(fullRandoPathName))
                {
                    writer.Write(rando);
                }
                Console.WriteLine("Random.txt created and appended successfully.");


            }
        }

        //Open the file just written and 
        // append to the end of the file on a new line another random number 1-1000 preceeded by the text "Pasco".
        private static void DoPascoStuff(string sAttr, string path, string rando)
        {
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

       
        private static void InstantiateACity(string sAttr, string path, string rando)
        {
            waCity newCity = new waCity();
            newCity.GenerateFile(sAttr, path, rando);

        }


    }


}
