using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApp4
{
    class waCity
    {
       
        public void GenerateFile(string sAttr, string path, string rando)
        {
            string timeStamp = GetTimestamp(DateTime.Now);
            string FILE_NAME = sAttr + '_' + timeStamp;

            //create the text file at the specified PATH
            string file = @path + FILE_NAME + ".txt";
            using (StreamWriter writer = new StreamWriter(file))
            {
                writer.Write(rando);
            }
            Console.WriteLine(FILE_NAME + " created successfully!");

        }

        private string GetTimestamp(DateTime value)
        { 
            return value.ToString("MM-dd-yyyy_hhmmtt").ToLower();
         
        }
    }
}
