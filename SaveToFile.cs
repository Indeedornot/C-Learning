using System;
using System.IO;

//Just some sandbox I'll be taking code out of
namespace TestProject {
    class Program {
        static void Main (string [ ] args) {
            string TextFileName = "Data" + ".txt";
            string Text = null;
            while (Text != "q") {
                Text = Console.ReadLine ( );
                string workingDirectory = Environment.CurrentDirectory + @"\" + TextFileName;
                
                using (System.IO.StreamWriter file = new System.IO.StreamWriter (@workingDirectory, true)) 
                {
                    file.WriteLine (Text);
                }
            }
        }
    }
}