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

            AppendRandoToLatestFile(path);

        }

       void AppendRandoToLatestFile(string path)
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

           // string docPath = (path);

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(path, latestfile), true))
            {
                outputFile.WriteLine("Hello, appendage! " + ConfigurationManager.AppSettings.Get("City") + " " + rando);
                Console.WriteLine("\n" + sAttr + " appended successfully!");
            }
        }


    }

}
