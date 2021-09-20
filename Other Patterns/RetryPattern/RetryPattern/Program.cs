using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RetryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var retry = new RetryHelper();

            Console.WriteLine(retry.RetryFunction(() =>
            {
                var client = new WebClient();

                return client.DownloadString(@"http://www.naver.com.123123").Substring(0, 100);
                //return client.DownloadString(@"http://www.naver.com").Substring(0, 100);
            }, 3000));
        }
    }

    internal class RetryHelper
    {
        private int LimitRetryCount { get; set; } = 3;  

        internal T RetryFunction<T>(Func<T> func, int delay)
        {
            int retryCount = 0;

            while (true)
            {
                try
                { 
                    return func.Invoke();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    retryCount++;

                    if (retryCount >= LimitRetryCount)
                        throw;
                }

                Thread.Sleep(delay);
            }
        }
    }
}
