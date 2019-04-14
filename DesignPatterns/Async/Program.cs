using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Async
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = "http://www.rocksolidknowledge.com/5SecondPage.aspx";
            var download = DownloadWebPage(url);

            Console.WriteLine(download);

            var downloadTask = DownloadWebPageAsync(url);
            while (!downloadTask.IsCompleted)
            {
                Console.WriteLine(".");
                Thread.Sleep(250);
            }

            Console.WriteLine(download);

            Console.ReadLine();
        }

        private static string DownloadWebPage(string url)
        {
            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                return reader.ReadToEnd();
            }
        }

        private static Task<string> DownloadWebPage2(string url)
        {
            var request = WebRequest.Create(url);
            var result = request.BeginGetResponse(null, null);

            return Task.Factory.FromAsync(result, iar =>
            {
                var response = request.EndGetResponse(iar);
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    return reader.ReadToEnd();
                }
            });
        }

        private static Task<string> DownloadWebPageAsync(string url)
        {
            return Task.Factory.StartNew(() => DownloadWebPage(url));
        }
    }
}
