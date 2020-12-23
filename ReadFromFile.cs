using System;
using System.Collections.Generic;
using System.IO;

//Just some sandbox I'll be taking code out of
namespace TestProject {
    class Program {
        static void Main (string [ ] args) {
            string TextFileName = "Data" + ".txt";
            string workingDirectory = Environment.CurrentDirectory + @"\" + TextFileName;
            string line;
            if (File.Exists (workingDirectory)) {
                using (StreamReader sr = new StreamReader (@workingDirectory)) {
                    while ((line = sr.ReadLine ( )) != null) {
                        Console.WriteLine (line);
                    }

                }
            }
            else
            {
                Console.WriteLine("Data file doesn't exist");
            }
        }
    }
}