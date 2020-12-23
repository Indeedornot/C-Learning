using System;
using System.Collections.Generic;

namespace bot{
    public static class ConsoleHelper
{
    public static (ConsoleKeyInfo cki, TimeSpan timeSpan) ReadKeyWithTimeOut(int timeOutMS)
    {
        DateTime timeoutvalue = DateTime.Now.AddMilliseconds(timeOutMS);

        while (DateTime.Now < timeoutvalue)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo cki = Console.ReadKey();
                TimeSpan timeSpan = timeoutvalue - DateTime.Now;
                return (cki, timeSpan);
            }
            else
            {
                System.Threading.Thread.Sleep(100);
            }
        }
        return (new ConsoleKeyInfo(' ', ConsoleKey.Spacebar, false, false, false), new TimeSpan(0));
    }
}
}
