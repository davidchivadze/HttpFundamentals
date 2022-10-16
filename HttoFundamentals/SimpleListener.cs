using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace HttoFundamentalsListener
{
    public static class SimpleListener
    {
        public static void SimpleListenerExample(string[] prefixes)
        {
            if (!HttpListener.IsSupported)
            {
                Console.WriteLine("Windows XP SP2 or Server 2003 is required to use the HttpListener class.");
                return;
            }
            if (prefixes == null || prefixes.Length == 0)
                throw new ArgumentException("prefixes");
            HttpListener listener = new HttpListener();

            foreach (string s in prefixes)
            {
                listener.Prefixes.Add(s);
            }
            listener.Start();
            Console.WriteLine("Listening...");

            HttpListenerContext context = listener.GetContext();
            HttpListenerRequest request = context.Request;
            HttpListenerResponse response = context.Response;
            var url = request.Url;
            Console.WriteLine(request.Url.OriginalString);
            var responseData = Controller.ExecuteRequest(request.Url.OriginalString);
  
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseData.ResponseText);
            response.StatusCode = (int)responseData.statusCode;
            if (responseData.Header != "")
            {
                response.Headers.Add("X-MyName", responseData.Header);
            }
            if (responseData.Coockie != "")
            {
                response.Cookies.Add(new Cookie() { Name = "MyName", Value = responseData.Coockie });
            }


            response.ContentLength64 = buffer.Length;
            System.IO.Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);

            output.Close();
            listener.Stop();
         
        }
    }
}
