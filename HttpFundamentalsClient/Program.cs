using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace HttpFundamentalsClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                Console.WriteLine("Write Method Name:");
                var methodName=Console.ReadLine();
                var returnResult = CallMethod(methodName);
                Console.WriteLine(returnResult);
            }
        
        }
        private static string CallMethod(string methodName)
        {
            CookieContainer cookies = new CookieContainer();
            HttpClientHandler handler = new HttpClientHandler();
            handler.CookieContainer = cookies;
            using (HttpClient client = new HttpClient(handler))
            {
                var result = client.GetAsync(String.Format("http://localhost:8888/{0}/",methodName)).GetAwaiter().GetResult();
                var parameters = new Dictionary<string, string>();

                var contents = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                Console.WriteLine(result.StatusCode.ToString());
                if (methodName == "MyNameByHeader")
                {
                    Console.WriteLine(result.Headers.GetValues("X-MyName").FirstOrDefault()?.ToString());
                }
                if(methodName == "MyNameByCookies")
                {
                   var cookieRes=cookies.GetCookies(new Uri(String.Format("http://localhost:8888/{0}/", methodName))).Cast<Cookie>().FirstOrDefault(m => m.Name == "MyName");
                    Console.WriteLine(cookieRes.Value);
                }
                return contents;
               
            }

        }
    }
}
