using Microsoft.FSharp.Collections;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace CSharpTest
{
    public class Class1
    {
        private static void Test()
        {
            LibraryTest.CompareWithCSharp.quicksort2(FSharpList<int>.Empty);
        }
    }

    internal static class WebPageDownloader
    {
        public static TResult FetchUrl<TResult>(
            string url,
            Func<string, StreamReader, TResult> callback)
        {
            var req = WebRequest.Create(url);
            using (var resp = req.GetResponse())
            using (var stream = resp.GetResponseStream())
            using (var reader = new StreamReader(stream))
                return callback(url, reader);
        }
    }

    internal class WebPageDownloaderTests
    {
        public void TestFetchUrlWithCallback()
        {
            string MyCallback(string url, StreamReader reader)
            {
                var html = reader.ReadToEnd();
                var html1000 = html.Substring(0, 1000);
                Console.WriteLine("Downloaded {0}. First 1000 is {1}", url, html1000);
                return html;
            }

            string FetchUrlWithCallback(string url) => WebPageDownloader.FetchUrl(url, MyCallback);

            var google = FetchUrlWithCallback("http://www.google.com");

            // test with a list of sites     
            var sites = new List<string> {
                "http://www.bing.com",
                "http://www.google.com",
                "http://www.yahoo.com"};

            // process each site in the list
            sites.ForEach(site => FetchUrlWithCallback(site));
        }
    }
}
