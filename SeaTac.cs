using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApp4
{
    // Write another text file to the c:\temp folder - Random.txt
    // Create Random.txt if it is not there.
    // Append a random number 1-1000 to the end of the file.

    class SeaTac : AnyCity
    {
        public SeaTac(string ssAttr, string spath, string srando)
        {
            sAttr = ssAttr;
            path = spath;
            rando = srando;

            //look for Random.txt
            string fileName = "Random.txt";
            string fullRandoPathName = @path + fileName;

            if (File.Exists(fullRandoPathName))
            {
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

    }  

}
