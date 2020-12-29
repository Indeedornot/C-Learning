using System.Net.Mime;
using System;
using System.Threading.Tasks;

//dotnet add package TextCopy --version 4.2.0
//uses appropriate clipboard system for os
//https://github.com/CopyText/TextCopy
using TextCopy;

//Just some sandbox I'll be taking code out of
namespace TestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string textData = "abcdefg";
            var clip = Clip(textData);
        }

        static async Task Clip(string textData)
        {
            //gets text
            var a = await ClipboardService.GetTextAsync();
            //write text
            Console.WriteLine(a);
            //sets text
            await ClipboardService.SetTextAsync(textData);

        }
    }
}