using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Threading;

//dotnet add package TextCopy --version 4.2.0
//uses appropriate clipboard system for os
//https://github.com/CopyText/TextCopy
using TextCopy;

//dotnet add package EventHook --version 1.4.113
//monitor for keyboard, mouse, clipboard, apps
//https://www.nuget.org/packages/EventHook
using EventHook;

//about TestProject.csproj
//net5.0 for cross-platform, net5.0-windows for Windows only
//these 2 for net5.0-windows only
//<UseWindowsForms>true</UseWindowsForms>
//<DisableWinExeOutputInference>true</DisableWinExeOutputInference>

//this project is windows only - EventHook

//Just some sandbox I'll be taking code out of
namespace TestProject
{
    class program
    {
        static int queueSize = 0;
        static void Main()
        {

            using (var eventHookFactory = new EventHookFactory())
            {
                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                var clipboardWatcher = eventHookFactory.GetClipboardWatcher();
                clipboardWatcher.Start();
                clipboardWatcher.OnClipboardModified += (s, e) =>
                {
                    if (e.DataFormat == 0)
                    {
                        cancellationTokenSource.Cancel();
                        cancellationTokenSource = new CancellationTokenSource();
                        ShortenUrl(cancellationTokenSource);
                    }
                };
                Console.Read();
                clipboardWatcher.Stop();
            }
        }
        
        static async Task ShortenUrl(CancellationTokenSource cancellationTokenSource)
        {
            var url = await ClipboardService.GetTextAsync();
            var client = new HttpClient();
            try
            {
                var textData = await client.GetStringAsync("http://tinyurl.com/api-create.php?url=" + url, cancellationTokenSource.Token);
                await ClipboardService.SetTextAsync(textData);
                Console.WriteLine("Done");
            }
            catch
            {
            }
            return;

        }
    }
}

