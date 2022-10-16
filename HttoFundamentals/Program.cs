using HttoFundamentalsListener;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttoFundamentals
{
    internal class Program
    {

        public static async Task Main(string[] args)
        {
            while (true)
            {
                SimpleListener.SimpleListenerExample(new string[] { "http://localhost:8888/" });
            }
            
            
        }
    }
}
