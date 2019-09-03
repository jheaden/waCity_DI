using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;

namespace ConsoleApp4
{
    class Pasco : AnyCity
    {
        public Pasco (string psAttr,string ppath, string prando)
        {
            sAttr = psAttr;
            path = ppath;
            rando = prando;

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

    }

}
