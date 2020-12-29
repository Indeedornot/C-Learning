using System;
using System.Net.Http;
using System.Threading.Tasks;

//Just some sandbox I'll be taking code out of
namespace TestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = Console.ReadLine();
            string ShortenedUrl = tinyurl(url).Result;
            Console.WriteLine(ShortenedUrl);
        }

        static async Task<string> tinyurl(string url)
        {
            try
            {
                var client = new HttpClient();
                return await client.GetStringAsync("http://tinyurl.com/api-create.php?url=" + url);
            }
            catch
            {
                Console.WriteLine("ERROR");
                Console.WriteLine("Repeat Request");
                return null;
            }

        }
    }
}