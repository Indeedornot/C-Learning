using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Threading;

public class Browsing {
    static void Main () {
        int sleepTime = 100;
        string additive = "";
        string url;
        string[] urls =
{
};
        for(int i = 0; i < urls.Length; i++)
        {
            url = additive + urls[i];
            OpenUrl (url);
            Thread.Sleep(sleeptime); // Sleep
        }
    }
    static void OpenUrl (string url) {
        try {
            Process.Start (url);
        } catch {
            url = url.Replace ("&", "^&");
            Process.Start (new ProcessStartInfo ("cmd", $"/c start {url}") { CreateNoWindow = true });
        }
    }

}